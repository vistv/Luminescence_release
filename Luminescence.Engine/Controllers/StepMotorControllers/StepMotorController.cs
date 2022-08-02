using System;
using Luminescence.Engine.Controllers.UsbConntrollers;

namespace Luminescence.Engine.Controllers.StepMotorControllers
{
    public class StepMotorController : IStepMotorController
    {
        private const byte COUNT_BYTES = 2;

        private readonly IUsbHidController _usbHid;

        private readonly Enum _incrementCmd;
        private readonly Enum _decrementCmd;
        private readonly Enum _timeDelayMsCmd;

        public StepMotorController(IUsbHidController usbHid, Enum timeDelayMsCmd, Enum incrementCmd, Enum decrementCmd)
        {
            _usbHid = usbHid;
            _incrementCmd = incrementCmd;
            _decrementCmd = decrementCmd;
            _timeDelayMsCmd = timeDelayMsCmd;
        }

        public bool Increment()
        {
            if (_usbHid.IsConnected)
            {
                if (_usbHid.SendComand(_incrementCmd, 1))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Decrement()
        {
            if (_usbHid.IsConnected)
            {
                if (_usbHid.SendComand(_decrementCmd, 1))
                {
                    return true;
                }
            }
            return false;
        }

        public bool RunForward(int countSteps)
        {
            byte[] bytes = CalculateBytes(countSteps);
            if (_usbHid.IsConnected)
            {
                if (_usbHid.SendComand(_incrementCmd, bytes[0], bytes[1]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool RunBack(int countSteps)
        {
            byte[] bytes = CalculateBytes(countSteps);
            if (_usbHid.IsConnected)
            {
                if (_usbHid.SendComand(_decrementCmd, bytes[0], bytes[1]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool StepMotorReady()
        {
            if (_usbHid.IsConnected)
            {
                return true;
            }

            return false;
        }

        public bool SetTimeDelayMs(byte timeDelayMs)
        {
            if (_usbHid.IsConnected)
            {
                if (_usbHid.SendComand(_timeDelayMsCmd, timeDelayMs))
                {
                    return true;
                }
            }
            return false;
        }

        #region Helpers

        private byte[] CalculateBytes(int countSteps)
        {
            return new byte[COUNT_BYTES]
            {
                (byte)countSteps,
                (byte)(countSteps/Byte.MaxValue)
            };
        }

        #endregion
    }
}
