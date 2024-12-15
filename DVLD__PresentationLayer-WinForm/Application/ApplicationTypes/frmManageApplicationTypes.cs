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
    public partial class frmManageApplicationTypes : Form
    {
        int SelectedApplicationID = -1;
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void _loadData()
        {
            dgvApplicationTypes.DataSource = clsApplicationType.GetApplicationTypesTable();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _loadData();
            lblRecordsCount.Text = "All Records = " + dgvApplicationTypes.Rows.Count;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedApplicationID != -1)
            {
                //int PersonID = Convert.ToInt32(dgvAllPeopleData.SelectedRows[0].Cells[0].Value);
                frmEditApplicationType frm = new frmEditApplicationType(SelectedApplicationID);
                frm.FormClosedDelegation += _loadData;
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a person from the list first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvApplicationTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check if the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Ensure the click is on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the row that was right-clicked
                    SelectedApplicationID = Convert.ToInt32(dgvApplicationTypes.Rows[e.RowIndex].Cells[0].Value);
                }
            }
        }
    }
}
