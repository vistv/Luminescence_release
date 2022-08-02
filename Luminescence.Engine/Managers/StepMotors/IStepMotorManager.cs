using System;
using System.Threading.Tasks;
using Luminescence.Engine.Managers.Settings;

namespace Luminescence.Engine.Managers.StepMotors
{
    public interface IStepMotorManager
    {
        bool IsStepMotorBusy { get; }
        int LastSpendedStepMotorSteps { get; }
        IStepMotorSettingsManager Settings { get; }

        #region Events

        event EventHandler<EventArgs> StepMotorStarted;
        event EventHandler<EventArgs> StepMotorCompleted;
        event EventHandler<EventArgs> StepMotorAborted;
        event EventHandler<EventArgs> StepMotorIncrement;
        event EventHandler<EventArgs> StepMotorDecrement;

        event EventHandler<EventArgs> StepMotorIncrementedPackage;
        event EventHandler<EventArgs> StepMotorDecrementedPackage;

        #endregion

        #region Methods

        bool SetTimeDelay();
        Task<bool> RunAsync(float moveToNm, bool doAtOneRequest);
        void StopStepMotor();
        void Increment();
        void Decrement();
        void Calibrate(float beginPosition, float realEndPosition);

        #endregion
    }
}
