using System;
using Luminescence.Engine.Repositories.Settings.StepMotorSettings;

namespace Luminescence.Engine.Managers.Settings
{
    public class StepMotorSettingsManager : IStepMotorSettingsManager
    {
        #region Fields

        private float _countNmPer1Step;
        private float _countStepsPer1Nm;
        private byte _delayMsPer1Step;
        private float _currentWavelength;

        private readonly IStepMotorRepository _stepMotorRepository;

        #endregion

        #region Constructor

        public StepMotorSettingsManager(IStepMotorRepository stepMotorRepository)
        {
            _stepMotorRepository = stepMotorRepository;
            this.InitValuesFromRepositories();
        }

        #endregion

        #region Events
        public event EventHandler<EventArgs> CurrentWavelengthChanged;
        public event EventHandler<EventArgs> CountStepsPer1NmChanged;
        public event EventHandler<EventArgs> CountNmPer1StepChanged;
        public event EventHandler<EventArgs> DelayMsPer1StepChanged;

        #endregion

        #region OnEvents
        protected void OnCurrentWavelengthChanged(EventArgs e)
        {
            this.CurrentWavelengthChanged?.Invoke(this, e);
        }

        protected void OnCountNmPer1StepChanged(EventArgs e)
        {
            this.CountNmPer1StepChanged?.Invoke(this, e);
        }
        protected void OnCountStepsPer1NmChanged(EventArgs e)
        {
            this.CountStepsPer1NmChanged?.Invoke(this, e);
        }

        protected void OnDelayMsPer1StepChanged(EventArgs e)
        {
            this.DelayMsPer1StepChanged?.Invoke(this, e);
        }

        #endregion

        #region Properties

        public float CountNmPer1Step
        {
            get { return _countNmPer1Step; }
            set
            {
                _countNmPer1Step = value;
                this.OnCountNmPer1StepChanged(EventArgs.Empty);
            }
        }

        public float CountStepsPer1Nm
        {
            get { return _countStepsPer1Nm; }
            set
            {
                _stepMotorRepository.CountStepsPer1Nm = value;
                _countStepsPer1Nm = value;
                _countNmPer1Step = 1f / _countStepsPer1Nm;
                this.OnCountStepsPer1NmChanged(EventArgs.Empty);
            }
        }

        public byte DelayMsPer1Step
        {
            get { return _delayMsPer1Step; }
            set
            {
                _stepMotorRepository.DelayMsPer1Step = value;
                _delayMsPer1Step = value;
                this.OnDelayMsPer1StepChanged(EventArgs.Empty);
            }
        }

        public float CurrentWavelength
        {
            get { return _currentWavelength; }
            set
            {
                _stepMotorRepository.CurrentWavelength = value;
                _currentWavelength = value;
                this.OnCurrentWavelengthChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Helpers

        private void InitValuesFromRepositories()
        {
            _currentWavelength = _stepMotorRepository.CurrentWavelength;
            _countStepsPer1Nm = _stepMotorRepository.CountStepsPer1Nm;
            _countNmPer1Step = 1f / _countStepsPer1Nm;
            _delayMsPer1Step = _stepMotorRepository.DelayMsPer1Step;
        }

        #endregion
    }
}