using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Luminescence.Engine.Code.Checkings.Diapason;
using Ninject;
using Luminescence.Engine.Controllers;
using Luminescence.Engine.Controllers.DimensionControllers;
using Luminescence.Engine.Controllers.StepMotorControllers;
using Luminescence.Engine.Controllers.UsbConntrollers;
using Luminescence.Engine.Devices;
using Luminescence.Engine.Managers.Device;
using Luminescence.Engine.Managers.Dimensions;
using Luminescence.Engine.Managers.Saver;
using Luminescence.Engine.Managers.Settings;
using Luminescence.Engine.Managers.StepMotors;
using Luminescence.Engine.Models;
using Luminescence.Engine.Repositories.ResultSavers;
using Luminescence.Engine.Repositories.Settings.ConnectionSettings;
using Luminescence.Engine.Repositories.Settings.DimensionSettings;
using Luminescence.Engine.Repositories.Settings.StepMotorSettings;
using Ninject.Infrastructure.Introspection;

namespace Luminescence.DesktopUI.WinForm.DI
{
    public class CompositionRoot
    {
        #region Fields

        private readonly IKernel _kernel;

        #endregion

        #region Constructors

        public CompositionRoot(IKernel kernel)
        {
            _kernel = kernel;
            this.AddBindings();
        }

        #endregion

        #region Helpers

        private void AddBindings()
        {
            /*Repositories*/

            string picConfigFilePath = string.Concat(Application.StartupPath, "/", ConfigurationManager.AppSettings["picConfigFilePath"]);
            string picConfigFileName = ConfigurationManager.AppSettings["picConfigFileName"];

            string saverConfigFilePath = String.Concat(Application.StartupPath, "/", ConfigurationManager.AppSettings["saverConfigFilePath"]);
            string saverConfigFileName = ConfigurationManager.AppSettings["saverConfigFileName"];

            byte theFindedInXmlNumberSettingsConnection =
                Byte.Parse(ConfigurationManager.AppSettings["theFindedInXmlNumberSettingsConnection"]);

            byte theFindedInXmlNumberSettingsDimensions =
                Byte.Parse(ConfigurationManager.AppSettings["theFindedInXmlNumberSettingsDimensions"]);

            byte theFindedInXmlNumberSettingsStepMotor1 =
                Byte.Parse(ConfigurationManager.AppSettings["theFindedInXmlNumberSettingsStepMotor1"]);

            byte theFindedInXmlNumberSettingsStepMotor2 =
                Byte.Parse(ConfigurationManager.AppSettings["theFindedInXmlNumberSettingsStepMotor2"]);

            _kernel.Bind<IConnectionRepository>().To<ConnectionRepository>().
                WithConstructorArgument("filePath", picConfigFilePath).
                WithConstructorArgument("fileName", picConfigFileName).
                WithConstructorArgument("theFindedInXmlFileNumber", theFindedInXmlNumberSettingsConnection);

            _kernel.Bind<IDimensionRepository>().To<DimensionRepository>().
                WithConstructorArgument("filePath", picConfigFilePath).
                WithConstructorArgument("fileName", picConfigFileName).
                WithConstructorArgument("theFindedInXmlFileNumber", theFindedInXmlNumberSettingsDimensions);
            
            _kernel.Bind<IStepMotorRepository>().To<StepMotorRepository>().
                WithConstructorArgument("filePath", picConfigFilePath).
                WithConstructorArgument("fileName", picConfigFileName).
                WithConstructorArgument("theFindedInXmlFileNumber", theFindedInXmlNumberSettingsStepMotor1);

            _kernel.Bind<IStepMotorRepository>().To<StepMotorRepository>().
                WithConstructorArgument("filePath", picConfigFilePath).
                WithConstructorArgument("fileName", picConfigFileName).
                WithConstructorArgument("theFindedInXmlFileNumber", theFindedInXmlNumberSettingsStepMotor2);

            _kernel.Bind<ILastFileNameSaverRepository>().To<LastFileNameSaverRepository>().
                WithConstructorArgument("confFilePath", saverConfigFilePath).
                WithConstructorArgument("confFileName", saverConfigFileName);

            /*Setting Managers*/

            _kernel.Bind<IStepMotorSettingsManager>().To<StepMotorSettingsManager>().
                WithConstructorArgument("stepMotorRepository", _kernel.GetAll<IStepMotorRepository>().ElementAt(0));

            _kernel.Bind<IStepMotorSettingsManager>().To<StepMotorSettingsManager>().
                WithConstructorArgument("stepMotorRepository", _kernel.GetAll<IStepMotorRepository>().ElementAt(1));

            _kernel.Bind<IDimensionSettingsManager>().To<DimensionSettingsManager>().
                WithConstructorArgument("dimensionRepository", _kernel.Get<IDimensionRepository>());

            _kernel.Bind<IConnectionSettingsManager>().To<ConnectionSettingsManager>().
                WithConstructorArgument("connectionRepository", _kernel.Get<IConnectionRepository>());

            _kernel.Bind<IUsbHidController>().To<UsbHidController>()
                .WithConstructorArgument("vid", _kernel.Get<IConnectionRepository>().Vid).
                WithConstructorArgument("pid", _kernel.Get<IConnectionRepository>().Pid).
                WithConstructorArgument("connectionTimeInterval",
                    _kernel.Get<IConnectionRepository>().ConnectionTimeRefreshing);
            
            _kernel.Bind<IStepMotorController>().To<StepMotorController>().
                WithConstructorArgument("usbHid", _kernel.Get<IUsbHidController>()).
                WithConstructorArgument("timeDelayMsCmd", StepMotor1Commands.SetTimeDelayMs).
                WithConstructorArgument("incrementCmd", StepMotor1Commands.Increment).
                WithConstructorArgument("decrementCmd", StepMotor1Commands.Decrement);
                
            _kernel.Bind<IStepMotorController>().To<StepMotorController>().
                WithConstructorArgument("usbHid", _kernel.Get<IUsbHidController>()).
                WithConstructorArgument("timeDelayMsCmd", StepMotor2Commands.SetTimeDelayMs).
                WithConstructorArgument("incrementCmd", StepMotor2Commands.Increment).
                WithConstructorArgument("decrementCmd", StepMotor2Commands.Decrement);
                
            _kernel.Bind<IDimensionController>().To<DimensionController>().
                WithConstructorArgument("usbHid", _kernel.Get<IUsbHidController>()).
                WithConstructorArgument("startImpulseCounterCmd", ImpulseCounterCommands.On);


            /*Managers*/

            _kernel.Bind<IStepMotorManager>().To<StepMotorManager>().
                WithConstructorArgument("stepMotorController", _kernel.GetAll<IStepMotorController>().ElementAt(0)).
                WithConstructorArgument("stepMotorSettingsManager",
                    _kernel.GetAll<IStepMotorSettingsManager>().ElementAt(0));

            _kernel.Bind<IStepMotorManager>().To<StepMotorManager>().
                WithConstructorArgument("stepMotorController", _kernel.GetAll<IStepMotorController>().ElementAt(1)).
                WithConstructorArgument("stepMotorSettingsManager",
                    _kernel.GetAll<IStepMotorSettingsManager>().ElementAt(1));

            _kernel.Bind<IDimensionManager>().To<DimensionManager>().
                WithConstructorArgument("dimensionController", _kernel.Get<IDimensionController>()).
                WithConstructorArgument("dimensionSettingsManager", _kernel.Get<IDimensionSettingsManager>());

            _kernel.Bind<IDeviceManager>().To<DeviceManager>().
                WithConstructorArgument("usbHid", _kernel.Get<IUsbHidController>()).
                WithConstructorArgument("connectionSettingsManager", _kernel.Get<IConnectionSettingsManager>());

            /*Savers*/
            _kernel.Bind<ICustomFileNameSaverManager>().To<CustomFileNameSaverManager>().
                WithConstructorArgument("resultSaverRepository", _kernel.Get<ILastFileNameSaverRepository>());

            /*Devices*/

            _kernel.Bind<IDevice>().To<Engine.Devices.Device>().
                WithConstructorArgument("stepMotorManager1", _kernel.GetAll<IStepMotorManager>().ElementAt(0)).
                WithConstructorArgument("stepMotorManager2", _kernel.GetAll<IStepMotorManager>().ElementAt(1)).
                WithConstructorArgument("dimensionManager", _kernel.Get<IDimensionManager>()).
                WithConstructorArgument("deviceManager", _kernel.Get<IDeviceManager>()).
                WithConstructorArgument("diapasonChecking", new MinimumInterval()).
                WithConstructorArgument("saver", _kernel.Get<ICustomFileNameSaverManager>());
        }

        #endregion
    }
}