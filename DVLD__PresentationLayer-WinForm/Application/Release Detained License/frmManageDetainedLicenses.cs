using BVLD__BusinessLayer;
using DVLD__PresentationLayer_WinForm.People;
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
    public partial class frmManageDetainedLicenses : Form
    {
        DataView dv;
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }
        void _LoadGridDate()
        {
            dv = clsDetainedLicense.GetAllDetainedLicenses().DefaultView;
            dgvDetainLicenses.DataSource = dv;
            lblRecordsCount.Text = "All Records = " + dv.Count.ToString();
        }
        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _LoadGridDate();
            CbFilter.SelectedIndex = 0;
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dv.RowFilter = "";
            txtFilterText.Text = "";
            lblRecordsCount.Text = "All Records = " + dv.Count.ToString();
            if (CbFilter.SelectedIndex == 0)
            {
                txtFilterText.Visible = false;
                cbReleasedStatus.Visible = false;
                
            }
            else if (CbFilter.SelectedIndex == 2)
            {
                cbReleasedStatus.Visible = true;
                txtFilterText.Visible = false;
                cbReleasedStatus.SelectedIndex = 0;
                
            }
            else
            {
                txtFilterText.Visible = true;
                cbReleasedStatus.Visible = false;
            }
        }
        private string _GetFilterString(string filter)
        {
            Dictionary<int, string> FilterString = new Dictionary<int, string>()
            {
                {0,string.Empty},
                {1,$"DetainID = {filter}"},
                {2,$"isReleased = '{filter}%'"},
                {3,$"NationalNo LIKE '{filter}%'"},
                {4,$"FullName LIKE '{filter}%'"},
                {5,$"ReleaseApplicationID = {filter}"}
            };
            return FilterString[CbFilter.SelectedIndex];
        }
        private string _GetisReleasedFilterString()
        {
            Dictionary<int, string> FilterString = new Dictionary<int, string>()
            {
                {0,string.Empty},
                {1,"IsReleased = True"},
                {2,"IsReleased = False"}
            };
            return FilterString[cbReleasedStatus.SelectedIndex];
        }
        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (CbFilter.SelectedIndex != 2)
                    dv.RowFilter = _GetFilterString(txtFilterText.Text);
            }
            catch { txtFilterText.Text = ""; }
            if (txtFilterText.Text == "") dv.RowFilter = "";
            lblRecordsCount.Text = "All Records = " + dv.Count.ToString();
        }

        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CbFilter.SelectedIndex == 4)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbReleasedStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            dv.RowFilter = _GetisReleasedFilterString();
            lblRecordsCount.Text = "All Records = " + dv.Count.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmDetainLicense = new frmDetainLicense();
            frmDetainLicense.ShowDialog();
            _LoadGridDate();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
            _LoadGridDate();
        }

        private void CmsManageDLGrid_Opening(object sender, CancelEventArgs e)
        {
            Boolean isReleased = (bool)dgvDetainLicenses.CurrentRow.Cells[3].Value; 
            
                ReleaseToolStripMenuItem.Enabled = !isReleased;
            
        }

        

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense((int)dgvDetainLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _LoadGridDate();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog(); 

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalLicenseInfo frm = new frmLocalLicenseInfo((int)dgvDetainLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
           
        }
    }
}