using System;
using System.Windows.Forms;
using OrviboController.Common;

namespace OrviboController.UI
{
    delegate void AddDeviceHandler(Device device);

    public partial class MainForm : Form
    {
        private readonly Controller _controller;
        private bool _isCycling;
        private bool _nextCycleIsOn;
        private int _onIntervalS;
        private int _offIntervalS;
        private DateTime _dtLastCycleCommand = DateTime.MinValue;
        private int _currentCycle;
        private int _maxCycles;

        public MainForm()
        {
            InitializeComponent();

            var version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            Text += @" v" + version;

            _controller = Controller.CreateController(false);
            _controller.OnFoundNewDevice += _controller_OnFoundNewDevice;
            _controller.OnNewResponse += _controller_OnNewResponse;
        }

        void AddNewDevice( Device device )
        {
            if(InvokeRequired)
            {
                Invoke(new AddDeviceHandler(AddNewDevice), new object[] {device});
                return;
            }

            foreach (Device d in comboBoxDevices.Items)
                if (d.MacAddr.ToString() == device.MacAddr.ToString())
                    return;

            comboBoxDevices.Items.Add(device);
            if (comboBoxDevices.Items.Count == 1)
                comboBoxDevices.SelectedIndex = 0;
        }

        void _controller_OnFoundNewDevice(object sender, DeviceEventArgs e)
        {
            AddNewDevice(e.Device);
        }

        void _controller_OnNewResponse(object sender, ResponseEventArgs e)
        {
            var rsp = e.Response;
            if (rsp is PowerControlResponse)
            {
                BeginInvoke(new MethodInvoker(delegate
                                             {
                                                 labelStatus.Text = ((PowerControlResponse) rsp).PowerState
                                                                        ? "Status: On"
                                                                        : "Status: Off";
                                             }));
            }
            else if (rsp is SubscriptionResponse)
            {
                BeginInvoke(new MethodInvoker(delegate
                                             {
                                                labelStatus.Text = ((SubscriptionResponse) rsp).PowerState ? "Status: On" : "Status: Off";
                                             }));
            }
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void ButtonExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonFindDevicesClick(object sender, EventArgs e)
        {
            if (!_controller.IsListening)
                _controller.StartListening();
            _controller.SendDiscoveryCommand();
        }

        private void CheckBoxManualCheckedChanged(object sender, EventArgs e)
        {
            buttonFindDevices.Enabled = !checkBoxManual.Checked;
            groupBoxManual.Enabled = checkBoxManual.Checked;
        }

        private void CheckBoxCycleCheckedChanged(object sender, EventArgs e)
        {
            groupBoxCycle.Enabled = checkBoxCycle.Checked;
        }

        private void ButtonQueryClick(object sender, EventArgs e)
        {
            var success = false;
            toolStripStatusLabel1.Text = @"Querying";
            Application.DoEvents();

            if (!_controller.IsListening)
                _controller.StartListening();

            try
            {

                Device device = null;

                if (checkBoxManual.Checked)
                {
                    var ipAddress = textBoxIPAddress.Text;
                    var macAddress = textBoxMACAddress.Text;

                    device = Device.CreateDevice(ipAddress, macAddress);
                }
                else
                {
                    if (comboBoxDevices.SelectedIndex < 0)
                        return;

                    device = (Device) comboBoxDevices.SelectedItem;
                }

                success = DoQuery(device);

            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Exception: " + ex.Message);
            }

            toolStripStatusLabel1.Text = success ? "OK" : "ERROR";
        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            var success = false;
            toolStripStatusLabel1.Text = @"Setting On";
            Application.DoEvents();

            if (!_controller.IsListening)
                _controller.StartListening();

            try
            {

                Device device = null;

                if (checkBoxManual.Checked)
                {
                    var ipAddress = textBoxIPAddress.Text;
                    var macAddress = textBoxMACAddress.Text;

                    device = Device.CreateDevice(ipAddress, macAddress);
                }
                else
                {
                    if (comboBoxDevices.SelectedIndex < 0)
                        return;

                    device = (Device)comboBoxDevices.SelectedItem;
                }

                success = DoControlPower(device, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Exception: " + ex.Message);
            }

            toolStripStatusLabel1.Text = success ? "OK" : "ERROR";
        }

        private void ButtonOffClick(object sender, EventArgs e)
        {
            var success = false;
            toolStripStatusLabel1.Text = @"Setting Off";
            Application.DoEvents();

            if (!_controller.IsListening)
                _controller.StartListening();

            try
            {

                Device device = null;

                if (checkBoxManual.Checked)
                {
                    var ipAddress = textBoxIPAddress.Text;
                    var macAddress = textBoxMACAddress.Text;

                    device = Device.CreateDevice(ipAddress, macAddress);
                }
                else
                {
                    if (comboBoxDevices.SelectedIndex < 0)
                        return;

                    device = (Device)comboBoxDevices.SelectedItem;
                }

                success = DoControlPower(device, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Exception: " + ex.Message);
            }

            toolStripStatusLabel1.Text = success ? "OK" : "ERROR";
        }

        private bool DoQuery(Device device)
        {
            var subscription = Command.CreateSubscribeCommand(device);

            // Subscribe before we can do anything
            var success = _controller.SendCommandWaitResponse(device, subscription);

            return success;
        }

        private bool DoControlPower(Device device, bool on)
        {
            var subscription = Command.CreateSubscribeCommand(device);

            // Subscribe before we can do anything
            var success = _controller.SendCommandWaitResponse(device, subscription);

            if (success)
            {
                // Handle the power control
                var control = Command.CreatePowerControlCommand(device, on);
                success = _controller.SendCommandWaitResponse(device, control);
            }

            return success;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            // Setup UI
            checkBoxCycle.Checked = false;
            CheckBoxManualCheckedChanged(this, null);
            CheckBoxCycleCheckedChanged(this, null);
            buttonStartCycling.Enabled = true;
            buttonStopCycling.Enabled = false;
        }

        private void ButtonStartCyclingClick(object sender, EventArgs e)
        {
            try
            {
                _onIntervalS = int.Parse(textBoxOnTimeS.Text);
                _offIntervalS = int.Parse(textBoxOffTimeS.Text);
                _isCycling = true;
                timerCycle.Enabled = true;
                _nextCycleIsOn = true;
                _currentCycle = 0;
                _dtLastCycleCommand = DateTime.MinValue;
                buttonStartCycling.Enabled = false;
                buttonStopCycling.Enabled = true;
                _maxCycles = int.Parse(textBoxCycleCount.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Exception: " + ex.Message);
            }
        }

        private void ButtonStopCyclingClick(object sender, EventArgs e)
        {
            buttonStopCycling.Enabled = false;
            _isCycling = false;
        }

        private void TimerCycleTick(object sender, EventArgs e)
        {

            if (_nextCycleIsOn)
            {
                if ((DateTime.Now - _dtLastCycleCommand).TotalSeconds > _offIntervalS)
                {
                    if (_maxCycles > 0)
                    {
                        _currentCycle++;
                        labelCurrentCycle.Text = (_maxCycles - _currentCycle).ToString();
                    }
                    else
                        labelCurrentCycle.Text = @"∞";

                    ButtonOnClick(this, null);
                    _dtLastCycleCommand = DateTime.Now;
                    _nextCycleIsOn = !_nextCycleIsOn;
                }
            }
            else
            {
                if (!_isCycling || ( (DateTime.Now - _dtLastCycleCommand).TotalSeconds > _onIntervalS ))
                {
                    ButtonOffClick(this, null);
                    _dtLastCycleCommand = DateTime.Now;
                    _nextCycleIsOn = !_nextCycleIsOn;

                    if (!_isCycling || (_currentCycle == _maxCycles && _maxCycles > 0))
                    {
                        ButtonStopCyclingClick(this, null);
                        buttonStartCycling.Enabled = true;

                        if (!_isCycling)
                            timerCycle.Enabled = false;                        
                    }
                }
            }
        }
    }
}
