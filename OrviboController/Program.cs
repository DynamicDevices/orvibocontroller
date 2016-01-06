using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using OrviboController.Common;

namespace OrviboController
{
    static class Program
    {
        static Controller _controller;
        private static bool _showDiscoverResponse;
        private static bool _showSubscriptionResponse;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            bool showHelp = false;

            if (args.Length == 0)
            {
                showHelp = true;
            }
            else
            {
                switch (args[0].ToLower())
                {
                    case "?" :
                    case "help":
                        showHelp = true;
                        break;

                    case "discover":

                        try
                        {
                            SetupController();
                            DoDiscovery();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                        }

                        break;

                    case "query" :

                        if(args.Length != 3)
                        {
                            showHelp = true;
                            break;                            
                        }

                        try
                        {
                            var macAddr = PhysicalAddress.Parse(args[1]);
                            var ipAddr = IPAddress.Parse(args[2]);

                            _showSubscriptionResponse = true;

                            SetupController();
                            DoQuery(macAddr, ipAddr);
                        } catch(Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                        }
                        break;

                    case "seton" :

                        if(args.Length != 3)
                        {
                            showHelp = true;
                            break;                            
                        }

                        try
                        {
                            var macAddr = PhysicalAddress.Parse(args[1]);
                            var ipAddr = IPAddress.Parse(args[2]);

                            SetupController();
                            DoSet(macAddr, ipAddr, true);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                        }

                        break;

                    case "setoff" :

                        if(args.Length != 3)
                        {
                            showHelp = true;
                            break;                            
                        }

                        try
                        {
                            var macAddr = PhysicalAddress.Parse(args[1]);
                            var ipAddr = IPAddress.Parse(args[2]);

                            SetupController();
                            DoSet(macAddr, ipAddr, false);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                        }

                        break;

                    case "cycle" :

                        if(args.Length < 5)
                        {
                            showHelp = true;
                            break;
                        }

                        try
                        {
                            var macAddr = PhysicalAddress.Parse(args[1]);
                            var ipAddr = IPAddress.Parse(args[2]);
                            var ontimeS = int.Parse(args[3]);
                            var offtimeS = int.Parse(args[4]);
                            var cycleCount = 0;
                            if (args.Length == 6)
                                cycleCount = int.Parse(args[5]);

                            SetupController();
                            DoCycle(macAddr, ipAddr, ontimeS, offtimeS, cycleCount);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                        }

                        break;

                    default :
                        showHelp = true;
                        break;
                }
            }

            if (showHelp)
            {
                var version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;

                Console.WriteLine("OrviboController v" + version + " - discover, query and control Orvibo S20 wireless power sockets");
                Console.WriteLine("Syntax: OrviboController [command]");
                Console.WriteLine("Where command is one of:");
                Console.WriteLine("");
                Console.WriteLine("  discover");
                Console.WriteLine("   - discovers devices on local network segment and returns MAC address / IP address");
                Console.WriteLine(
                    "     (note you must have joined the device to the network and may need to power cycle to discover)");
                Console.WriteLine("  query macaddr ipaddr");
                Console.WriteLine("   - queries current state for device with given mac/IP");
                Console.WriteLine("  seton macaddr ipaddr");
                Console.WriteLine("   - sets current state to ON for device with given mac/IP");
                Console.WriteLine("  setoff macaddr ipaddr");
                Console.WriteLine("   - sets current state to OFF for device with given mac/IP");
                Console.WriteLine("  cycle macaddr ipaddr ontimesecs offtimesecs [cycles]");
                Console.WriteLine("   - cycle device on/off for given intervals in seconds, for a given number of cycles (or infinite)");
            }
        }

        private static bool SetupController()
        {
            _controller = Controller.CreateController(true);
            _controller.OnFoundNewDevice += _controller_OnFoundNewDevice;
            _controller.OnNewResponse += _controller_OnNewResponse;

            return true;
        }

        private static bool DoDiscovery()
        {
            if (!_controller.IsListening)
                _controller.StartListening();

            _showDiscoverResponse = true;

            _controller.SendDiscoveryCommand();

            Thread.Sleep(10000);

            return true;
        }

        private static bool DoQuery(PhysicalAddress macAddress, IPAddress ipAddress)
        {
            var device = Device.CreateDevice(ipAddress, macAddress);

            var subscription = Command.CreateSubscribeCommand(device);

            // Subscribe before we can do anything
            var success = _controller.SendCommandWaitResponse(device, subscription);

            return success;
        }

        private static bool DoSet(PhysicalAddress macAddress, IPAddress ipAddress, bool isOn)
        {
            var device = Device.CreateDevice(ipAddress, macAddress);

            var subscription = Command.CreateSubscribeCommand(device);

            // Subscribe before we can do anything
            var success = _controller.SendCommandWaitResponse(device, subscription);

            if (success)
            {
                // Handle the power control
                var control = Command.CreatePowerControlCommand(device, isOn);
                success = _controller.SendCommandWaitResponse(device, control);
            }

            return success;
        }

        private static bool DoCycle(PhysicalAddress macAddress, IPAddress ipAddress, int onTimeS, int offTimeS, int cycleCount)
        {
            var loop = cycleCount == 0;
            var iteration = 1;

            do
            {
                Console.WriteLine("Iteration " + iteration + ( (cycleCount > 0) ? " / " + cycleCount : "" ) );

                Console.WriteLine(" - set on");
                DoSet(macAddress, ipAddress, true);

                Console.WriteLine(" - wait " + onTimeS + " secs");
                Thread.Sleep(onTimeS * 1000);

                Console.WriteLine(" - set off");
                DoSet(macAddress, ipAddress, false);

                Console.WriteLine(" - wait " + offTimeS + " secs");
                Thread.Sleep(offTimeS * 1000);

            } while (((iteration++ < cycleCount) || loop) && !Console.KeyAvailable);

            Console.WriteLine("Done");

            return true;
        }

        private static void _controller_OnFoundNewDevice(object sender, DeviceEventArgs e)
        {
            if (_showDiscoverResponse) 
                Console.WriteLine("Found Device with MAC Address: " + e.Device.MacAddr + ", IP Address: " + e.Device.IpAddr);
        }

        private static void _controller_OnNewResponse(object sender, ResponseEventArgs e)
        {
            var rsp = e.Response;
            if (rsp is PowerControlResponse)
            {
            }
            else if (rsp is SubscriptionResponse)
            {
                if (_showSubscriptionResponse)
                    Console.WriteLine("Power State: " + ((SubscriptionResponse) rsp).PowerState);
            }
        }

    }
}
