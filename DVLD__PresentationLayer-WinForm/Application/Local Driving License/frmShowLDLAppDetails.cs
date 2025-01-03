using BVLD__BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmShowLDLAppDetails : Form
    {

        int _LDLApplicationID = 0;
        public frmShowLDLAppDetails(int LDLAppID)
        {
            InitializeComponent();
            ucLDLApplicationDetails1.LoadApplicationInfoByLocalDrivingAppID(LDLAppID);
        }
        
    }
}
