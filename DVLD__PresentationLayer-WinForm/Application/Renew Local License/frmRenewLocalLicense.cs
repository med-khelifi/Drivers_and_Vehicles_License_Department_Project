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
using static System.Windows.Forms.AxHost;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmRenewLocalLicense : Form
    {
        clsApplication _Application;
        clsLicense _NewLicense;
        clsLicense _License;

        DateTime _Date;
        float _AppFees,_LicenseFees;
        int PersonID,validityLength;

        public frmRenewLocalLicense()
        {
            InitializeComponent();
        }
        private void _DisplayInitialppInfo()
        {
            lblAppDate.Text = _Date.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = _Date.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = _Date.ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblAppFees.Text = _AppFees.ToString();
            lblTotalFees.Text = (_LicenseFees + _AppFees).ToString();

            btnRenew.Enabled = false;
        }
        private void _LoadLicenseData()
        {
            //short Gender = clsPerson.getPersonGendor(PersonID);

            //ucLicenseWithFilter1.LicenseID = _License.LicenseID;
            //ucLicenseWithFilter1.LicenseClass = clsLicenseClass.GetClassName(_License.LicenseClassID);
            //ucLicenseWithFilter1.FullName = clsPerson.getPersonFullName(PersonID);
            //ucLicenseWithFilter1.NationalNo = clsPerson.getPersonNationalNo(PersonID);
            //ucLicenseWithFilter1.Gender = (Gender == 0 ? "Male" : (Gender == -1 ? "NULL" : "Female"));
            //ucLicenseWithFilter1.IssueDate = _License.IssueDate;
            //ucLicenseWithFilter1.IssueReason = IssueReasonString(_License.IssueReason);
            //ucLicenseWithFilter1.Notes = _License.Notes;
            //ucLicenseWithFilter1.isActive = (_License.isActive ? "Yes" : "No");
            //ucLicenseWithFilter1.DateOfBirth = clsPerson.getPersonBirthDate(PersonID);
            //ucLicenseWithFilter1.DriverID = _License.DriverID;
            //ucLicenseWithFilter1.ExpirationDate = _License.ExpirationDate;
            //ucLicenseWithFilter1.isDetained = clsLicense.isLicenseDetained(_License.LicenseID) ? "Yes" : "No";
            //ucLicenseWithFilter1.ImagePath = clsPerson.getPersonImagePath(PersonID);
        }
        string IssueReasonString(int Reason)
        {
            switch (Reason)
            {
                case 1: return "First Time";
                case 2: return "Renew";
                case 3: return "Replacement for Damaged";
                case 4: return "Replacement for Lost";
                default: return "";
            }
        }
        private void ucLicenseWithFilter1_onSearchLicenseBtnClicked(string id)
        {
            if (id == "") return;
            _License = clsLicense.Find(Convert.ToInt32(id));
            if (_License != null)
            {
                PersonID = clsDriver.GetPersonIDOfDriver(_License.DriverID);
                validityLength = clsLicenseClass.GetLicenseClassDefaultValidityLength(_License.LicenseClassID);
                _LoadLicenseData();
                lblOldLicenseID.Text = _License.LicenseID.ToString();
                _LicenseFees = clsLicenseClass.GetLicenseFees(_License.LicenseClassID);
                lblLicenseFees.Text = _LicenseFees.ToString();  
                lblTotalFees.Text = (_LicenseFees + _AppFees).ToString();
                lblExpirationDate.Text = _Date.AddYears(validityLength).ToString("dd/MMM/yyyy");
                linkLShowLicenseHistory.Enabled = true;

               
                if (!_License.isActive)
                {
                    MessageBox.Show("License is Not Active ,You Cannot Renew it!", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_License.ExpirationDate > DateTime.Now)
                {
                    MessageBox.Show($"License is not Expired Yet!(it will expire in {_License.ExpirationDate.ToString("dd/MMM/yyyy")}),You cannot renew it", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                btnRenew.Enabled = true;
            }
            else
            {
                MessageBox.Show("License Not Found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void linkLShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory frm = new frmLicensesHistory(PersonID, true);
            frm.ShowDialog();
        }
        private void linkLShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLocalLicenseInfo frm = new frmLocalLicenseInfo(_NewLicense.LicenseID);
            frm.ShowDialog();   
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Issue The License ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                return;
            }

            _Application = new clsApplication();
            _Application.ApplicantPersonID = PersonID;
            _Application.ApplicationDate = _Date;
            _Application.ApplicationTypeID = 2;
            _Application.ApplicationStatus = 3;
            _Application.LastStatusDate = _Date;
            _Application.PaidFees = _LicenseFees + _AppFees;
            _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Application.Save())
            {
                _NewLicense = new clsLicense();
                _NewLicense.ApplicationID = _Application.ApplicationID;
                _NewLicense.DriverID = _License.DriverID;
                _NewLicense.LicenseClassID = _License.LicenseClassID;
                _NewLicense.IssueDate = _Date;
                _NewLicense.ExpirationDate = _Date.AddYears(validityLength);
                _NewLicense.isActive = true;
                _NewLicense.IssueReason = 2;
                _NewLicense.Notes = txtNotes.Text.Trim();
                _NewLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                _License.isActive = false;
                if (!clsLicense.DeactivateLicense(_License.LicenseID))
                {
                    MessageBox.Show("Saving old License Faild", "Saving Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_NewLicense.Save())
                {
                    lblRLApplicationID.Text = _Application.ApplicationID.ToString();
                    lblNewLicenseID.Text = _NewLicense.LicenseID.ToString();
                    MessageBox.Show($"New License Issued With ID : ({_NewLicense.LicenseID}).", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    linkLShowLicenseInfo.Enabled = true;
                    btnRenew.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Saving New License Faild", "Saving Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Saving New License Application Faild", "Saving Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmRenewLocalLicense_Load(object sender, EventArgs e)
        {
            _Date = DateTime.Now;
            _AppFees = clsApplicationType.GetApplicationTypeFees(2);
            _DisplayInitialppInfo();
        }
    }
}