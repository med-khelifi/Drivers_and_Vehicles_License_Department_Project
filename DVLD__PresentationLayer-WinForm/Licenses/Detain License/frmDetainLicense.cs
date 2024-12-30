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
    public partial class frmDetainLicense : Form
    {
        public delegate void onFormCloseEventHandler();
        public onFormCloseEventHandler onFormCloseDelegate;


        clsDetainedLicense DetainedLicense;
        clsLicense _License;
        DateTime _Date;
        int PersonID;
        bool haschanges = false;    
        public frmDetainLicense()
        {
            InitializeComponent();
        }
        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
                //PersonID = clsDriver.GetPersonIDOfDriver(_License.DriverID);
                _LoadData();
                lblLicenseID.Text = _License.LicenseID.ToString();
                linkLShowLicenseHistory.Enabled = true;
                linkLShowLicenseInfo.Enabled = true;

                //if (clsLicense.isLicenseDetained(_License.LicenseID)) 
                //{
                //    MessageBox.Show("License is Already Detained !.", "License is Detained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                btnDetain.Enabled = true;
                //
            }
            else
            {
                MessageBox.Show("License Not Found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DesplayInitialValue()
        {
            _Date = DateTime.Now;
            lblDetainDate.Text = _Date.ToString("dd/MMM/yyyy");
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName; 
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Detain This License ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                return;
            }

            DetainedLicense = new clsDetainedLicense();
            DetainedLicense.LicenseID = _License.LicenseID;
            DetainedLicense.DetainDate = _Date;
            DetainedLicense.FineFees = Convert.ToInt32(txtFineFees.Text);
            DetainedLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            DetainedLicense.IsReleased = false;

            DetainedLicense.ReleaseDate = DateTime.MinValue;
            DetainedLicense.ReleasedByUserID = -1;
            DetainedLicense.ReleaseApplicationID = -1;

            if (DetainedLicense.Save())
            {
                lblDetainID.Text = DetainedLicense.DetainID.ToString();
                MessageBox.Show($"License Detained.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                btnDetain.Enabled = false;
                haschanges = true;
            }
            else
            {
                MessageBox.Show("Saving Detain License Faild", "Saving Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            DesplayInitialValue();
        }

        private void linkLShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory frm = new frmLicensesHistory(PersonID,true);
            frm.ShowDialog();
        }

        private void linkLShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLocalLicenseInfo frm = new frmLocalLicenseInfo(_License.LicenseID);
            frm.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDetainLicense_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (haschanges)
            {
                onFormCloseDelegate?.Invoke();
            }
        }
    }
}
