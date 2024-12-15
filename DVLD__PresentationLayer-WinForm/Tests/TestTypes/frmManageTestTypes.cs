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
    public partial class frmManageTestTypes : Form
    {
        int SelectedTestID = -1;
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTable();           
        }
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();    
            lblRecordsCount.Text = "All Records " + dgvTestTypes.Rows.Count;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvTestTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check if the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Ensure the click is on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the row that was right-clicked
                    SelectedTestID = Convert.ToInt32(dgvTestTypes.Rows[e.RowIndex].Cells[0].Value);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm =new frmEditTestType(SelectedTestID);
            frm.OnFormCloseDelegate += _LoadData;
            frm.ShowDialog();
        }
    }
}
