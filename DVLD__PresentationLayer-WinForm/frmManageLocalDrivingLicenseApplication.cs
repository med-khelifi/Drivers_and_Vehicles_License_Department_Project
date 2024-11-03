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
        public frmManageLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        private void _LoadData()
        {
            dgvLDLApplication.DataSource = clsLDLApplication.GetLDLApplications();
            lblRecordsCount.Text = "All Records = " + dgvLDLApplication.Rows.Count;
        }
        private void frmManageLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
