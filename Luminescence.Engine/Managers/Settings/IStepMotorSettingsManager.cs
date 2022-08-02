using System;

namespace Luminescence.Engine.Managers.Settings
{
    public interface IStepMotorSettingsManager
    {
        float CountNmPer1Step { get; }
        float CountStepsPer1Nm { get; set; }
        byte DelayMsPer1Step { get; set; }
        float CurrentWavelength { get; set; }

        event EventHandler<EventArgs> CurrentWavelengthChanged;
        event EventHandler<EventArgs> CountStepsPer1NmChanged;
        event EventHandler<EventArgs> DelayMsPer1StepChanged;
    }
}