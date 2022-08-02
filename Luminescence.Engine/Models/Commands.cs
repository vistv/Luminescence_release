namespace Luminescence.Engine.Models
{
    public enum ImpulseCounterCommands
    {
        On = 0x51
    }

    public enum StepMotor1Commands
    {
        SetTimeDelayMs = 0x20,
        Increment = 0x21,
        Decrement = 0x22,
    }

    public enum StepMotor2Commands
    {
        SetTimeDelayMs = 0x30,
        Increment = 0x31,
        Decrement = 0x32
    }

    public enum StepMotorWay
    {
        Increment = 1,
        Decrement = -1
    }

    public enum ActiveStepMotor
    {
        StepMotor1 = 1,
        StepMotor2 = 2
    }
}
