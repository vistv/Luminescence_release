using System;
using System.Threading.Tasks;
using System.Threading;
using Luminescence.Engine.Controllers.DimensionControllers;
using Luminescence.Engine.Managers.Settings;

namespace Luminescence.Engine.Managers.Dimensions
{
    public class DimensionManager : IDimensionManager
    {
        private readonly IDimensionController _dimensionController;

        public event EventHandler<EventArgs> DimensionCompleted
        {
            add { _dimensionController.OneDimensionCompleted += value; }
            remove { _dimensionController.OneDimensionCompleted -= value; }
        }
        public IDataDimension LastDataOfDimension => _dimensionController.DataOfLastDimension;
        public IDimensionSettingsManager Settings { get; }

        public DimensionManager(IDimensionController dimensionController, 
            IDimensionSettingsManager dimensionSettingsManager)
        {
            _dimensionController = dimensionController;
            this.Settings = dimensionSettingsManager;
        }

        public void MakeDimension()
        {
            _dimensionController.StartDimension(this.Settings.DimensionDelaySec);
        }
    }
}