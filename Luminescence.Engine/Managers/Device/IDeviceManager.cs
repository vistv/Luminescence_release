using System;
using Luminescence.Engine.Managers.Settings;

namespace Luminescence.Engine.Managers.Device
{
    public interface IDeviceManager
    {
        event EventHandler<EventArgs> Connected;
        event EventHandler<EventArgs> Disconnected;

        bool IsConnected { get; }
        IConnectionSettingsManager ConnectionSettingsManager { get; }
    }
}

namespace Device {
	public interface IDeviceManager  {

		event EventHandler<EventArgs> Connected;

		IConnectionSettingsManager ConnectionSettingsManager{
			get;
		}

		event EventHandler<EventArgs> Disconnected;

		bool IsConnected{
			get;
		}
	}//end IDeviceManager

}//end namespace Device