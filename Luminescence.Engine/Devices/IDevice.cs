using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using Luminescence.Engine.Code.Checkings.Diapason;
using Luminescence.Engine.Controllers.DimensionControllers;
using Luminescence.Engine.Managers.Device;
using Luminescence.Engine.Managers.Dimensions;
using Luminescence.Engine.Managers.Settings;
using Luminescence.Engine.Managers.StepMotors;



using System.Threading.Tasks;
using System.Threading;
using Luminescence.Engine.Code;
using Luminescence.Engine.Managers.Saver;
using Luminescence.Engine.Models;


namespace Luminescence.Engine.Devices
{
    public interface IDevice
    {
        #region Events 

        // Wokflow Mode Events
        event EventHandler<EventArgs> WorkflowDimensionsStarted;
        event EventHandler<EventArgs> WorkflowDimensionsAborted;
        event EventHandler<EventArgs> WorkflowDimensionsCompleted;
        event EventHandler<EventArgs> WorkflowOneDimensionCompleted;
        event EventHandler<EventArgs> WorkflowDimensionsPaused;
        event EventHandler<EventArgs> WorkflowDimensionsResumed;

        // Idling Mode Events
        event EventHandler<EventArgs> IdlingDimensionsStarted;
        event EventHandler<EventArgs> IdlingDimensionsAborted;
        event EventHandler<EventArgs> IdlingDimensionCompleted;

        event EventHandler<EventArgs> WindCompleted;
        event EventHandler<EventArgs> WindStarted;
        event EventHandler<EventArgs> WindAborted; 

        event EventHandler<EventArgs> ActiveStepMotorChanged;

        #endregion

        #region Properties

        ICustomFileNameSaverManager Saver { get; }
        IStepMotorSettingsManager StepMotor1Settings { get; }
        IStepMotorSettingsManager StepMotor2Settings { get; }
        ActiveStepMotor CurrentActiveStepMotor { get; set; }
        IDimensionSettingsManager DimensionSettings { get; }
        IStepMotorSettingsManager ActiveStepMotorSettings { get; }
        IDeviceManager DeviceManager { get; }
        IDataDimension LastDataOfDimension { get; }
        bool IsWinding { get; }
        bool IsWorkflowing { get; }
        bool IsIdling { get; }
        bool IsWorkflowingPaused { get; }

        byte PercenteCompleted { get; }
        TimeSpan ElapsedTime { get; }
        TimeSpan RemainingTime { get; }

        #endregion

        #region Methods

        bool StartDimensions();
        void AbortDimensions();
        void PauseDimensions();
        void ResumeDimensions();

        void Increment();
        void Decrement();
        bool StartWindAsync(float moveToNm);
        void StopWind();
        void StartDevice();
        void CalibrateActiveStepMotor(float beginPosition, float realEndPosition);

        #endregion
    }
}
