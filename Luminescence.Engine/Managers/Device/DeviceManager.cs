using System;
using Luminescence.Engine.Controllers.UsbConntrollers;
using Luminescence.Engine.Managers.Settings;

namespace Luminescence.Engine.Managers.Device
{
    public class DeviceManager : IDeviceManager
    {
        private readonly IUsbHidController _usbHid;

        public bool IsConnected => _usbHid.IsConnected;

        public IConnectionSettingsManager ConnectionSettingsManager { get; }

        public event EventHandler<EventArgs> Connected
        {
            add { _usbHid.DeviceConnected += value; }
            remove { _usbHid.DeviceConnected += value; }
        }

        public event EventHandler<EventArgs> Disconnected
        {
            add { _usbHid.DeviceDisconnected += value; }
            remove { _usbHid.DeviceDisconnected -= value; }
        }

        public DeviceManager(IUsbHidController usbHid, IConnectionSettingsManager connectionSettingsManager)
        {
            _usbHid = usbHid;
            this.ConnectionSettingsManager = connectionSettingsManager;
        }
    }
}