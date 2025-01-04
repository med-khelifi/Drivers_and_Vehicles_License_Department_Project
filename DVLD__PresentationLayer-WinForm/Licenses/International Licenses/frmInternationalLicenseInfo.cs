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
    public partial class frmInternationalLicenseInfo : Form
    {
        
        int _InternationalLicenseID = 0;
        public frmInternationalLicenseInfo(int internationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID=internationalLicenseID;
        }
        
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
           ucInternationalLicenseInfo1.LoadInfo(_InternationalLicenseID);
        }
    }
}
