using System;

namespace Luminescence.Engine.Code.Checkings.Diapason
{
    public class MinimumInterval : IDiapasonChecking
    {
        public bool DiapasonForward(float currentPosition, float step, float endPosition)
        {
            float next = currentPosition + step;
            if (next < endPosition)
            {
                return true;
            }
            else
            {
                if (next - endPosition < endPosition - currentPosition)
                {
                    return true;
                }
            }

            return false;
        }

        public bool DiapasonBack(float currentPosition, float step, float endPosition)
        {
            float next = currentPosition - step;  
            if (next > endPosition)
            {
                return true;
            }
            else
            {
                if (endPosition - next < currentPosition - endPosition)
                {
                    return true;
                }
            }
            return false;
        }
    }
}