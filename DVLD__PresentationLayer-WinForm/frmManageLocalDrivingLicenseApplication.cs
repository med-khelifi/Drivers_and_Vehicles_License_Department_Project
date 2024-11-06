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
    public partial class frmManageLocalDrivingLicenseApplication : Form
    {
        DataTable DataTable;
        DataView dv;
        int SelectedApplicationID = -1;
        public frmManageLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private string _GetFilterString(string filter)
        {
            Dictionary<int, string> FilterString = new Dictionary<int, string>()
            {
                {0,string.Empty},
                {1,$"LocalDrivingLicenseApplicationID = {filter}"},
                {2,$"NationalNo LIKE '{filter}%'"},
                {3,$"FullName LIKE '{filter}%'"},
                {4,$"Status LIKE '{filter}%'"}
            };
            return FilterString[CbFilter.SelectedIndex];
        }
        private void _LoadData()
        {
            DataTable = clsLDLApplication.GetLDLApplications();
            dv = DataTable.DefaultView;
            lblRecordsCount.Text = "All Records = " + dgvLDLApplication.Rows.Count;
            dgvLDLApplication.DataSource = dv; 
        }
        private void frmManageLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
            CbFilter.SelectedIndex = 0;
        }

        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CbFilter.SelectedIndex == 0) 
            {
                e.Handled = true;
            }
            if (CbFilter.SelectedIndex == 1) 
            { 
                if(!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                {
                    e.Handled |= true;
                }                    
            }
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterText.Text = string.Empty;
        }

        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
            if(txtFilterText.Text == string.Empty)
            {
                dv.RowFilter = "";
            }
            try
            {
                dv.RowFilter = _GetFilterString(txtFilterText.Text);
            }
            catch { txtFilterText.Text = ""; }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmAddNewLDLApplication frm = new frmAddNewLDLApplication();
            frm.frmClosedDelegate = _LoadData;
            frm.ShowDialog();
        }

        private void canToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsLDLApplication.CancelApplication(SelectedApplicationID,DateTime.Now))
            {
                MessageBox.Show("Application Canceled Successfully.", "Application Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadData();
            }
            else
            {
                MessageBox.Show("Error Was Happend.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLDLApplication_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check if the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Ensure the click is on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the row that was right-clicked
                    SelectedApplicationID = Convert.ToInt32(dgvLDLApplication.Rows[e.RowIndex].Cells[0].Value);
                }
            }
        }
    }
}
