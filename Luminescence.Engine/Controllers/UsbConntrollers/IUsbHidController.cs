using System;

namespace Luminescence.Engine.Controllers.UsbConntrollers
{
    public interface IUsbHidController
    {
        String DeviceId { get; }
        bool IsConnected { get; }                   
        byte[] FromDeviceToHostBuffer { get; set; }       
        byte[] FromHostToDeviceBuffer { get; set; }
        bool ReceiveViaUsb();
        bool SendViaUsb();
        bool SendComand(Enum cmd, byte additionalData0 = 0, byte additionalData1 = 0);

        #region Events

        event EventHandler<EventArgs> DeviceConnected;
        event EventHandler<EventArgs> DeviceDisconnected;

        #endregion
    }
}
