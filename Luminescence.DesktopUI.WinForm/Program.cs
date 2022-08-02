using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Luminescence.DesktopUI.WinForm.DI;
using Luminescence.Engine.Devices;
using Ninject;

namespace Luminescence.DesktopUI.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Init default app culture.
            InitDefaultAppCulture();

            // Create kernel for DI.
            IKernel kernel = new StandardKernel();
            var compositionRoot = new CompositionRoot(kernel);

            // Run application.
            Application.Run(new MainForm(kernel.Get<IDevice>()));
        }

        private static void InitDefaultAppCulture()
        {
            var culture = new CultureInfo(ConfigurationManager.AppSettings["AppCulture"]);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
