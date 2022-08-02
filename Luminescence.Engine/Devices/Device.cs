using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Luminescence.Engine.Code;
using Luminescence.Engine.Code.Checkings.Diapason;
using Luminescence.Engine.Controllers.DimensionControllers;
using Luminescence.Engine.Managers.Device;
using Luminescence.Engine.Managers.Dimensions;
using Luminescence.Engine.Managers.Saver;
using Luminescence.Engine.Managers.Settings;
using Luminescence.Engine.Managers.StepMotors;
using Luminescence.Engine.Models;


namespace Luminescence.Engine.Devices
{
    public class Device : IDevice
    {
        #region Fields

        private readonly IStepMotorManager _sm1Manager;
        private readonly IStepMotorManager _sm2Manager;
        private readonly IDimensionManager _dimManager;
        private readonly IDiapasonChecking _diapasonChecking;
        private IStepMotorSettingsManager _activeSMSettings;
        private IStepMotorManager _activeSMManager;
        private ActiveStepMotor _activeStepMotor;

        private Task _idlingTask = null;
        private Task _workflowTask = null;

        private CancellationTokenSource _workflowCts;
        private PauseTokenSource _workflowPts;
        private CancellationTokenSource _idlingCts;

        private readonly Stopwatch _elapsedOneDim = new Stopwatch();

        #endregion

        #region Constructor

        public Device(IStepMotorManager stepMotorManager1, IStepMotorManager stepMotorManager2,
            IDimensionManager dimensionManager,
            IDeviceManager deviceManager,
            IDiapasonChecking diapasonChecking, 
            ICustomFileNameSaverManager saver)
        {
            _sm1Manager = stepMotorManager1;
            _sm2Manager = stepMotorManager2;
            _dimManager = dimensionManager;
            _diapasonChecking = diapasonChecking;
            this.DeviceManager = deviceManager;

            this.Saver = saver;
            this.Saver.DimensionSettings = this.DimensionSettings;

            this.InitEvents();
            this.Init();
        }

        #endregion

        #region Initiators

        private void Init()
        {
            this.CurrentActiveStepMotor = ActiveStepMotor.StepMotor1;
        }

        private void InitEvents()
        {
            this.WorkflowDimensionsStarted += (sender, args) =>
            {
                this.PercenteCompleted = 0;
                this.RemainingTime = new TimeSpan(0);
                this.ElapsedTime = new TimeSpan(0);
                _elapsedOneDim.Reset();
                this.Saver.Results.Clear();
            };

            this.WorkflowOneDimensionCompleted += (sender, args) =>
            {
                this.PercenteCompleted = (byte)((Math.Abs(DimensionSettings.BeginPosition - this.ActiveStepMotorSettings.CurrentWavelength)) /
                Math.Abs(this.DimensionSettings.BeginPosition - this.DimensionSettings.EndPosition) * 100);

                bool isFirstTime = ElapsedTime == TimeSpan.Zero;
                this.ElapsedTime += _elapsedOneDim.Elapsed;
                if (isFirstTime)
                {
                    if (this.PercenteCompleted != 0)
                    {
                        this.RemainingTime =
                            TimeSpan.FromMilliseconds((int) (ElapsedTime.Milliseconds*100/this.PercenteCompleted));
                    }
                }
                else
                {
                    if (this.PercenteCompleted != 0)
                    {
                        // _device.ActiveStepMotorSettings.CurrentWavelength

                        //int a = ElapsedTime.Seconds;
                        //double a = ElapsedTime.TotalSeconds;
                       // TimeSpan.FromSeconds

                        this.RemainingTime =
                            TimeSpan.FromSeconds((int)(ElapsedTime.TotalSeconds * (100.0 / this.PercenteCompleted-1.0)));
                    }
                }

                this.Saver.Results.Add(new Results(this.LastDataOfDimension, this.StepMotor1Settings.CurrentWavelength, this.StepMotor2Settings.CurrentWavelength));
            };

            _dimManager.DimensionCompleted += (sender, args) =>
            {
                if (this.IsIdling)
                {
                    this.OnIdlingCompleted(EventArgs.Empty);
                }
                else if (this.IsWorkflowing)
                {
                    this.OnWokflowOneDimensionCompleted(EventArgs.Empty);
                    this.PercenteCompleted = 100;
                    _elapsedOneDim.Reset();
                }
            };

            EventHandler<EventArgs> windStarted = (sender, args) =>
            {
                if (this.IsWinding)
                {
                    this.OnWindStarted(EventArgs.Empty);
                }
            };

            EventHandler<EventArgs> windAborted = (sender, args) =>
            {
                if (this.IsWinding)
                {
                    this.OnWindAborted(EventArgs.Empty);
                }
            };

            EventHandler<EventArgs> windCompleted = (sender, args) =>
            {
                if (this.IsWinding)
                {
                    this.OnWindCompleted(EventArgs.Empty);
                }
            };
            _sm1Manager.StepMotorStarted += windStarted;
            _sm1Manager.StepMotorAborted += windAborted;
            _sm1Manager.StepMotorCompleted += windCompleted;

            _sm2Manager.StepMotorStarted += windStarted;
            _sm2Manager.StepMotorAborted += windAborted;
            _sm2Manager.StepMotorCompleted += windCompleted;
        }

        #endregion

        #region Events 

        public event EventHandler<EventArgs> WorkflowDimensionsStarted;
        public event EventHandler<EventArgs> WorkflowDimensionsAborted;
        public event EventHandler<EventArgs> WorkflowDimensionsCompleted;
        public event EventHandler<EventArgs> WorkflowOneDimensionCompleted;
        public event EventHandler<EventArgs> WorkflowDimensionsPaused;
        public event EventHandler<EventArgs> WorkflowDimensionsResumed;

        public event EventHandler<EventArgs> IdlingDimensionsStarted;
        public event EventHandler<EventArgs> IdlingDimensionsAborted;
        public event EventHandler<EventArgs> IdlingDimensionCompleted;

        public event EventHandler<EventArgs> WindCompleted;
        public event EventHandler<EventArgs> WindStarted;
        public event EventHandler<EventArgs> WindAborted;

        public event EventHandler<EventArgs> ActiveStepMotorChanged;

        #endregion

        #region OnEvents

        protected void OnWorkflowDimensionsStarted(EventArgs e)
        {
            this.WorkflowDimensionsStarted?.Invoke(this, e);
        }

        protected void OnWokflowOneDimensionCompleted(EventArgs e)
        {
            this.WorkflowOneDimensionCompleted?.Invoke(this, e);
        }

        protected void OnWorflowDimensionsPaused(EventArgs e)
        {
            this.IsWorkflowingPaused = true;
            this.WorkflowDimensionsPaused?.Invoke(this, e);
        }

        protected void OnWorflowDimensionsResumed(EventArgs e)
        {
            this.IsWorkflowingPaused = false;
            this.WorkflowDimensionsResumed?.Invoke(this, e);
        }
        protected void OnWorflowDimensionsAborted(EventArgs e)
        {
            this.WorkflowDimensionsAborted?.Invoke(this, e);
        }

        protected void OnWorflowDimensionsCompleted(EventArgs e)
        {
            this.WorkflowDimensionsCompleted?.Invoke(this, e);
        }

        protected void OnIdlingDimensionsStarted(EventArgs e)
        {
            this.IdlingDimensionsStarted?.Invoke(this, e);
        }

        protected void OnIdlingDimensionsAborted(EventArgs e)
        {
            this.IdlingDimensionsAborted?.Invoke(this, e);
        }

        protected void OnIdlingCompleted(EventArgs e)
        {
            this.IdlingDimensionCompleted?.Invoke(this, e);
        }

        protected void OnWindStarted(EventArgs e)
        {
            this.WindStarted?.Invoke(this, e);
        }

        protected void OnWindAborted(EventArgs e)
        {
            this.WindAborted?.Invoke(this, e);
        }

        protected void OnWindCompleted(EventArgs e)
        {
            this.WindCompleted?.Invoke(this, e);
        }

        protected void OnActiveStepMotorChanged(EventArgs e)
        {
            this.ActiveStepMotorChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Properties

        public ICustomFileNameSaverManager Saver { get; }
        public IStepMotorSettingsManager StepMotor1Settings => _sm1Manager.Settings;
        public IStepMotorSettingsManager StepMotor2Settings => _sm2Manager.Settings;
        public ActiveStepMotor CurrentActiveStepMotor
        {
            get { return _activeStepMotor; }
            set
            {
                _activeStepMotor = value;
                if (value == ActiveStepMotor.StepMotor1)
                {
                    _activeSMManager = _sm1Manager;
                    _activeSMSettings = StepMotor1Settings;
                }
                else
                {
                    _activeSMManager = _sm2Manager;
                    _activeSMSettings = StepMotor2Settings;
                }
                this.OnActiveStepMotorChanged(EventArgs.Empty);
            }
        }
        public IDimensionSettingsManager DimensionSettings => _dimManager.Settings;
        public IStepMotorSettingsManager ActiveStepMotorSettings => _activeSMSettings;
        public IDeviceManager DeviceManager { get; }
        public IDataDimension LastDataOfDimension => _dimManager.LastDataOfDimension;

        public bool IsWinding { get; private set; } = false;
        public bool IsWorkflowing { get; private set; } = false;
        public bool IsIdling { get; private set; } = false;
        public bool IsWorkflowingPaused { get; private set; } = false;

        public byte PercenteCompleted { get; private set; }
        public TimeSpan ElapsedTime { get; private set; }
        public TimeSpan RemainingTime { get; private set; }

        #endregion

        #region Methods

        public bool StartDimensions()
        {
            if (!this.IsDeviceBusy())
            {
                _workflowTask = new Task(async () =>
                {
                    if (_activeSMManager.SetTimeDelay())
                    {
                        this.OnWorkflowDimensionsStarted(EventArgs.Empty);
                        this.IsWorkflowing = true;
                        _workflowCts = new CancellationTokenSource();
                        _workflowPts = new PauseTokenSource();
                        _dimManager.Settings.BeginPosition = this.ActiveStepMotorSettings.CurrentWavelength;
                        
                        Func<float, float, float, bool> checkDiapason;
                        StepMotorWay way;
                        if (this.ActiveStepMotorSettings.CurrentWavelength < _dimManager.Settings.EndPosition)
                        {
                            way = StepMotorWay.Increment;
                            checkDiapason = _diapasonChecking.DiapasonForward;
                        }
                        else
                        {
                            way = StepMotorWay.Decrement;
                            checkDiapason = _diapasonChecking.DiapasonBack;
                        }
                        float next = 0;

                        while (!_workflowCts.Token.IsCancellationRequested)
                        {
                            _elapsedOneDim.Start();
                            _dimManager.MakeDimension();

                            if (way == StepMotorWay.Increment)
                            {
                                next = this.ActiveStepMotorSettings.CurrentWavelength +
                                       _dimManager.Settings.DimensionStepNm;
                            }
                            else
                            {
                                next = this.ActiveStepMotorSettings.CurrentWavelength -
                                       _dimManager.Settings.DimensionStepNm;
                            }

                            if (checkDiapason(this.ActiveStepMotorSettings.CurrentWavelength,
                                _dimManager.Settings.DimensionStepNm, _dimManager.Settings.EndPosition))
                            {
                                if (await _activeSMManager.RunAsync(next, true))
                                {
                                    _elapsedOneDim.Stop();
                                    if (_workflowPts.IsPaused)
                                    {
                                        this.OnWorflowDimensionsPaused(EventArgs.Empty);
                                        await _workflowPts.WaitWhilePausedAsync();
                                        this.OnWorflowDimensionsResumed(EventArgs.Empty);
                                    }
                                }
                                else
                                {
                                    _elapsedOneDim.Stop();
                                    break;
                                }
                            }
                            else
                            {
                                this.OnWorflowDimensionsCompleted(EventArgs.Empty);
                                this.IsWorkflowing = false;
                                _elapsedOneDim.Stop();
                                this.StartIdling();
                                return;
                            }
                        }
                        this.OnWorflowDimensionsAborted(EventArgs.Empty);
                        this.IsWorkflowing = false;
                        this.StartIdling();
                    }
                });
                _idlingTask.ContinueWith((idlingTask) =>
                {
                    _workflowTask.Start();
                });
                this.StopIdling();
                return true;
            }
            return false;
        }

        public void AbortDimensions()
        {
            _workflowCts.Cancel();
        }

        public void PauseDimensions()
        {
            _workflowPts.IsPaused = true;
        }

        public void ResumeDimensions()
        {
            _workflowPts.IsPaused = false;
        }

        public void Increment()
        {
            if (!this.IsDeviceBusy())
            {
                _activeSMManager.Increment();
            }
        }

        public void Decrement()
        {
            if (!this.IsDeviceBusy())
            {
                _activeSMManager.Decrement();
            }
        }

        public bool StartWindAsync(float moveToNm)
        {
            if (Math.Abs(this.ActiveStepMotorSettings.CurrentWavelength - moveToNm) < this.ActiveStepMotorSettings.CountNmPer1Step)
            {
                return false;
            }
            if (!this.IsDeviceBusy())
            {
                this.StopIdling();
                if (_activeSMManager.SetTimeDelay())
                {
                    if (_diapasonChecking.DiapasonForward(_activeSMManager.Settings.CurrentWavelength,
                        _activeSMManager.Settings.CountNmPer1Step, moveToNm) ||
                        _diapasonChecking.DiapasonBack(_activeSMManager.Settings.CurrentWavelength,
                            _activeSMManager.Settings.CountNmPer1Step, moveToNm))
                    {
                        this.IsWinding = true;
                        Task task = _activeSMManager.RunAsync(moveToNm, false);
                            task.ContinueWith((some) => 
                        {
                            this.IsWinding = false;
                            this.StartIdling();
                        });
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void StopWind()
        {
            _activeSMManager.StopStepMotor();
        }

        public void StartDevice()
        {
            this.StartIdling();
        }

        public void CalibrateActiveStepMotor(float beginPosition, float realEndPosition)
        {
            if (!this.IsDeviceBusy())
            {
                _activeSMManager.Calibrate(beginPosition, realEndPosition);
            }
        }

        #endregion

        #region Helpers

        private bool IsDeviceBusy()
        {
            if (this.IsWorkflowing || this.IsWinding)
            {
                return true;
            }
            return false;
        }

        private void StartIdling()
        {
            if (!this.IsDeviceBusy())
            {
                _idlingTask = new Task(() =>
                {
                    this.IsIdling = true;
                    _idlingCts = new CancellationTokenSource();
                    this.OnIdlingDimensionsStarted(EventArgs.Empty);
                    while (!_idlingCts.IsCancellationRequested)
                    {
                        _dimManager.MakeDimension();
                    }
                    this.IsIdling = false;
                    this.OnIdlingDimensionsAborted(EventArgs.Empty);
                }, TaskCreationOptions.PreferFairness);
                _idlingTask.Start();
            }
        }

        private void StopIdling()
        {
            _idlingCts.Cancel();
        }

        #endregion
    }
}
