using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luminescence.DesktopUI.WinForm.Code
{
    public static  class InvokeControls
    {
        public static void InvokeIfRequired(Control c, Action action)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(action);
            }
            else
            {
                action();
            }
        }

        public static void InvokeIfRequired<T>(T c, Action<T> action) where T : Control
        {
            if (c.InvokeRequired)
            {
                c.Invoke(action, c);
            }
            else
            {
                action(c);
            }
        }
    }
}
