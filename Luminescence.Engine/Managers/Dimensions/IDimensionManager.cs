using System;
using System.Threading.Tasks;
using System.Threading;
using Luminescence.Engine.Controllers.DimensionControllers;
using Luminescence.Engine.Managers.Settings;
using Luminescence.Engine.Managers.StepMotors;

namespace Luminescence.Engine.Managers.Dimensions
{
    public interface IDimensionManager
    {
        event EventHandler<EventArgs> DimensionCompleted;

        IDimensionSettingsManager Settings { get; }
        IDataDimension LastDataOfDimension { get; }

        void MakeDimension();
    }
}