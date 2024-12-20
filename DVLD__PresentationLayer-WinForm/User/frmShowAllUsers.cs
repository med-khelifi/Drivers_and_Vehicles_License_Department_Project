﻿using BVLD__BusinessLayer;
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
        int SelectedUserID = -1;

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

        private string _GetFilterString(string FilterValue)
        {
            int SelectedIndex = CbFilter.SelectedIndex;

            if (SelectedIndex == 5)
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
            txtFilterText.Text = string.Empty;
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
        }

        private void cbActiveState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltredUsers.RowFilter = _GetFilterString("tvrtgvfg");
            dgvAllUsersData.DataSource = FiltredUsers;
        }


        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);
            frm.onFormClose += _LoadData;
            frm.ShowDialog();
            lblRecordsCount.Text = "All Records = " + dgvAllUsersData.Rows.Count;
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {

            //int PersonID = Convert.ToInt32(dgvAllPeopleData.SelectedRows[0].Cells[0].Value);
            frmAddEditUser frm = new frmAddEditUser(-1);
            frm.onFormClose += _LoadData;
            frm.ShowDialog();
        }

        private void dgvAllUsersData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check if the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Ensure the click is on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the row that was right-clicked
                    SelectedUserID = Convert.ToInt32(dgvAllUsersData.Rows[e.RowIndex].Cells[0].Value);
                    //MessageBox.Show(SelectedUserID.ToString());
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedUserID != -1)
            {
                //int PersonID = Convert.ToInt32(dgvAllPeopleData.SelectedRows[0].Cells[0].Value);
                frmAddEditUser frm = new frmAddEditUser(SelectedUserID);
                frm.onFormClose += _LoadData;
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a user from the list first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedUserID != -1)
            {
                //int PersonID = Convert.ToInt32(dgvAllPeopleData.SelectedRows[0].Cells[0].Value);
                frmShowUserDetails frm = new frmShowUserDetails(SelectedUserID);
                frm.frmClose += _LoadData;
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a user from the list first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedUserID != -1)
            {
                if (clsUser.DeleteUser(SelectedUserID))
                {
                    MessageBox.Show("User Deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _LoadData();
                    lblRecordsCount.Text = "All Records = " + dgvAllUsersData.Rows.Count;
                }
                else
                {
                    MessageBox.Show("User Can't Be Deleted Due Data Related to it", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SelectedUserID != -1)
            {
                //int PersonID = Convert.ToInt32(dgvAllPeopleData.SelectedRows[0].Cells[0].Value);
                frmChangePassword frm = new frmChangePassword(SelectedUserID);
                frm.frmClose += _LoadData;
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a user from the list first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtFilterText_TextChanged_1(object sender, EventArgs e)
        {
            FiltredUsers.RowFilter = _GetFilterString(txtFilterText.Text);
            dgvAllUsersData.DataSource = FiltredUsers;
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
