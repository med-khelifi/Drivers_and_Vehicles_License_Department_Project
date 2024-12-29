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
            
            //int PersonID = Convert.ToInt32(dgvAllPeopleData.SelectedRows[0].Cells[0].Value);
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _loadData();
        }
    }
}
