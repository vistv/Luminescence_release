using System;
using System.Threading;
using System.Threading.Tasks;
using Luminescence.Engine.Controllers.StepMotorControllers;
using Luminescence.Engine.Managers.Settings;
using Luminescence.Engine.Models;

namespace Luminescence.Engine.Managers.StepMotors
{
    public class StepMotorManager : IStepMotorManager
    {
        #region Constants

        private byte MIN_PACKAGE = 1;

        #endregion

        #region Fields 

        private CancellationTokenSource _cts;
        private readonly IStepMotorController _stepMotorController;
        private float _moveToNm;
        private int _packageSize;
        
        #endregion

        #region Properties

        public bool IsStepMotorBusy { get; private set; }
        public IStepMotorSettingsManager Settings { get; }
        public int LastSpendedStepMotorSteps { get; private set; }

        #endregion

        #region Constructors

        public StepMotorManager(IStepMotorController stepMotorController,
            IStepMotorSettingsManager stepMotorSettingsManager)
        {
            _stepMotorController = stepMotorController;
            this.Settings = stepMotorSettingsManager;

            this.StepMotorIncrement += (sender, args) =>
            {
                this.Settings.CurrentWavelength += this.Settings.CountNmPer1Step;
                this.AddCountLastSteps(_packageSize);
            };

            this.StepMotorDecrement += (sender, args) =>
            {
                this.Settings.CurrentWavelength -= this.Settings.CountNmPer1Step;
                this.AddCountLastSteps(_packageSize);
            };

            this.StepMotorIncrementedPackage += (sender, args) =>
            {
                this.Settings.CurrentWavelength += this.Settings.CountNmPer1Step*_packageSize;
                this.AddCountLastSteps(_packageSize);
            };

            this.StepMotorDecrementedPackage += (sender, args) =>
            {
                this.Settings.CurrentWavelength -= this.Settings.CountNmPer1Step*_packageSize;
                this.AddCountLastSteps(_packageSize);
            };
        }

        #endregion

        #region Events

        public event EventHandler<EventArgs> StepMotorStarted;
        public event EventHandler<EventArgs> StepMotorCompleted;
        public event EventHandler<EventArgs> StepMotorAborted;
        public event EventHandler<EventArgs> StepMotorIncrement;
        public event EventHandler<EventArgs> StepMotorDecrement;

        public event EventHandler<EventArgs> StepMotorIncrementedPackage;
        public event EventHandler<EventArgs> StepMotorDecrementedPackage;

        #endregion

        #region Methods

        public Task<bool> RunAsync(float moveToNm, bool doAtOneRequest)
        {
            _moveToNm = moveToNm;
            StepMotorWay way = (this.Settings.CurrentWavelength < _moveToNm)
                ? StepMotorWay.Increment 
                : StepMotorWay.Decrement;

            if (!this.IsStepMotorBusy)
            {
                this.ClearCountLastSteps();
                this.BookStepMotor();
                _cts = new CancellationTokenSource();
                return Task.Factory.StartNew(() =>
                {
                    bool repeat = false;

                    Func<int> getPackageSize = () => (int)(Math.Abs(this.Settings.CurrentWavelength - _moveToNm) / this.Settings.CountNmPer1Step);
                    Func<float, float, float, bool> checkForwardDiapason = (current, step, end) => (current + step) < end;
                    Func<float, float, float, bool> checkBackDiapason = (current, step, end) => (current - step) > end;

                    // Define size of _packageSize.
                    if (doAtOneRequest || (Math.Abs(this.Settings.CurrentWavelength - _moveToNm) < this.Settings.CountNmPer1Step))
                    {
                        _packageSize = getPackageSize();
                    }
                    else
                    {
                        _packageSize = (int)this.Settings.CountStepsPer1Nm;
                        repeat = true;
                    }

                    // Define the function for way of step motor.
                    Func<bool> run;
                    Func<float, float, float, bool> checkDiapason;
                    if (way == StepMotorWay.Increment)
                    {
                        checkDiapason = checkForwardDiapason;
                        run = this.Forward;
                    }
                    else
                    {
                        checkDiapason = checkBackDiapason;
                        run = this.Back;
                    }

                    // Define where was informed about start 
                    bool wasInformed = false;
                    Func<bool> action = () =>
                    {
                        if (!this.Canceled() && run())
                        {
                            if (!wasInformed)
                            {
                                this.OnStepMotorStart(EventArgs.Empty);
                                wasInformed = true;
                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    };
                    while (checkDiapason(this.Settings.CurrentWavelength,
                        _packageSize * this.Settings.CountNmPer1Step,
                        _moveToNm))
                    {
                        if (!action())
                        {
                            FreeStepMotor();
                            this.OnStepMotorAbort(EventArgs.Empty);
                            return false;
                        }
                    }

                    if (repeat)
                    {
                        _packageSize = getPackageSize();
                        if (!action())
                        {
                            this.FreeStepMotor();
                            this.OnStepMotorAbort(EventArgs.Empty);
                            return false;
                        }
                    }
                    this.FreeStepMotor();
                    this.OnStepMotorCompleted(EventArgs.Empty);
                    return true;
                });
            }
            return new Task<bool>(() => false);
        }

        public void Increment()
        {
            if (!IsStepMotorBusy)
            {
                this.ClearCountLastSteps();
                BookStepMotor();
                _packageSize = MIN_PACKAGE;
                if (_stepMotorController.Increment())
                {
                    this.OnStepMotorIncrement(EventArgs.Empty);
                }
                FreeStepMotor();
            }
        }

        public void Decrement()
        {
            if (!IsStepMotorBusy)
            {
                this.ClearCountLastSteps();
                BookStepMotor();
                _packageSize = MIN_PACKAGE;
                if (_stepMotorController.Decrement())
                {
                    this.OnStepMotorDecrement(EventArgs.Empty);
                }
                FreeStepMotor();
            }
        }

        public void StopStepMotor()
        {
            _cts?.Cancel();
        }

        public bool SetTimeDelay()
        {
            return _stepMotorController.SetTimeDelayMs(this.Settings.DelayMsPer1Step);
        }

        public void Calibrate(float beginPosition, float realEndPosition)
        {
            if (this.LastSpendedStepMotorSteps != 0)
            {
                float countNmPer1Step = Math.Abs(realEndPosition - beginPosition)/this.LastSpendedStepMotorSteps;
                if (countNmPer1Step != 0)
                {
                    this.Settings.CountStepsPer1Nm = 1/countNmPer1Step;
                }
            }
        }

        #endregion

        #region OnEventsHandlers

        protected void OnStepMotorStart(EventArgs e)
        {
            BookStepMotor();
            this.StepMotorStarted?.Invoke(this, e);
        }

        protected void OnStepMotorCompleted(EventArgs e)
        {
            FreeStepMotor();
            this.StepMotorCompleted?.Invoke(this, e);
        }

        protected void OnStepMotorAbort(EventArgs e)
        {
            FreeStepMotor();
            this.StepMotorAborted?.Invoke(this, e);
        }

        protected void OnStepMotorIncrement(EventArgs e)
        {
            this.StepMotorIncrement?.Invoke(this, e);
        }

        protected void OnStepMotorDecrement(EventArgs e)
        {
            this.StepMotorDecrement?.Invoke(this, e);
        }

        protected void OnStepMotorIncrementedPackage(EventArgs e)
        {
            this.StepMotorIncrementedPackage?.Invoke(this, e);
        }

        protected void OnStepMotorDecrementedPackage(EventArgs e)
        {
            this.StepMotorDecrementedPackage?.Invoke(this, e);
        }

        #endregion

        #region Helpers

        private bool Forward()
        {
            if (_stepMotorController.RunForward(_packageSize))
            {
                this.OnStepMotorIncrementedPackage(EventArgs.Empty);
                return true;
            }
            return false;
        }

        private bool Back()
        {
            if (_stepMotorController.RunBack(_packageSize))
            {
                this.OnStepMotorDecrementedPackage(EventArgs.Empty);
                return true;
            }
            return false;
        }

        private bool Canceled()
        {
            return _cts.Token.IsCancellationRequested;
        }

        private void BookStepMotor()
        {
            IsStepMotorBusy = true;
        }

        private void FreeStepMotor()
        {
            IsStepMotorBusy = false;
        }

        private void ClearCountLastSteps()
        {
            this.LastSpendedStepMotorSteps = 0;
        }

        private void AddCountLastSteps(int value)
        {
            this.LastSpendedStepMotorSteps += value;
        }

        #endregion
    }
}
