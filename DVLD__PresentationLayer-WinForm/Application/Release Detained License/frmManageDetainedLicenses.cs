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
    public partial class frmManageDetainedLicenses : Form
    {
        DataView dv;
        int SelectedDetainID;
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }
        void _LoadGridDate()
        {
            //dv = clsDetainedLicense.GetDetainedLicenses().DefaultView;
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
            if (CbFilter.SelectedIndex == 0)
            {
                txtFilterText.Visible = false;
                cbReleasedStatus.Visible = false;
                dv.RowFilter = "";
            }
            else if (CbFilter.SelectedIndex == 2)
            {
                cbReleasedStatus.Visible = true;
                txtFilterText.Visible = false;
                txtFilterText.Text = string.Empty;
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
                {3,$"N.No LIKE '{filter}%'"},
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

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmDetainLicense = new frmDetainLicense();
            frmDetainLicense.onFormCloseDelegate += _LoadGridDate;
            frmDetainLicense.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense(-1);
            frm.onFormCloseDelegate += _LoadGridDate;
            frm.ShowDialog();
        }

        private void CmsManageDLGrid_Opening(object sender, CancelEventArgs e)
        {
            //if (clsDetainedLicense.isDetained(SelectedDetainID))
            //{
            //    CmsManageDLGrid.Items[0].Enabled = true;
            //}
            //else
            //{
            //    CmsManageDLGrid.Items[0].Enabled = false;
            //}
        }

        private void dgvDetainLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check if the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Ensure the click is on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the row that was right-clicked
                    
                    SelectedDetainID = Convert.ToInt32(dgvDetainLicenses.Rows[e.RowIndex].Cells[0].Value);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense(SelectedDetainID);
            frm.onFormCloseDelegate += _LoadGridDate;
            frm.ShowDialog();
        }

        private void CmsManageDLGrid_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            CmsManageDLGrid.Items[0].Enabled = true;
        }
    }
}