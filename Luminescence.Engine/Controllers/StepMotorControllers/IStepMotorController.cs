namespace Luminescence.Engine.Controllers.StepMotorControllers
{
    public interface IStepMotorController
    {
        bool Increment();
        bool Decrement();
        bool RunForward(int countSteps);
        bool RunBack(int countSteps);
        bool SetTimeDelayMs(byte timeDelayMs);
        bool StepMotorReady();
    }
}
