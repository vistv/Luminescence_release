using System;
using Luminescence.Engine.Controllers.UsbConntrollers;

namespace Luminescence.Engine.Controllers.DimensionControllers
{
    public class DimensionController : IDimensionController
    {
        #region Fields

        private readonly IUsbHidController _usbHid;
        private readonly Enum _startImpulseCounterCmd;
        private const byte CHANNEL_A_START_BYTE = 2;
        private const byte CHANNEL_B_START_BYTE = 5;
        private const byte CHANNEL_BIT = 3;

        #endregion

        #region Properties

        public IDataDimension DataOfLastDimension { get; private set; } = new DataDimension();

        #endregion

        #region Events

        public event EventHandler<EventArgs> OneDimensionCompleted;

        #endregion

        #region OnEvents

        protected void OnOneDimensionCompleted(EventArgs e)
        {
            OneDimensionCompleted?.Invoke(this, e);
        }

        #endregion

        #region Constructors

        public DimensionController(IUsbHidController usbHid, Enum startImpulseCounterCmd)
        {
            _usbHid = usbHid;
            _startImpulseCounterCmd = startImpulseCounterCmd;
        }

        #endregion

        #region Methods

        public void StartDimension(byte timeDelaySec)
        {
            if (this.SendCommandToStartDimension(timeDelaySec))
            {
                if (this.SendCommandToReceiveDataOfDimension())
                {
                    this.DataOfLastDimension = GetDataOfDimension();
                    this.OnOneDimensionCompleted(EventArgs.Empty);
                }
            }
        }

        #endregion

        #region Helpers

        private bool SendCommandToStartDimension(byte timeDelaySec)
        {
            if (_usbHid.IsConnected)
            {
                lock (_usbHid)
                {
                    return _usbHid.SendComand(_startImpulseCounterCmd, timeDelaySec);
                }
            }
            return false;
        }

        private bool SendCommandToReceiveDataOfDimension()
        {
            if (_usbHid.IsConnected)
            {
                lock (_usbHid)
                {
                    return _usbHid.ReceiveViaUsb();
                }
            }
            return false;
        }

        private DataDimension GetDataOfDimension()
        {
            return new DataDimension(
                this.ParceDataFromBytes(CHANNEL_A_START_BYTE), 
                this.ParceDataFromBytes(CHANNEL_B_START_BYTE));
        }

        private int ParceDataFromBytes(byte channelStartByte)
        {
            int impulceCount = 0;
            int maxCountNumbersImByte = (Byte.MaxValue + 1);
            for (byte i = 0; i < CHANNEL_BIT; i++)
            {
                impulceCount += (int)Math.Pow(maxCountNumbersImByte, i) * _usbHid.FromDeviceToHostBuffer[channelStartByte + i];
            }
            return impulceCount;
        }

        #endregion
    }
}
