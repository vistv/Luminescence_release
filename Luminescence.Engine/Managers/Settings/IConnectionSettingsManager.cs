using System;

namespace Luminescence.Engine.Managers.Settings
{
    public interface IConnectionSettingsManager
    {
        event EventHandler<EventArgs> PidChanged;
        event EventHandler<EventArgs> VidChanged;
        event EventHandler<EventArgs> ConnectionTimeRefreshingChanged;

        string Pid { get; set; }
        string Vid { get; set; }
        int ConnectionTimeRefreshing { get; set; }
    }
}