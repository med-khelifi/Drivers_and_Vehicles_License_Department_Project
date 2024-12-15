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
    public partial class ucDriverLicenses : UserControl
    {
        int SelectedApplicationID =-1;
        bool isLocal =false;    
        public DataTable InternationalLicenseDate 
            { 
            set
            {
                dgvInternationalLicenses.DataSource = value;
                lblAllInternationalLSRecords.Text = "Al Records = " + value.Rows.Count;
            } 
        }
        public DataTable LocalLicenseDate
        {
            set
            {
                dgvLocalLicenses.DataSource = value;    
                lblAllLocalDrivingRecords.Text = "Al Records = " + value.Rows.Count;
            }
        }
        public ucDriverLicenses()
        {
            InitializeComponent();
        }

        private void dgvLocalLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check if the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Ensure the click is on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the row that was right-clicked
                    SelectedApplicationID = Convert.ToInt32(dgvLocalLicenses.Rows[e.RowIndex].Cells[0].Value);
                }
            }
            isLocal = true;
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLocal)
            {
                frmLocalLicenseInfo frm = new frmLocalLicenseInfo(SelectedApplicationID);
                frm.ShowDialog();
            }
            else
            {
                frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(SelectedApplicationID);
                frm.ShowDialog();
            }
        }

        private void dgvInternationalLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Ensure the click is on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the row that was right-clicked
                    SelectedApplicationID = Convert.ToInt32(dgvInternationalLicenses.Rows[e.RowIndex].Cells[0].Value);
                }
            }
            isLocal = false;
        }
    }
}
