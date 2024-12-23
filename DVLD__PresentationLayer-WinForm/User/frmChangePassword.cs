using BVLD__BusinessLayer;
using ContactBusinessLayer;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class frmChangePassword : Form
    {
        public delegate void frmEditShowUserDetailsDelegate();
        public frmEditShowUserDetailsDelegate frmClose;
        clsUser User;
        clsPerson UserPerson;
        int UserID;
        bool isMatchPassword = false,isTruePassword = false;
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            this.UserID = userID;
        }
        private void _LoadData()
        {
            User = clsUser.Find(UserID);
            if (User == null)
            {
                MessageBox.Show("User is NULL, Form Will close.", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else
            {
                UserPerson = clsPerson.Find(User.PersonID);
                if (UserPerson == null)
                {
                    MessageBox.Show("UserPerson is NULL, Form Will close.", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                else
                {
                    UserDetails.UserID = User.UserID.ToString();
                    UserDetails.UserName = User.UserName;
                    UserDetails.isActive = (User.isActive) ? "Yes" : "No";
                    UserDetails.PersonID = $"#{UserPerson.PersonID}";
                    UserDetails.FullName = $"{UserPerson.FirstName} {UserPerson.SecondName} {UserPerson.ThirdName} {UserPerson.LastName}";
                    UserDetails.NationalNo = UserPerson.NationalNo;
                    UserDetails.Gender = (UserPerson.Gender == 0 ? "Male" : "Female");
                    UserDetails.Address = UserPerson.Address;
                    UserDetails.Email = UserPerson.Email;
                    UserDetails.DateOfBirth = UserPerson.DateOfBirth;
                    UserDetails.Phone = UserPerson.Phone;
                    UserDetails.ImagePath = UserPerson.ImagePath;

                    clsCountry Country = clsCountry.Find(UserPerson.NationalityCountryID);
                    if (Country != null)
                    {
                        UserDetails.Country = Country.CountryName;
                    }
                    else
                    {
                        UserDetails.Country = "_____";
                    }
                }
            }
        }

        private void _OnEditClicked()
        {
            frmAddEditUser frm = new frmAddEditUser(User.UserID);
            frm.onFormClose += _LoadData;
            frm.ShowDialog();
        }
        private void ucUserDetails1_Load(object sender, EventArgs e)
        {
            _LoadData();
            UserDetails.EditPersonInfoInFrmEditUser += _OnEditClicked;
            txtCurrentPass.Focus();
        }

        private void txtCurrentPass_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (User.Password != txtCurrentPass.Text.Trim())
            {
                errorProvider1.SetError(txtCurrentPass, "Please Enter Current Password correctly.");
                e.Cancel = true;
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNewPassword.Text) && txtNewPassword.Text.Length < 3)
            {
                e.Cancel = true; // Cancels the event if validation fails
                errorProvider1.SetError(txtNewPassword, "This field is required and must contain at least 3 characters.");
                isTruePassword = false;
            }
            else
            {
                isTruePassword = true;
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (!txtNewPassword.Text.Trim().Equals(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true; // Cancels the event if validation fails
                errorProvider1.SetError(txtConfirmPassword, "Passswords Dont Matche.");
                isMatchPassword = false;
            }
            else
            {
                isMatchPassword = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            frmClose?.Invoke();
            Close();
        }

        private void frmChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmClose?.Invoke();
        }
        private bool _AreValidInputs()
        {
            return isMatchPassword && isTruePassword;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (_AreValidInputs())
            {
                User.Password = txtNewPassword.Text;
                if (User.Save())
                {
                    MessageBox.Show("User Saved SuccessFully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Saving...");
                }
            }
            else
            {
                MessageBox.Show("please,Fill All Field.");
            }
        }
    }
}
