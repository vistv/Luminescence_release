using System;

namespace Luminescence.Engine.Repositories.Settings.ConnectionSettings
{
    public class ConnectionRepository : Repository, IConnectionRepository
    {
        #region Constants

        private const string PID = "pid";
        private const string VID = "vid";
        private const string CONNECTION_TIME_REFRESHING = "connectionTimeRefreshing";

        #endregion

        #region Constructor

        public ConnectionRepository(string filePath, string fileName)
            : base(filePath, fileName)
        { }

        #endregion

        #region Properties

        public string Pid
        {
            get
            {
                return base.GetValue(PID);
            }
            set
            {
                base.SaveValue(PID, value);
            }
        }

        public string Vid
        {
            get
            {
                return base.GetValue(VID);
            }
            set
            {
                base.SaveValue(VID, value);
            }
        }

        public int ConnectionTimeRefreshing
        {
            get
            {
                return int.Parse(base.GetValue(CONNECTION_TIME_REFRESHING));
            }
            set
            {
                base.SaveValue(CONNECTION_TIME_REFRESHING, value.ToString());
            }
        }

        #endregion
    }
}
