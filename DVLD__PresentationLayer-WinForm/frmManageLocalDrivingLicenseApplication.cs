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
                    e.Handled = true;
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

        private void CmsManageLDLGrid_Opening(object sender, CancelEventArgs e)
        {

            if (clsLDLApplication.isLDLCancelled(SelectedApplicationID))
            {
                CmsManageLDLGrid.Items[4].Enabled = false;
                CmsManageLDLGrid.Items[5].Enabled = false;
                CmsManageLDLGrid.Items[6].Enabled = false;
                return;
            }

            int PassedTests = clsLDLApplication.GetPassedTetsNumber(SelectedApplicationID);
            
            if(PassedTests == 3)
            {
                CmsManageLDLGrid.Items[4].Enabled = false;
                if (clsLicense.isLDLAlreadyHasLicense(SelectedApplicationID))
                {
                    CmsManageLDLGrid.Items[5].Enabled = false;
                    CmsManageLDLGrid.Items[6].Enabled = true;
                    
                }
                else
                {
                    CmsManageLDLGrid.Items[5].Enabled = true;
                    CmsManageLDLGrid.Items[6].Enabled = false;
                }
                return;
            }

            ToolStripMenuItem ScheduleTestRow = CmsManageLDLGrid.Items[4] as ToolStripMenuItem;
            
            if (PassedTests == 0)
            {
                ScheduleTestRow.DropDownItems[0].Enabled = true;   // Enable sub-item 0
                ScheduleTestRow.DropDownItems[1].Enabled = false;  // Disable sub-item 1
                ScheduleTestRow.DropDownItems[2].Enabled = false;  // Disable sub-item 2
                CmsManageLDLGrid.Items[5].Enabled = false;
                CmsManageLDLGrid.Items[6].Enabled = false;
            }
            else if (PassedTests == 1)
            {
                ScheduleTestRow.DropDownItems[0].Enabled = false;  // Disable sub-item 0
                ScheduleTestRow.DropDownItems[1].Enabled = true;   // Enable sub-item 1
                ScheduleTestRow.DropDownItems[2].Enabled = false;  // Disable sub-item 2
            }
            else if (PassedTests == 2)
            {
                ScheduleTestRow.DropDownItems[0].Enabled = false;  // Disable sub-item 0
                ScheduleTestRow.DropDownItems[1].Enabled = false;  // Disable sub-item 1
                ScheduleTestRow.DropDownItems[2].Enabled = true;   // Enable sub-item 2
            }
        }


        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("Are You Sure You Want To Delete This Application ?", "Delete Application",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsLDLApplication.DeleteLDLApplication(SelectedApplicationID))
                {
                    MessageBox.Show("Application Deleted Successfully.", "Application Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadData();
                }
                else
                {
                    MessageBox.Show("Error Was Happend,Cannot Delete this Application !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void _ResetCSMItems()
        {
            ToolStripMenuItem ScheduleTestRow = CmsManageLDLGrid.Items[4] as ToolStripMenuItem;
            CmsManageLDLGrid.Items[1].Enabled = true;
            CmsManageLDLGrid.Items[2].Enabled = true;
            CmsManageLDLGrid.Items[3].Enabled = true;
            CmsManageLDLGrid.Items[4].Enabled = true;
            CmsManageLDLGrid.Items[5].Enabled = true;
            CmsManageLDLGrid.Items[6].Enabled = true;
            CmsManageLDLGrid.Items[7].Enabled = true;
            

            ScheduleTestRow.DropDownItems[0].Enabled = true;  
            ScheduleTestRow.DropDownItems[1].Enabled = true;  
            ScheduleTestRow.DropDownItems[2].Enabled = true;   
        }
        private void CmsManageLDLGrid_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _ResetCSMItems();
        }

        private void vesionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments frm = new frmTestAppointments(SelectedApplicationID,1);
            frm.OnFormClosedDelegated += _LoadData;
            frm.ShowDialog();
        }

        private void sechduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments frm = new frmTestAppointments(SelectedApplicationID, 2);
            frm.OnFormClosedDelegated += _LoadData;
            frm.ShowDialog();
        }

        private void sechduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments frm = new frmTestAppointments(SelectedApplicationID, 3);
            frm.OnFormClosedDelegated += _LoadData;
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLDLAppDetails frm = new frmShowLDLAppDetails(SelectedApplicationID);
            frm.ShowDialog();
        }
    }
}
