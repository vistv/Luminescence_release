using System;
using System.Configuration;
using System.Windows.Forms;
using Luminescence.Engine.Code.Checkings.Diapason;
using Luminescence.Engine.Controllers;
using Luminescence.Engine.Managers.Settings;
using Luminescence.Engine.Devices;
using Luminescence.Engine.Controllers.DimensionControllers;
using Luminescence.Engine.Controllers.StepMotorControllers;
using Luminescence.Engine.Controllers.UsbConntrollers;
using Luminescence.Engine.Managers.Device;
using Luminescence.Engine.Managers.Dimensions;
using Luminescence.Engine.Managers.Saver;
using Luminescence.Engine.Managers.StepMotors;
using Luminescence.Engine.Models;
using Luminescence.Engine.Repositories.Settings.ConnectionSettings;
using Luminescence.Engine.Repositories.Settings.DimensionSettings;
using Luminescence.Engine.Repositories.Settings.StepMotorSettings;

namespace Luminescence.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string settingsFileName = ConfigurationManager.AppSettings["filePath"] + "\\" + ConfigurationManager.AppSettings["fileName"];//"Settings.xml";
            byte theFindedInXmlFileNumber = 0;


            IDimensionRepository dimensionRepository = new DimensionRepository(Application.StartupPath, settingsFileName, theFindedInXmlFileNumber);
            IConnectionRepository connectionRepository = new ConnectionRepository(Application.StartupPath, settingsFileName);
            IStepMotorRepository stepMotorRepository = new StepMotorRepository(Application.StartupPath, settingsFileName, theFindedInXmlFileNumber);
           
            


            IStepMotorSettingsManager stepMotorSettingsManager = new StepMotorSettingsManager(stepMotorRepository);
            IDimensionSettingsManager dimensionSettingsManager = new DimensionSettingsManager(dimensionRepository);
            IConnectionSettingsManager connectionSettingsManager = new ConnectionSettingsManager(connectionRepository);


            IUsbHidController usbHidController = new UsbHidController(IntPtr.Zero, connectionSettingsManager.Vid, connectionSettingsManager.Pid, connectionSettingsManager.ConnectionTimeRefreshing);
            IDimensionController dimensionController = new DimensionController(usbHidController, ImpulseCounterCommands.On);
            IStepMotorController stepMotorController = new StepMotorController(usbHidController, StepMotor1Commands.SetTimeDelayMs, StepMotor1Commands.Increment, StepMotor1Commands.Decrement);

            IDiapasonChecking diapasonChecking = new MinimumInterval();

            IDimensionManager dimensionManager = new DimensionManager(dimensionController, dimensionSettingsManager);
            IStepMotorManager stepMotorManager = new StepMotorManager(stepMotorController, stepMotorSettingsManager);
            IDeviceManager deviceManager = new DeviceManager(usbHidController, connectionSettingsManager);

            IDevice device = new Engine.Devices.Device(stepMotorManager, stepMotorManager, dimensionManager, deviceManager, diapasonChecking, new CustomFileNameSaverManager(null));

            /*******************************************************************************************/

            /*Init*/
            Init(device);

            /*DeviceTest*/
            dimensionSettingsManager.EndPosition = 600;
            DeviceTest(device);


            /*Test*/


            /*StepMotorTest*/
            /*
            dimensionSettingsManager.CurrentWavelenghtChanged += (sender, eventArgs) =>
            {
                stepMotorManager.CurrentWavelenght = dimensionSettingsManager.CurrentWavelenght;
            };
            stepMotorManager.StepMotorIncrement += (sender, eventArgs) =>
            {
                dimensionSettingsManager.CurrentWavelenght += stepMotorManager.Settings.CountNmPer1Step;
            };
            stepMotorManager.StepMotorDecrement += (sender, eventArgs) =>
            {
                dimensionSettingsManager.CurrentWavelenght -= stepMotorManager.Settings.CountNmPer1Step;
            };

            StepMotorTest(stepMotorManager);
            
            //stepMotorSettingsManager.DelayMsPer1Step = 1333;
            //stepMotorManager.Settings.DelayMsPer1Step = 3454;
            */
            /*DimensionTest*/
            //DimensionTest(dimensionManager);


                




            //Test test = new Test();
            //test.UnSign();
            //test.OnTested(EventArgs.Empty);
            //test.Sign();
            //test.OnTested(EventArgs.Empty);

            Console.Read();
        }

        private static void DeviceTest(IDevice device)
        {
            device.IdlingDimensionsAborted += (sender, eventArgs) => { Console.WriteLine("IdlingAborted"); };
            device.IdlingDimensionCompleted += (sender, args) => { Console.WriteLine("IdlingCompleted"); };
            device.IdlingDimensionsStarted += (sender, args) => { Console.WriteLine("IdlingStarted"); };

            device.WorkflowDimensionsAborted += (sender, args) => { Console.WriteLine("WorflowAborted"); };
            device.WorkflowDimensionsCompleted += (sender, args) => { Console.WriteLine("WorflowCompleted"); };
            device.WorkflowDimensionsPaused += (sender, args) => { Console.WriteLine("WorflowPaused"); };
            device.WorkflowDimensionsResumed += (sender, args) => { Console.WriteLine("WorflowResumed"); };
            device.WorkflowDimensionsStarted += (sender, args) => { Console.WriteLine("WorflowStarted"); };

            device.ActiveStepMotorSettings.CurrentWavelengthChanged +=
                (sender, args) =>
                {
                    Console.WriteLine("CurrentWavelength : {0}", device.ActiveStepMotorSettings.CurrentWavelength);
                };

            device.StepMotor1Settings.DelayMsPer1Step = 1;
            device.StepMotor1Settings.CountStepsPer1Nm = 5;

            device.WorkflowOneDimensionCompleted +=
                (sender, args) =>
                {
                    Console.WriteLine("WorflowOneDimensionCompleted      currentWavelenght : {0}", device.ActiveStepMotorSettings.CurrentWavelength);
                };
            device.StartDevice();
            device.DimensionSettings.EndPosition = 520;
            System.Threading.Thread.Sleep(3000);
            device.StartWindAsync(530);
            System.Threading.Thread.Sleep(3000);

            device.StartDimensions();

            System.Threading.Thread.Sleep(3000);
            device.PauseDimensions();
            System.Threading.Thread.Sleep(4000);
            device.ResumeDimensions();
        }

        private static void Init(IDevice device)
        {
            device.DeviceManager.Connected += Connected;
            device.DeviceManager.Disconnected += Disconnected;
        }


        private static void StepMotorTest(IStepMotorManager stepMotorManager)
        {
            //stepMotorManager.Settings.CountStepsPer1Nm = 1;
            stepMotorManager.Settings.DelayMsPer1Step = 200;
            
            stepMotorManager.StepMotorIncrement += (sender, args) =>
            {
                Console.WriteLine("Increment");
                Console.WriteLine("time {0} ms", stepMotorManager.Settings.DelayMsPer1Step);
            };
            stepMotorManager.StepMotorDecrement += (sender, args) =>
            {
                Console.WriteLine("Decrement");
            };
            stepMotorManager.StepMotorCompleted += (sender, args) => { Console.WriteLine("Completed"); };
            stepMotorManager.StepMotorStarted += (sender, args) => { Console.WriteLine("Started"); };
            stepMotorManager.StepMotorAborted += (sender, args) => { Console.WriteLine("Aborted"); };

            Console.WriteLine("Settings information: ");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("countStepsPer1Nm : {0}", stepMotorManager.Settings.CountStepsPer1Nm);
            Console.WriteLine("countNmPer1Step : {0}", stepMotorManager.Settings.CountNmPer1Step);
            Console.WriteLine("delayMsPer1Step : {0}", stepMotorManager.Settings.DelayMsPer1Step);
            Console.WriteLine("**********************************************");
            

            stepMotorManager.RunAsync(420.5f, true);


            //stepMotorManager.RunAsync(35000).GetAwaiter();

            //Console.WriteLine("started");
            //System.Threading.Thread.Sleep(2000);
            //stepMotorManager.Decrement();
            //stepMotorManager.StopStepMotor();

        }


        private static void DimensionTest(IDimensionManager dimensionManager)
        {
            dimensionManager.Settings.DimensionDelaySec = 3;
            dimensionManager.Settings.DimensionStepNm = 1.1f;

            Console.WriteLine("Settings information: ");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("DimensionStepNm : {0}", dimensionManager.Settings.DimensionStepNm);
            Console.WriteLine("EndPosition : {0}", dimensionManager.Settings.EndPosition);
            Console.WriteLine("BeginPosition : {0}", dimensionManager.Settings.BeginPosition);
            Console.WriteLine("DimensionDelaySec : {0}", dimensionManager.Settings.DimensionDelaySec);
            Console.WriteLine("**********************************************");

            dimensionManager.DimensionCompleted += (sender, args) => { Console.WriteLine("Completed"); };

            //dimensionManager.DimensionCompleted;

            for (int i = 0; i < 100; i++)
            {
                dimensionManager.MakeDimension();
                Console.WriteLine("ChannelA: {0}, ChannelB: {1}", dimensionManager.LastDataOfDimension.ChannelA, dimensionManager.LastDataOfDimension.ChannelB);
            }

        }

        

        private class Test
        {
            public event EventHandler<EventArgs> Tested;

            public Test()
            {
                //Tested += (sender, args) => { Console.WriteLine("Test"); };
            }

            private Delegate[] list;
            public void Sign()
            {
                for (int i = 0; i < list?.Length; i++)
                {
                    Tested += (EventHandler<EventArgs>)list[i];
                }
            }

            public void UnSign()
            {
                list = Tested?.GetInvocationList();
                for (int i = 0; i < list?.Length; i++)
                {
                    Tested -= (EventHandler<EventArgs>)list[i];
                }
            }

            public void OnTested(EventArgs e)
            {
                this.Tested?.Invoke(this, e);
            }
        }

        private static void Device_StepMotorStarted(object sender, EventArgs e)
        {
            Console.WriteLine("Device_StepMotorStarted");
        }

        private static void Device_StepMotorIncremented(object sender, EventArgs e)
        {
            Console.WriteLine("Device_StepMotorIncremented");
        }

        private static void Device_StepMotorDecremented(object sender, EventArgs e)
        {
            Console.WriteLine("Device_StepMotorDecremented");
        }

        private static void Device_StepMotorCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Device_StepMotorCompleted");
        }

        private static void Device_StepMotorAborted(object sender, EventArgs e)
        {
            Console.WriteLine("Device_StepMotorAborted");
        }

        private static void Device_DimensionProccessStarted(object sender, EventArgs e)
        {
            Console.WriteLine("Device_DimensionProccessStarted");
        }

        private static void Device_DimensionProccessResumed(object sender, EventArgs e)
        {
            Console.WriteLine("Device_DimensionProccessResumed");
        }

        private static void Device_DimensionProccessPaused(object sender, EventArgs e)
        {
            Console.WriteLine("Device_DimensionProccessPaused");
        }

        private static void Device_DimensionProccessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Device_DimensionProccessCompleted");
        }

        private static void Device_DimensionProccessAborted(object sender, EventArgs e)
        {
            Console.WriteLine("Device_DimensionProccessAborted");
        }

        private static void Device_ReqularDimensionCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Device_ReqularDimensionCompleted");
        }

        private static void Connected(object obj, EventArgs e)
        {
            Console.WriteLine("device connected");
        }

        private static void Disconnected(object obj, EventArgs e)
        {
            Console.WriteLine("device disconnected");
        }
    }
}
