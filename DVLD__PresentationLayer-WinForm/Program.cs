﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmScheduleTests(1,7));
             Application.Run(new frmLoggingScrren());
            //Application.Run(new frmAddNewLDLApplication());
            //Application.Run(new frmManageLocalDrivingLicenseApplication());
            //Application.Run(new frmEditAddPerson());
            //Application.Run(new ScheduleTest());
        }
    }
}
