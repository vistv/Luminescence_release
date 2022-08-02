using System;

namespace Luminescence.Engine.Controllers.DimensionControllers
{
    public interface IDimensionController
    {
        event EventHandler<EventArgs> OneDimensionCompleted;
        IDataDimension DataOfLastDimension { get; }
        void StartDimension(byte timeDelaySec);
    }
}
