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

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmLocalLicenseInfo : Form
    {
        int _LicenseID = -1;   
        public frmLocalLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            ucDriverLicenseInfo1.LoadInfo(_LicenseID);
        }
    }
}
