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

        clsApplication _Application;
        clsLDLApplication _LDLApp;
        int _LDLApplicationID = 0;
        public frmShowLDLAppDetails(int LDLAppID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLAppID;
        }
        private void _LoadLDLApplicationData()
        {
            _LDLApp = clsLDLApplication.Find(_LDLApplicationID);
            if (_LDLApp == null)
            {
                MessageBox.Show("Error Was Happen ,Object Is Empty (clsLDLApplication) ==> Form Will Close", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            ucLDLApplicationDetails1.LDLAppID = _LDLApp.LDLApplicationID;
            string ClassName = clsLicenseClass.GetClassName(_LDLApp.LicenseClassID);
            if (ClassName == null) { ucLDLApplicationDetails1.LicenseClass = "Error getting Class Name"; }
            else { ucLDLApplicationDetails1.LicenseClass = ClassName; }
            ucLDLApplicationDetails1.PassedTests = clsLDLApplication.GetPassedTetsNumber(_LDLApplicationID);

            _Application = clsApplication.Find(_LDLApp.ApplicationID);
            if (_Application == null)
            {
                MessageBox.Show("Error Was Happen ,Object Is Empty (clsApplication) ==> Form Will Close", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            ucLDLApplicationDetails1.AppID = _Application.ApplicationID;
            ucLDLApplicationDetails1.AppDate = _Application.ApplicationDate;
            ucLDLApplicationDetails1.AppStatusDate = _Application.LastStatusDate;
            ucLDLApplicationDetails1.AppStatus = _Application.ApplicationStatus == 1 ? "New" : _Application.ApplicationStatus == 2 ? "Cancelled" : "Commpleted";
            ucLDLApplicationDetails1.AppFees = _Application.PaidFees;
            ucLDLApplicationDetails1.AppType = clsApplicationType.Find(1)?.ApplicationTypeTitle;
            ucLDLApplicationDetails1.CreatedByUser = clsUser.GetUserName(_Application.CreatedByUserID);
            ucLDLApplicationDetails1.Applicant = clsPerson.getPersonFullName(_Application.ApplicantPersonID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ShowPersonInfo()
        {

            frmShowPersonDetails frm = new frmShowPersonDetails(_Application.ApplicantPersonID);
            frm.FormClosedEvent += _LoadLDLApplicationData;
            frm.ShowDialog();
        }
        private void frmShowLDLAppDetails_Load(object sender, EventArgs e)
        {
            _LoadLDLApplicationData();
            ucLDLApplicationDetails1.OnShowPersonDetailsClicked += ShowPersonInfo;

        }
    }
}
