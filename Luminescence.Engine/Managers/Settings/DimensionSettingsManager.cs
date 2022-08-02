using System;
using Luminescence.Engine.Repositories.Settings.ConnectionSettings;
using Luminescence.Engine.Repositories.Settings.DimensionSettings;
using Luminescence.Engine.Repositories.Settings.StepMotorSettings;

namespace Luminescence.Engine.Managers.Settings
{
    public class DimensionSettingsManager : IDimensionSettingsManager
    {
        #region Fields

        private readonly IDimensionRepository _dimensionRepository;

        private float _beginPosition;
        private float _endPosition;
        private byte _dimensionDelaySec;
        private float _dimensionStepNm;

        #endregion

        #region Events

        public event EventHandler<EventArgs> BeginPositionChanged;
        public event EventHandler<EventArgs> EndPositionChanged;
        public event EventHandler<EventArgs> DimensionDelaySecChanged;
        public event EventHandler<EventArgs> DimensionStepNmChanged; 

        #endregion

        #region OnEvents

        protected void OnBeginPositionChanget(EventArgs e)
        {
            this.BeginPositionChanged?.Invoke(this, e);
        }
        protected void OnEndPositionChanget(EventArgs e)
        {
            this.EndPositionChanged?.Invoke(this, e);
        }
        protected void OnDimensionDelaySecChanget(EventArgs e)
        {
            this.DimensionDelaySecChanged?.Invoke(this, e);
        }
        protected void OnDimensionStepNmChanged(EventArgs e)
        {
            this.DimensionStepNmChanged?.Invoke(this, e);
        }

        #endregion

        #region Properties

        public float BeginPosition
        {
            get { return _beginPosition; }
            set
            {
                _dimensionRepository.BeginWavelength = value;
                _beginPosition = value;
                this.OnBeginPositionChanget(EventArgs.Empty);
            }
        }

        public float EndPosition
        {
            get { return _endPosition; }
            set
            {
                _dimensionRepository.EndWavelength = value;
                _endPosition = value;
                this.OnEndPositionChanget(EventArgs.Empty);
            }
        }

        public byte DimensionDelaySec
        {
            get { return _dimensionDelaySec; }
            set
            {
                _dimensionRepository.DelaySec = value;
                _dimensionDelaySec = value;
                this.OnDimensionDelaySecChanget(EventArgs.Empty);
            }
        }

        public float DimensionStepNm
        {
            get { return _dimensionStepNm; }
            set
            {
                _dimensionRepository.StepNms = value;
                _dimensionStepNm = value;
                this.OnDimensionStepNmChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Constructor

        public DimensionSettingsManager(IDimensionRepository dimensionRepository)
        {
            _dimensionRepository = dimensionRepository;
            this.InitValuesFromRepositories();
        }

        #endregion

        #region Helpers

        private void InitValuesFromRepositories()
        {
            _beginPosition = _dimensionRepository.BeginWavelength;
            _endPosition = _dimensionRepository.EndWavelength;
            _dimensionDelaySec = _dimensionRepository.DelaySec;
            _dimensionStepNm = _dimensionRepository.StepNms;
        }

        #endregion
    }
}