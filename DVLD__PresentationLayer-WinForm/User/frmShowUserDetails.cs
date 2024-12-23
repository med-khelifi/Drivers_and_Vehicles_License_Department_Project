using BVLD__BusinessLayer;
using ContactBusinessLayer;
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
    public partial class frmShowUserDetails : Form
    {
        public delegate void frmEditShowUserDetailsDelegate();
        public frmEditShowUserDetailsDelegate frmClose;
        int UserID = -1;
        clsUser User = null;
        clsPerson UserPerson = null;
        public frmShowUserDetails(int userID)
        {
            InitializeComponent();
            UserID = userID;
            UserDetails.EditPersonInfoInFrmEditUser += _OnEditClicked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmClose?.Invoke();
            this.Close();
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
        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void frmShowUserDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmClose?.Invoke();
        }
    }
}
