namespace Luminescence.Engine.Repositories.Settings.StepMotorSettings
{
    public interface IStepMotorRepository
    {
        float CountStepsPer1Nm { get; set; }
        byte DelayMsPer1Step { get; set; }
        float CurrentWavelength { get; set; }
    }
}
