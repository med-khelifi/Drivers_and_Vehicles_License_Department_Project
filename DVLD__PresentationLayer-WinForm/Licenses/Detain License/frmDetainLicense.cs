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
        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;
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
        
        
        
        
        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Invalid Inputs !.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Clear errors if all validations pass
                return;
            }

            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            _DetainID = ucLicenseWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text), clsGlobal.CurrentUser.UserID);
            if (_DetainID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetain.Enabled = false;
            ucLicenseWithFilter1.FilterEnabled = false;
            txtFineFees.Enabled = false;
            linkLShowLicenseInfo.Enabled = true;
        }
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }

        private void linkLShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ucLicenseWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void linkLShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLocalLicenseInfo frm = new frmLocalLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ucLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            linkLShowLicenseInfo.Enabled = (_SelectedLicenseID != -1);
            linkLShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)

            {
                return;
            }

            //ToDo: make sure the license is not detained already.
            if (ucLicenseWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtFineFees.Focus();
            btnDetain.Enabled = true;
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            string input = txtFineFees.Text.Trim();

            // Check if the input is empty
            if (string.IsNullOrEmpty(input))
            {
                e.Cancel = true; // Prevent focus change
                errorProvider1.SetError(txtFineFees, "Fees cannot be empty!");
                return;
            }

            // Check if the input is a valid positive number
            if (!float.TryParse(input, out float value) || value <= 0)
            {
                e.Cancel = true; // Prevent focus change
                errorProvider1.SetError(txtFineFees, "Enter a valid positive number.");
                return;
            }

            // Clear errors if valid
            errorProvider1.SetError(txtFineFees, null);
        }
    }
}
