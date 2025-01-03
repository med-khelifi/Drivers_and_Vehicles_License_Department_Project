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
    public partial class ucDriverLicenses : UserControl
    {
        private int _DriverID;
        private clsDriver _Driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;

        public ucDriverLicenses()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenseInfo()
        {

            _dtDriverLocalLicensesHistory = clsDriver.GetLicenses(_DriverID);


            dgvLocalLicenses.DataSource = _dtDriverLocalLicensesHistory;
            lblAllLocalDrivingRecords.Text = "All Records = " + dgvLocalLicenses.Rows.Count.ToString();

            if (dgvLocalLicenses.Rows.Count > 0)
            {
                dgvLocalLicenses.Columns[0].HeaderText = "Lic.ID";          
                dgvLocalLicenses.Columns[1].HeaderText = "App.ID";     
                dgvLocalLicenses.Columns[2].HeaderText = "Class Name";
                dgvLocalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicenses.Columns[5].HeaderText = "Is Active";
       
            }
        }

        private void _LoadInternationalLicenseInfo()
        {

            _dtDriverInternationalLicensesHistory = clsDriver.GetInternationalLicenses(_DriverID);


            dgvInternationalLicenses.DataSource = _dtDriverInternationalLicensesHistory;
            lblAllInternationalLSRecords.Text = "All Records = " + dgvInternationalLicenses.Rows.Count.ToString();

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].HeaderText = "Is Active";

            }
        }

        public void LoadInfo(int DriverID)
        {
            
            _Driver = clsDriver.FindByDriverID(_DriverID);
            if (_Driver == null) 
            { 
                MessageBox.Show($"No Driver with id = {DriverID} is Found !","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _DriverID = DriverID;
            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();

        }

        public void LoadInfoByPersonID(int PersonID)
        {

            _Driver = clsDriver.FindByPersonID(PersonID);
            if (_Driver == null)
            {
                MessageBox.Show($"No Person with id = {PersonID} is Linked To Driver !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            _DriverID = _Driver.DriverID;
            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalLicenseInfo frm = new frmLocalLicenseInfo((int)dgvLocalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo((int)dgvLocalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        public void Clear()
        {
            dgvLocalLicenses.Rows.Clear();
            dgvInternationalLicenses.Rows.Clear();
        }
    }
}
