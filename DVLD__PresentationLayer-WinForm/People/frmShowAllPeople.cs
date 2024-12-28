using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BVLD__BusinessLayer;
using DVLD__PresentationLayer_WinForm.People;
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

        private void _RefreshPeopleList()
        {
            PeopleData = clsPerson.GetAllPeople();
            FiltredPeople = PeopleData.DefaultView;
            dgvAllPeopleData.DataSource = FiltredPeople;
            lblRecordsCount.Text = "All Records = " + dgvAllPeopleData.Rows.Count;
        }
        private void frmShowAllPeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            CbFilter.SelectedIndex = 0;
        }
        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
            FiltredPeople.RowFilter = _GetFilterString(txtFilterText.Text);
            dgvAllPeopleData.DataSource = FiltredPeople;
            lblRecordsCount.Text = "All Records = " + dgvAllPeopleData.Rows.Count;
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
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //int PersonID = Convert.ToInt32(dgvAllPeopleData.SelectedRows[0].Cells[0].Value);
           frmShowPersonCard frm = new frmShowPersonCard((int)dgvAllPeopleData.CurrentRow.Cells[0].Value);
           frm.ShowDialog();

            _RefreshPeopleList();
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewPerson.PerformClick();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvAllPeopleData.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvAllPeopleData.CurrentRow.Cells[0].Value;
            string PersonImage = clsPerson.Find(PersonID).ImagePath;
            if (MessageBox.Show("Are You Sure You Want To Delete Person [" + PersonID + "]",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPerson.DeletePerson(PersonID))
                {
                    //We have to delete person image as well if it's exist
                    if (PersonImage != null)
                    {
                        File.Delete(PersonImage);
                    }
                    MessageBox.Show("Person Deleted Successfully", "Successful", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Person Was Not Deleted Because It Has Data Linked To It",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterText.Focus();
            txtFilterText.Visible = !(CbFilter.SelectedItem.ToString() == "None"); 
        }
    }
}
