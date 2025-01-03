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
        private int _NewLicenseID = -1;

        public frmRenewLocalLicense()
        {
            InitializeComponent();
        }
        private void _DisplayInitialppInfo()
        {
            //lblAppDate.Text = _Date.ToString("dd/MMM/yyyy");
            //lblIssueDate.Text = _Date.ToString("dd/MMM/yyyy");
            //lblExpirationDate.Text = _Date.ToString("dd/MMM/yyyy");
            //lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            //lblAppFees.Text = _AppFees.ToString();
            //lblTotalFees.Text = (_LicenseFees + _AppFees).ToString();

            btnRenew.Enabled = false;
        }
        
       
        private void linkLShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ucLicenseWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
            //refresh data here
        }
        private void linkLShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLocalLicenseInfo frm = new frmLocalLicenseInfo (_NewLicenseID);
            frm.ShowDialog();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsLicense NewLicense = ucLicenseWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text.Trim(),clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblRLApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblNewLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            ucLicenseWithFilter1.FilterEnabled = false;
            linkLShowLicenseInfo.Enabled = true;
        }
        private void frmRenewLocalLicense_Load(object sender, EventArgs e)
        {
            ucLicenseWithFilter1.txtLicenseIDFocus();


            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblAppDate.Text;

            lblExpirationDate.Text = "-";
            lblAppFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ucLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            linkLShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }

            int DefaultValidityLength = ucLicenseWithFilter1.SelectedLicenseInfo.LicenseClassIfo.DefaultValidityLength;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLength));
            lblLicenseFees.Text = ucLicenseWithFilter1.SelectedLicenseInfo.LicenseClassIfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblAppFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txtNotes.Text = ucLicenseWithFilter1.SelectedLicenseInfo.Notes;


            //check the license is not Expired.
            if (!ucLicenseWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + clsFormat.DateToShort(ucLicenseWithFilter1.SelectedLicenseInfo.ExpirationDate)
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            //check the license is not Active.
            if (!ucLicenseWithFilter1.SelectedLicenseInfo.isActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }



            btnRenew.Enabled = true;
        }
    }
}