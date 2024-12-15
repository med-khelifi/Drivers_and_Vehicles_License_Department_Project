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
   
    public partial class ucLDLApplicationDetails : UserControl
    {
        public delegate void ShowPersonDetails();
        public ShowPersonDetails OnShowPersonDetailsClicked;
        public int LDLAppID { set { lblDLAppID.Text = value.ToString(); } }
        public string LicenseClass { set { lblLicenseClass.Text = value; } }
        public int PassedTests { set { lblPassedTests.Text = value.ToString() + "/3"; } }

        public int AppID { set { lblAppID.Text = value.ToString(); } }
        public string AppStatus { set { lblStatus.Text = value; } }
        public float AppFees { set { lblFees.Text = value.ToString(); } }
        public string AppType { set { lblAppType.Text = value; } }
        public string Applicant { set {  lblApplicant.Text = value; } }
        public DateTime AppStatusDate { set { lblSatusDate.Text = value.ToString(); } }
        public DateTime AppDate { set{ lblDate.Text = value.ToString(); } }
        public string CreatedByUser { set{ lblCreatedByUser.Text = value; } }

        public ucLDLApplicationDetails()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnShowPersonDetailsClicked?.Invoke();
        }
    }
}
