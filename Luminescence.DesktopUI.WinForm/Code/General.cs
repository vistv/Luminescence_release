using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Luminescence.DesktopUI.WinForm.Code
{
    public static class General
    {
        public static bool CheckAtReqular(this TextBox textBox, Regex regex)
        {
            if (regex.IsMatch(textBox.Text))
            {
                textBox.ClearUndo();
                return true;
            }
            textBox.Undo();
            return false;
        }

        public static void ShowNotApllayedButton(this Button button)
        {
            button.BackColor = Color.Chartreuse;
        }

        public static void ShowApllayedButton(this Button button)
        {
            button.BackColor = Color.Empty;
        }
    }
}