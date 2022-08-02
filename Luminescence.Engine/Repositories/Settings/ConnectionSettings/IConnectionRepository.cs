namespace Luminescence.Engine.Repositories.Settings.ConnectionSettings
{
    public interface IConnectionRepository
    {
        string Vid { get; set; }
        string Pid { get; set; }
        int ConnectionTimeRefreshing { get; set; }
    }
}
