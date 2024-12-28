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
    public partial class frmShowAllUsers : Form
    {
        DataView FiltredUsers = new DataView();
        DataTable PeopleData;
        public frmShowAllUsers()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            PeopleData = clsUser.GetAllUsers();
            FiltredUsers = PeopleData.DefaultView;
            dgvAllUsersData.DataSource = FiltredUsers;

        }

        private void frmShowAllUsers_Load(object sender, EventArgs e)
        {
            _LoadData();
            lblRecordsCount.Text = "All Records = " + dgvAllUsersData.Rows.Count;
            CbFilter.SelectedIndex = 0;
        }

        private string _GetFilterString()
        {
            
                // Handle IsActive filter based on cbActiveState selection
                if (cbActiveState == null || cbActiveState.SelectedIndex == 0) // All
                    return string.Empty;
                else if (cbActiveState.SelectedIndex == 1) // Yes
                    return "IsActive = True";
                else if (cbActiveState.SelectedIndex == 2) // No
                    return "IsActive = False";
                else
                   return string.Empty;
            
        }

        private string _GetFilterString(string FilterValue)
        {
            int SelectedIndex = CbFilter.SelectedIndex;

            if (string.IsNullOrWhiteSpace(FilterValue))
            {
                return string.Empty;
            }

            switch (SelectedIndex)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return $"UserID = {FilterValue}";
                case 2:
                    return $"UserName LIKE '{FilterValue}%'";
                case 3:
                    return $"PersonID = {FilterValue}";
                case 4:
                    return $"FullName LIKE '{FilterValue}%'";
                default:
                    return string.Empty;
            }
        }  
        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterText.Text = "";
            if (CbFilter.SelectedItem.ToString() == "None")
            {
                txtFilterText.Visible = false;
                cbActiveState.Visible = false;


                FiltredUsers.RowFilter = "";
                dgvAllUsersData.DataSource = FiltredUsers;
                lblRecordsCount.Text = "All Records = " + dgvAllUsersData.Rows.Count;
                return;
            }
            

            
            if (CbFilter.SelectedIndex != 5)
            {
                txtFilterText.Visible = true;
                cbActiveState.Visible = false;
            }
            else
            {
                txtFilterText.Visible = false;
                cbActiveState.Visible = true;
                cbActiveState.SelectedIndex = 0;
            }
        }

        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
            FiltredUsers.RowFilter = _GetFilterString(txtFilterText.Text);
            dgvAllUsersData.DataSource = FiltredUsers;
            lblRecordsCount.Text = "All Records = " + dgvAllUsersData.Rows.Count;
        }

        private void cbActiveState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltredUsers.RowFilter = _GetFilterString();
            dgvAllUsersData.DataSource = FiltredUsers;
            lblRecordsCount.Text = "All Records = " + dgvAllUsersData.Rows.Count;
        }


        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewUser_Click(sender, e);
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
            // refresh user list
            frmShowAllUsers_Load(null,null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser((int)dgvAllUsersData.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            // refresh user list
            frmShowAllUsers_Load(null, null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frm = new frmShowUserDetails((int)dgvAllUsersData.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            // refresh user list
            frmShowAllUsers_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Delete This User .", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            if (clsUser.DeleteUser((int)dgvAllUsersData.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("User Deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // refresh user list
                frmShowAllUsers_Load(null, null);
            }
            else
            {
                MessageBox.Show("User Can't Be Deleted Due Data Related to it", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {          
            frmChangePassword frm = new frmChangePassword((int)dgvAllUsersData.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtFilterText_TextChanged_1(object sender, EventArgs e)
        {
            FiltredUsers.RowFilter = _GetFilterString(txtFilterText.Text);
            dgvAllUsersData.DataSource = FiltredUsers;
            lblRecordsCount.Text = "All Records = " + dgvAllUsersData.Rows.Count;
        }

        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(CbFilter.SelectedIndex == 1 || CbFilter.SelectedIndex == 3)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    // If the character is not a digit (0-9) or control key, ignore it
                    e.Handled = true;
                }
            }
        }
    }
}
