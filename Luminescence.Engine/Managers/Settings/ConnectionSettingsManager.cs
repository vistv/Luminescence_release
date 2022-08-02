using System;
using Luminescence.Engine.Repositories.Settings.ConnectionSettings;

namespace Luminescence.Engine.Managers.Settings
{
    public class ConnectionSettingsManager : IConnectionSettingsManager
    {
        #region Fields

        private readonly IConnectionRepository _connectionRepository;
        private string _pid;
        private string _vid;
        private int _connectionTimeRefreshing;

        #endregion

        #region Constructor

        public ConnectionSettingsManager(IConnectionRepository connectionRepository)
        {
            _connectionRepository = connectionRepository;
            this.InitValuesFromRepositories();
        }

        #endregion

        #region Events

        public event EventHandler<EventArgs> PidChanged;
        public event EventHandler<EventArgs> VidChanged;
        public event EventHandler<EventArgs> ConnectionTimeRefreshingChanged;

        #endregion

        #region OnEvents

        protected void OnPidChanget(EventArgs e)
        {
            this.PidChanged?.Invoke(this, e);
        }
        protected void OnVidChanget(EventArgs e)
        {
            this.VidChanged?.Invoke(this, e);
        }
        protected void OnConnectionTimeRefreshingChanget(EventArgs e)
        {
            this.ConnectionTimeRefreshingChanged?.Invoke(this, e);
        }

        #endregion

        #region Properties

        public string Vid
        {
            get { return _vid; }
            set
            {
                _connectionRepository.Vid = value;
                _vid = value;
                this.OnVidChanget(EventArgs.Empty);
            }
        }

        public string Pid
        {
            get { return _pid; }
            set
            {
                _connectionRepository.Pid = value;
                _pid = value;
                this.OnPidChanget(EventArgs.Empty);
            }
        }

        public int ConnectionTimeRefreshing
        {
            get { return _connectionTimeRefreshing; }
            set
            {
                _connectionRepository.ConnectionTimeRefreshing = value;
                _connectionTimeRefreshing = value;
                this.OnConnectionTimeRefreshingChanget(EventArgs.Empty);
            }
        }

        #endregion

        #region Helpers

        private void InitValuesFromRepositories()
        {
            _vid = _connectionRepository.Vid;
            _pid = _connectionRepository.Pid;
            _connectionTimeRefreshing = _connectionRepository.ConnectionTimeRefreshing;
        }

        #endregion
    }
}