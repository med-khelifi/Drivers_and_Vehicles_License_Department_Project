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
    public partial class frmLicenseReplacement : Form
    {
        clsApplication _Application;
        clsLicense _NewLicense;
        clsLicense _License;

        DateTime _Date;
        float _AppLicenseLostFees, _AppLicenseDamagedFees;
        int _PersonID;

        public frmLicenseReplacement()
        {
            InitializeComponent();
        }
        private void _DisplayInitialppInfo()
        {
            lblApplicationDate.Text = _Date.ToString("dd/MMM/yyyy");
            lblCreateByUser.Text = clsGlobal.CurrentUser.UserName;
            lblAppFees.Text = _AppLicenseDamagedFees.ToString();
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
            short Gender = clsPerson.getPersonGendor(_PersonID);

            ucLicenseWithFilter2.LicenseID = _License.LicenseID;
            ucLicenseWithFilter2.LicenseClass = clsLicenseClass.GetClassName(_License.LicenseClassID);
            ucLicenseWithFilter2.FullName = clsPerson.getPersonFullName(_PersonID);
            ucLicenseWithFilter2.NationalNo = clsPerson.getPersonNationalNo(_PersonID);
            ucLicenseWithFilter2.Gender = (Gender == 0 ? "Male" : (Gender == -1 ? "NULL" : "Female"));
            ucLicenseWithFilter2.IssueDate = _License.IssueDate;
            ucLicenseWithFilter2.IssueReason = IssueReasonString(_License.IssueReason);
            ucLicenseWithFilter2.Notes = _License.Notes;
            ucLicenseWithFilter2.isActive = (_License.isActive ? "Yes" : "No");
            ucLicenseWithFilter2.DateOfBirth = clsPerson.getPersonBirthDate(_PersonID);
            ucLicenseWithFilter2.DriverID = _License.DriverID;
            ucLicenseWithFilter2.ExpirationDate = _License.ExpirationDate;
            ucLicenseWithFilter2.isDetained = "....";
            ucLicenseWithFilter2.ImagePath = clsPerson.getPersonImagePath(_PersonID);
        }
        private void frmLicenseReplacement_Load(object sender, EventArgs e)
        {
            btnIssueReplacement.Enabled = false;
            rbForDamage.Checked = true;
            _Date = DateTime.Now;
            _AppLicenseLostFees = clsApplicationType.GetApplicationTypeFees(3);
            _AppLicenseDamagedFees = clsApplicationType.GetApplicationTypeFees(4);
            _DisplayInitialppInfo();
        }
        private void rbForDamage_CheckedChanged(object sender, EventArgs e)
        {
            lblAppFees.Text = (rbForDamage.Checked ? _AppLicenseDamagedFees:_AppLicenseLostFees ).ToString();
        }
        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Replace License ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                return;
            }

            _Application = new clsApplication();
            _Application.ApplicantPersonID = _PersonID;
            _Application.ApplicationDate = _Date;
            _Application.ApplicationTypeID = (rbForDamage.Checked ? 4 : 3); // lblAppFees.Text = (rbForDamage.Checked ? _AppLicenseDamagedFees:_AppLicenseLostFees ).ToString();
            _Application.ApplicationStatus = 3;
            _Application.LastStatusDate = _Date;
            _Application.PaidFees = (rbForDamage.Checked ? _AppLicenseDamagedFees : _AppLicenseLostFees);
            _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Application.Save())
            {
                _NewLicense = new clsLicense();
                _NewLicense.ApplicationID = _Application.ApplicationID;
                _NewLicense.DriverID = _License.DriverID;
                _NewLicense.LicenseClassID = _License.LicenseClassID;
                _NewLicense.IssueDate = _License.IssueDate;
                _NewLicense.ExpirationDate = _License.ExpirationDate;
                _NewLicense.isActive = true;
                _NewLicense.IssueReason = (rbForDamage.Checked ? 3 : 4);
                _NewLicense.Notes = _License.Notes;
                _NewLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                _License.isActive = false;
                if (!clsLicense.DeactivateLicense(_License.LicenseID))
                {
                    MessageBox.Show("Saving old License Faild", "Saving Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_NewLicense.Save())
                {
                    lblLRAppID.Text = _Application.ApplicationID.ToString();
                    lblReplacedLicenseID.Text = _NewLicense.LicenseID.ToString();
                    MessageBox.Show($"New License Issued With ID : ({_NewLicense.LicenseID}).", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    linkLShowLicenseInfo.Enabled = true;
                    btnIssueReplacement.Enabled = false;
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
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void linkLShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory frm = new frmLicensesHistory(_PersonID, true);
            frm.ShowDialog();
        }
        private void linkLShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLocalLicenseInfo frm = new frmLocalLicenseInfo(_NewLicense.LicenseID);
            frm.ShowDialog();
        }
        private void ucLicenseWithFilter2_onSearchLicenseBtnClicked(string id)
        {
            if (id == "") return;
            _License = clsLicense.Find(Convert.ToInt32(id));
            if (_License != null)
            {
                _PersonID = clsDriver.GetPersonIDOfDriver(_License.DriverID);
                _LoadLicenseData();
                lblOldLicenseID.Text = _License.LicenseID.ToString();
                linkLShowLicenseHistory.Enabled = true;


                if (!_License.isActive)
                {
                    MessageBox.Show("License is Not Active ,You Cannot Replace it!", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_License.ExpirationDate < DateTime.Now)
                {
                    MessageBox.Show($"License is Expired !,You cannot Replace it", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                btnIssueReplacement.Enabled = true;
            }
            else
            {
                MessageBox.Show("License Not Found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
