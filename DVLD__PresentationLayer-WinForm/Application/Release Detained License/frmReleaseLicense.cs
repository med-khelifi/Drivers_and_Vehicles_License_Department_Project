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
using static System.Windows.Forms.AxHost;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmReleaseLicense : Form
    {

        public delegate void onFormCloseEventHandler();
        public onFormCloseEventHandler onFormCloseDelegate;

        bool hasChanged = false;
        clsLicense _License;
        clsApplication _Application;
        clsDetainedLicense _DetainedLicenseInfo;
        int PersonID, _DetainID;
        float _AppFees, _DetainFineFees;
        DateTime _Date;
        public frmReleaseLicense(int detainID)
        {
            InitializeComponent();
            _DetainID = detainID;
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
        private void ucLicenseWithFilter1_onSearchLicenseBtnClicked(string id)
        {
            if (id == "") return;
            _License = clsLicense.Find(Convert.ToInt32(id));
            if (_License != null)
            {
                if (!clsLicense.isLicenseDetained(_License.LicenseID))
                {
                    MessageBox.Show("License is Not Detained !", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PersonID = clsDriver.GetPersonIDOfDriver(_License.DriverID);
                _DetainID = clsDetainedLicense.GetDetainID(_License.LicenseID);
                _DetainedLicenseInfo = clsDetainedLicense.Find(_DetainID);

                if (_DetainedLicenseInfo == null)
                {
                    MessageBox.Show("Detain ID retrieving faild ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _LoadLicenseData();


                _DetainFineFees = _DetainedLicenseInfo.FineFees;
                lblFineFees.Text = _DetainFineFees.ToString();


                lblDetainID.Text = _DetainID.ToString();
                lblDetainDate.Text = _DetainedLicenseInfo.DetainDate.ToString("dd/MMM/yyyy");
                lblLicenseID.Text = _License.LicenseID.ToString();

                linkLShowLicenseHistory.Enabled = true;

                btnRelease.Enabled = true;
            }
            else
            {
                MessageBox.Show("License Not Found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory frm = new frmLicensesHistory(PersonID, true);
            frm.ShowDialog();
        }

        private void linkLShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLocalLicenseInfo frm = new frmLocalLicenseInfo(_License.LicenseID);
            frm.ShowDialog();
        }

        private void frmReleaseLicense_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (hasChanged)
                onFormCloseDelegate?.Invoke();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Release This License ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                return;
            }

            _Application = new clsApplication();
            _Application.ApplicantPersonID = PersonID;
            _Application.ApplicationDate = _Date;
            _Application.ApplicationTypeID = 5;
            _Application.ApplicationStatus = 3;
            _Application.LastStatusDate = _Date;
            _Application.PaidFees = _DetainFineFees + _AppFees;
            _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Application.Save())
            {
                _DetainedLicenseInfo.ReleaseDate = _Date;
                _DetainedLicenseInfo.ReleasedByUserID = clsGlobal.CurrentUser.UserID;
                _DetainedLicenseInfo.ReleaseApplicationID = _Application.ApplicationID;
                _DetainedLicenseInfo.IsReleased = true;

                if (_DetainedLicenseInfo.Save())
                {
                    lblRLAppID.Text = _Application.ApplicationID.ToString();
                    MessageBox.Show($"License Released Successfully .", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    linkLShowLicenseInfo.Enabled = true;
                    btnRelease.Enabled = false;
                    hasChanged = true;
                }
                else
                {
                    MessageBox.Show("Saving detained Faild", "Saving Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Saving Release Application Faild", "Saving Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            _Date = DateTime.Now;
            _AppFees = clsApplicationType.GetApplicationTypeFees(5);

            if (_DetainID != -1)
            {
                LoadDetainedPassedID();
                ucLicenseWithFilter1.EnableSearchText = false;
                ucLicenseWithFilter1.SearchText = _License.LicenseID.ToString();

                lblDetainDate.Text = _DetainedLicenseInfo.DetainDate.ToString("dd/MMM/yyyy");
            }

            ShowInitialValue();
        }
        void ShowInitialValue()
        {
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblAppFees.Text = _AppFees.ToString();
            lblFineFees.Text = _DetainFineFees.ToString();
            lblTotalFees.Text = (_AppFees + _DetainFineFees).ToString();
            
        }
        private void LoadDetainedPassedID()
        {
            _DetainedLicenseInfo = clsDetainedLicense.Find(_DetainID);
            if (_DetainedLicenseInfo == null)
            {
                MessageBox.Show("Detain Not Found.===> form will close", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            _License = clsLicense.Find(_DetainedLicenseInfo.LicenseID);
            if (_License != null)
            {
                PersonID = clsDriver.GetPersonIDOfDriver(_License.DriverID);

                _DetainFineFees = _DetainedLicenseInfo.FineFees;
                lblAppFees.Text = _DetainFineFees.ToString();

                _LoadLicenseData();

                lblLicenseID.Text = _License.LicenseID.ToString();
                linkLShowLicenseHistory.Enabled = true;
                lblDetainID.Text = _DetainID.ToString();

                btnRelease.Enabled = true;
            }
            else
            {
                MessageBox.Show("License Not Found.===> form will close", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}