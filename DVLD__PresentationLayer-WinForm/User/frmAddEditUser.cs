using BVLD__BusinessLayer;
using ContactBusinessLayer;
using Guna.UI2.HtmlRenderer.Adapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmAddEditUser : Form
    {
        public delegate void OnFormClose();
        public OnFormClose onFormClose;
        //public event OnFormClose OnFormCloseDelegate;

        enum enMode { AddNew,Update}
        enMode Mode;
        bool isValidUserName = false;
        bool isMatchPassword = false;
        clsUser User;
        clsPerson UserPerson;
        int UserID;
        public frmAddEditUser(int userID)
        {
            InitializeComponent();
            UserID = userID;
            if (userID == -1) 
            { 
                Mode = enMode.AddNew;
            }
            else
            {
                Mode = enMode.Update;
            }
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void _LoadData()
        {
            
            if (Mode == enMode.AddNew)
            {
                lblCaption.Text = "Add New User";
                User = new clsUser();
                return;
            }

            User = clsUser.Find(UserID);
            if (User == null)
            {
                MessageBox.Show("User Not Found. App Will Close.");
                Close();
                return;
            }
            UserPerson = clsPerson.Find(User.PersonID);
            if (UserPerson == null)
            {
                MessageBox.Show("UserPerson Not Found. App Will Close.");
                Close();
                return;
            }
            clsCountry Country = clsCountry.Find(UserPerson.NationalityCountryID);
            
            isMatchPassword = true;
            isValidUserName = true;
            ucPersondetailsWithFilter1.FilterVisibility = false;
            
            
            lblCaption.Text = "Edit User Info";
            ucPersondetailsWithFilter1.PersonID = UserPerson.PersonId.ToString();
            ucPersondetailsWithFilter1.FullName = $"{UserPerson.FirstName} {UserPerson.SecondName} {UserPerson.ThirdName} {UserPerson.LastName}";
            ucPersondetailsWithFilter1.NationalNo = UserPerson.NationalNo;
            ucPersondetailsWithFilter1.DateOfBirth = UserPerson.DateOfBirth;
            ucPersondetailsWithFilter1.Phone = UserPerson.Phone;
            ucPersondetailsWithFilter1.Gender = UserPerson.Gender == 0 ? "Male" : "Female";
            if (Country != null)
            {
                ucPersondetailsWithFilter1.Country = Country.CountryName;
            }
            else
            {
                ucPersondetailsWithFilter1.Country = "_____";
            }
            ucPersondetailsWithFilter1.Email = UserPerson.Email;
            ucPersondetailsWithFilter1.Address = UserPerson.Address;
            ucPersondetailsWithFilter1.ImagePath = UserPerson.ImagePath;

            lblID.Text = User.UserID.ToString();
            txtUserName.Text = User.UserName;
            txtPassword.Text = User.Password;
            txtConfirmPassword.Text = User.Password;
            chkIsActive.Checked = User.isActive;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tabControlUser.SelectedIndex = 1; // Sets focus to Tab 2
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear(); 
            // Regular expression pattern for letters, numbers, dashes, and underscores
            string pattern = @"^[a-zA-Z0-9-_]+$";
            if (!Regex.IsMatch(txtUserName.Text, pattern))
            {
                e.Cancel = true; // Cancels the event if validation fails
                errorProvider1.SetError(txtUserName, "Only letters, numbers, dashes, and underscores are allowed.");
                isValidUserName = false;

            }
            else
            {
                if (clsUser.isUserNameExist(txtUserName.Text.Trim()) && txtUserName.Text != User.UserName)
                {
                    e.Cancel = true; // Cancels the event if validation fails
                    errorProvider1.SetError(txtUserName, "This Username already used,try another one.");
                    isValidUserName = false;
                }
                else
                {
                    isValidUserName = true;
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtPassword.Text) && txtPassword.Text.Length < 3)
            {
                e.Cancel = true; // Cancels the event if validation fails
                errorProvider1.SetError(txtPassword, "This field is required and must contain at least 3 characters.");
            }
         
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (!txtPassword.Text.Trim().Equals(txtConfirmPassword.Text.Trim()))
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
        private bool _AreValidInputs()
        {
            return isMatchPassword && isValidUserName;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (ucPersondetailsWithFilter1.isEmpty)
            {
                MessageBox.Show("please,Select Person first");
                return;
            }
            if (_AreValidInputs())
            {
                User.Password = txtPassword.Text;
                User.UserName = txtUserName.Text;
                User.isActive = chkIsActive.Checked;
                User.PersonID = Convert.ToInt32(ucPersondetailsWithFilter1.PersonID);

                if (User.Save())
                {
                    MessageBox.Show("User Saved SuccessFully","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    lblID.Text = User.UserID.ToString();
                }
                else
                {
                    MessageBox.Show("Error Saving...");
                }
            }
            else
            {
                MessageBox.Show("please,Fill All User Info");
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            onFormClose?.Invoke();
            Close();
        }

        private void frmAddEditUser_FormClosing(object sender, FormClosingEventArgs e)
        { 
            onFormClose?.Invoke();
        }

       
    }
}
