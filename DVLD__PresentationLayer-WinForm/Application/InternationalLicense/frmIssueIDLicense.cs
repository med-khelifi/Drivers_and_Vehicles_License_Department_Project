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
    public partial class frmIssueIDLicense : Form
    {
        public delegate void IssueIDLicenseFormClosedEventHandler();
        public IssueIDLicenseFormClosedEventHandler onIssueIDLicenseFormClosed;

        clsApplication _Application;
        clsInternationalLicense _InternationalLicense;
        clsLicense _License =null;
        DateTime _Date;
        float PaidFees;
        int PersonID;
        private void _DisplayInitialppInfo()
        {
            lblAppDate.Text = _Date.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = _Date.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = _Date.AddYears(1).ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblFees.Text = PaidFees.ToString();
            btnSave.Enabled = false;
        }
        public frmIssueIDLicense()
        {
            InitializeComponent();
        }
        private void frmIssueIDLicense_Load(object sender, EventArgs e)
        {
            _Date = DateTime.Now;
            PaidFees = clsApplicationType.GetApplicationTypeFees(6);
            _DisplayInitialppInfo();
            
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You Sure  You Want To Issue The License ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                return;
            }

            _Application = new clsApplication();
            _Application.ApplicantPersonID = PersonID;
            _Application.ApplicationDate = _Date;
            _Application.ApplicationTypeID = 6;
            _Application.ApplicationStatus = 3;
            _Application.LastStatusDate = _Date;    
            _Application.PaidFees = PaidFees;
            _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Application.Save()) 
            {
                _InternationalLicense = new clsInternationalLicense();
                _InternationalLicense.ApplicationID = _Application.ApplicationID;
                _InternationalLicense.DriverID = _License.DriverID;
                _InternationalLicense.IssuedUsingLocalDrivingLicense = _License.LicenseID;
                _InternationalLicense.IssueDate = _Date;
                _InternationalLicense.ExpirationDate = _Date.AddYears(1);
                _InternationalLicense.isActive = true;
                _InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (_InternationalLicense.Save()) 
                { 
                    lblILAppID.Text = _Application.ApplicationID.ToString();
                    lblILicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();     
                    MessageBox.Show($"International License Issued With ID : ({_InternationalLicense.InternationalLicenseID})", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    linkLShowLicenseInfo.Enabled = true;
                    btnSave.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Saving International License Faild", "Saving Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Saving International License Application Faild", "Saving Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void linkLShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory frm = new frmLicensesHistory(PersonID, true);
            frm.ShowDialog();
        }
        private void linkLShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(_InternationalLicense.InternationalLicenseID);
            frm.ShowDialog();
        }
        private void frmIssueIDLicense_FormClosing(object sender, FormClosingEventArgs e)
        {
            onIssueIDLicenseFormClosed?.Invoke();
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
        private void _LoadData()
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
        private void ucLicenseWithFilter1_onSearchLicenseBtnClicked(string id)
        {
            if (id == "") return;
            _License = clsLicense.Find(Convert.ToInt32(id));
            if (_License != null)
            {
                PersonID = clsDriver.GetPersonIDOfDriver(_License.DriverID);
                _LoadData();
                lblLocalLicenseID.Text = _License.LicenseID.ToString();
                linkLShowLicenseHistory.Enabled = true;

                if (_License.LicenseClassID != 3)
                {
                    MessageBox.Show($"License Should Be Class (3),License with ID <{_License.LicenseID}> Is Invalid.", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (clsInternationalLicense.isPersonHasInternationalLicense(PersonID))
                {
                    MessageBox.Show("Person Already has International License.", "License Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!_License.isActive)
                {
                    MessageBox.Show("License is Not Active !", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_License.ExpirationDate < DateTime.Now)
                {
                    MessageBox.Show("License is Expired Please!", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
    
                btnSave.Enabled = true;
            }
            else
            {
                MessageBox.Show("License Not Found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
