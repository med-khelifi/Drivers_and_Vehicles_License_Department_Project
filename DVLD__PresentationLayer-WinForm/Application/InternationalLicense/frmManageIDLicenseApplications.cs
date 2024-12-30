using BVLD__BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmManageIDLicenseApplications : Form
    {
        DataView dv;
        int PersonID,SelectedDriverID, SelectedLicenseID;
        void _LoadData()
        {
            dv = clsInternationalLicense.GetAllInternationalData().DefaultView;
            dgvIDLApp.DataSource = dv;
            lblRecordsCount.Text = "All Records = " + dgvIDLApp.Rows.Count;
        }
        public frmManageIDLicenseApplications()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

      

        private void frmManageIDLicenseApplications_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void issureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PersonID = clsDriver.GetPersonIDOfDriver(SelectedDriverID);
            //frmShowPersonDetails frm =new frmShowPersonDetails(PersonID);
            //frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PersonID = clsDriver.GetPersonIDOfDriver(SelectedDriverID);
            frmLicensesHistory frm = new frmLicensesHistory(PersonID,true);
            frm.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmIssueIDLicense frm = new frmIssueIDLicense();
            frm.onIssueIDLicenseFormClosed += _LoadData;
            frm.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(SelectedLicenseID);
            frm.ShowDialog();
        }

        private void dgvIDLApp_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check if the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Ensure the click is on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the row that was right-clicked
                    SelectedDriverID = Convert.ToInt32(dgvIDLApp.Rows[e.RowIndex].Cells[2].Value);
                    SelectedLicenseID = Convert.ToInt32(dgvIDLApp.Rows[e.RowIndex].Cells[0].Value);

                }
            }
        }

    }
}
