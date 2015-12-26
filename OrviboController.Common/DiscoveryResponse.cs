namespace OrviboController.Common
{
    public class DiscoveryResponse : Response
    {
        private readonly Device _device;

        public DiscoveryResponse(Device device)
        {
            _device = device;
        }

        public Device Device
        {
            get { return _device; }
        }
    }
}
