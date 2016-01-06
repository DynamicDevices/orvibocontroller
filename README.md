
Orvibo Controller
=================

A basic little .NET application to turn the Orvibo S20 on and off automatically for testing purposes.

This is based on Andrius Stikonas and others' work as documented here https://stikonas.eu/wordpress/2015/02/24/reverse-engineering-orvibo-s20-socket/

Discovery of devices (MAC/IP) and also manual control of an S20 for which you have the IP address and MAC address is possible.

There are two utilities, one with a user interface and one to operate from the command line

- The UI utility can be used to set cycle on/off times and a max cycle count for testing.
- The console utility can be used in a similar manner to discover query, set and cycle devices