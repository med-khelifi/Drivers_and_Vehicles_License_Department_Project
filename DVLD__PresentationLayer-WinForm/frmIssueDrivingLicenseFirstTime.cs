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
    
    public partial class frmIssueDrivingLicenseFirstTime : Form
    {
        public delegate void frmIssueDrivingLicenseFirstTimeClosedEventHandler();
        public frmIssueDrivingLicenseFirstTimeClosedEventHandler OnfrmIssueDrivingLicenseFirstTimeClosedEventHandler;

        clsLicense _NewLicense;
        clsDriver _NewDriver;

        clsApplication _Application;
        clsLDLApplication _LDLApp;
        int _LDLApplicationID = 0;
        bool isLicenseIssued = false;   
        public frmIssueDrivingLicenseFirstTime(int LDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
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
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueDrivingLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _LoadLDLApplicationData();
            ucLDLApplicationDetails1.OnShowPersonDetailsClicked += _ShowPersonInfo;
        }
        private void _ShowPersonInfo()
        {
            frmShowPersonDetails frm = new frmShowPersonDetails (_Application.ApplicantPersonID);
            frm.ShowDialog();
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            int driverID = -1;
            if (clsDriver.isPersonADriver(_Application.ApplicantPersonID))
            {
                driverID = clsDriver.GetDriverIDOfPerson(_Application.ApplicantPersonID);
            }
            else
            {
                _NewDriver = new clsDriver();
                _NewDriver.PersonID = _Application.ApplicantPersonID; 
                _NewDriver.CreatedByUserID = clsCurrentUserInfo.CurrentUser.UserID;
                _NewDriver.CreatedDate = DateTime.Now;
                if (!_NewDriver.Save())
                {
                    MessageBox.Show("Cannot Save Driver Info (AddNew).","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                    return;
                }
                else
                {
                    driverID = _NewDriver.DriverID;
                }
            }

            _NewLicense = new clsLicense();
            _NewLicense.ApplicationID = _Application.ApplicationID;
            _NewLicense.DriverID = driverID;
            _NewLicense.LicenseClassID = _LDLApp.LicenseClassID;
            _NewLicense.IssueDate = DateTime.Now;
            _NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.GetLicenseClassDefaultValidityLength(_LDLApp.LicenseClassID));
            _NewLicense.Notes = txtNotes.Text.Trim();
            _NewLicense.PaidFees = clsLicenseClass.GetLicenseFees(_LDLApp.LicenseClassID);
            _NewLicense.isActive = true;
            _NewLicense.IssueReason = 1;
            _NewLicense.CreatedByUserID = clsCurrentUserInfo.CurrentUser.UserID ;

            if (_NewLicense.Save())
            {
                btnIssue.Enabled = false;
                if (!clsLDLApplication.CompleteLDLApplication(_LDLApp.LDLApplicationID, DateTime.Now)) 
                {
                    MessageBox.Show($"Error Cannot Change LDLApp to completed", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MessageBox.Show($"License Added Successfully,License ID = {_NewLicense.LicenseID}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isLicenseIssued = true;
            }
            else
            {
                MessageBox.Show($"License Saving Faild", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmIssueDrivingLicenseFirstTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isLicenseIssued)
            {
                OnfrmIssueDrivingLicenseFirstTimeClosedEventHandler?.Invoke();
            }
        }
    }
}
