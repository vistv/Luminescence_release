namespace Luminescence.Engine.Code.Checkings.Diapason
{
    public interface IDiapasonChecking
    {
        bool DiapasonForward(float currentPosition, float step, float endPosition);
        bool DiapasonBack(float currentPosition, float step, float endPosition);
    }
}