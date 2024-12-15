using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BVLD__BusinessLayer;
namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmShowAllPeople : Form
    {
        DataView FiltredPeople = new DataView();
        DataTable PeopleData;
        public frmShowAllPeople()
        {
            InitializeComponent();
        }
        int SelectedPersonID = -1;

        private void _LoadPersonsData(int x = -1)
        {
            PeopleData = clsPerson.GetAllPeople();
            FiltredPeople = PeopleData.DefaultView;
            dgvAllPeopleData.DataSource = FiltredPeople;
        }
        private void _LoadPersonsData()
        {
            PeopleData = clsPerson.GetAllPeople();
            FiltredPeople = PeopleData.DefaultView;
            dgvAllPeopleData.DataSource = FiltredPeople;
        }
        private void frmShowAllPeople_Load(object sender, EventArgs e)
        {
            _LoadPersonsData();
            lblRecordsCount.Text = "All Records = " + dgvAllPeopleData.Rows.Count;
            CbFilter.SelectedIndex = 0;
        }
        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
            FiltredPeople.RowFilter = _GetFilterString(txtFilterText.Text);
            dgvAllPeopleData.DataSource = FiltredPeople;
        }
      private string _GetFilterString(string FilterValue)
      {
            int SelectedIndex = CbFilter.SelectedIndex;
            if (string.IsNullOrWhiteSpace(FilterValue) || SelectedIndex == 0)
            {
                return string.Empty;
            }
            if (SelectedIndex == 1)
            {
                return dgvAllPeopleData.Columns[SelectedIndex - 1].Name.Trim() + " = " + FilterValue.Trim();
            }
            if(SelectedIndex <= 7)
            {
                return dgvAllPeopleData.Columns[SelectedIndex - 1].Name.Trim() + $" LIKE '{FilterValue.Trim()}%'" ;
            }
            if (SelectedIndex > 7)
            {
                return dgvAllPeopleData.Columns[CbFilter.Text].Name.Trim() + $" LIKE '{FilterValue.Trim()}%'";
            }
            return string.Empty;
      }
        private void dgvAllPeopleData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check if the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Ensure the click is on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the row that was right-clicked
                    SelectedPersonID = Convert.ToInt32(dgvAllPeopleData.Rows[e.RowIndex].Cells[0].Value);
                }
            }
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SelectedPersonID != -1)
            {
                //int PersonID = Convert.ToInt32(dgvAllPeopleData.SelectedRows[0].Cells[0].Value);
                frmShowPersonDetails frm = new frmShowPersonDetails(SelectedPersonID);
                 frm.FormClosedEvent += _LoadPersonsData;
                 frm.ShowDialog();
            }
            else 
            {
                 MessageBox.Show("Please select a person from the list first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmEditAddPerson frm = new frmEditAddPerson(-1);
            frm.OnDataback += _LoadPersonsData;
            frm.ShowDialog();
            lblRecordsCount.Text = "All Records = " + dgvAllPeopleData.Rows.Count;
        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewPerson_Click(sender, e);
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedPersonID != -1)
            {
                //int PersonID = Convert.ToInt32(dgvAllPeopleData.SelectedRows[0].Cells[0].Value);
                frmEditAddPerson frm = new frmEditAddPerson(SelectedPersonID);
                frm.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Please select a person from the list first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsPerson.Delete(SelectedPersonID)) 
            {
                MessageBox.Show("Person Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadPersonsData();
                lblRecordsCount.Text = "All Records = " + dgvAllPeopleData.Rows.Count;
            }
            else
            {
                MessageBox.Show("Person Can't Be Deleted Due Data Related to it", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            int SelectedIndex = CbFilter.SelectedIndex;

            // If the selected index is 1 or 10, allow only numeric input
            if (SelectedIndex == 1 || SelectedIndex == 10)
            {
                if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Block non-numeric and non-control key inputs
                }
            }
            else if (SelectedIndex == 2 )
            {
                if (!char.IsNumber(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Block non-numeric and non-control key inputs
                }
            }
            // If the selected index is 0, block all input
            else if (SelectedIndex == 0)
            {
                e.Handled = true; // Block all input
            }
            // In other cases, allow only letters and punctuation
            else
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true; // Block non-letter, non-punctuation, non-control, and non-space keys
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
