using System;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLoggingScrren()); // Replace 'MainForm' with your startup form
        }
    }
}
