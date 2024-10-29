using BVLD__BusinessLayer;
using ContactBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class ucPersondetailsWithFilter : UserControl
    {

        clsPerson PersonInfo;
        bool isValidInput = false;
        public string PersonID { set { Person1.PersonID = value.ToString(); } get { return Person1.PersonID; } }
        public string NationalNo { set { Person1.NationalNo = value; } }
        public string FullName { set { Person1.FullName = value; } }
        public string Gender { set { Person1.Gender = value; } get { return Person1.Gender; } }
        public string Address { set { Person1.Address = value; } }
        public string Email { set { Person1.Email = value; } }
        public string Country { set { Person1.Country = value; } }
        public string Phone { set { Person1.Phone = value; } }
        public DateTime DateOfBirth { set { Person1.DateOfBirth = value; } }
        public string ImagePath { set { Person1.ImagePath = value; } }
        public bool isEmpty { get { return string.IsNullOrEmpty(PersonID) ; } }
        public bool FilterVisibility { set { gbFilter.Enabled = value; } }
        public ucPersondetailsWithFilter()
        {
            InitializeComponent();
            CbFilter.SelectedIndex = 0;
            Person1.EditPersonDetailsEventFired += OnEditPersonLinkLabelClicked;
        }
        private void _Loaddata()
        {
            Person1.PersonID = PersonInfo.PersonId.ToString();
            Person1.FullName = $"{PersonInfo.FirstName} {PersonInfo.SecondName} {PersonInfo.ThirdName} {PersonInfo.LastName}";
            Person1.NationalNo = PersonInfo.NationalNo;
            Person1.Gender = PersonInfo.Gender == 0 ? "Male" : "Female";
            Person1.Phone = PersonInfo.Phone;
            Person1.Address = PersonInfo.Address;
            Person1.Email = PersonInfo.Email;
            Person1.DateOfBirth = PersonInfo.DateOfBirth;
            Person1.ImagePath = PersonInfo.ImagePath;

            clsCountry Country = clsCountry.Find(PersonInfo.NationalityCountryID);
            if (Country != null)
            {
                Person1.Country = Country.CountryName;
            }
            else
            {
                Person1.Country = "_";
            }
        }
        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if (!isValidInput || string.IsNullOrEmpty(txtFilterText.Text.Trim())) return;

            if (CbFilter.SelectedIndex == 0)
            {
                PersonInfo = clsPerson.Find(Convert.ToInt32(txtFilterText.Text.Trim()));
            }
            if (CbFilter.SelectedIndex == 1)
            {
                PersonInfo = clsPerson.Find(txtFilterText.Text.Trim());
            }

            if (PersonInfo != null)
            {
                if (clsUser.isThisPersonUser(PersonInfo.PersonId))
                {
                    MessageBox.Show("This Person is already User.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PersonInfo = null;
                }
                else
                {
                    _Loaddata();
                }
                
            }
            else
            {
                MessageBox.Show("Person Not Found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            txtFilterText.Text = "";
        }
        private void txtFilterText_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            string pattern = "";
            if (CbFilter.SelectedIndex == 0)
            {
                pattern = @"^[0-9 ]+$"; // Allow only numbers
                if (!Regex.IsMatch(txtFilterText.Text, pattern) && !string.IsNullOrEmpty(txtFilterText.Text.Trim()))
                {
                    errorProvider1.SetError(txtFilterText, "Invalid Person ID! Only numbers are allowed.");
                    e.Cancel = true;
                    isValidInput = false;
                }
                else
                {
                    isValidInput = true;
                }
            }
            else
            {
                pattern = @"^[0-9a-zA-Z ]+$";
                if (!Regex.IsMatch(txtFilterText.Text, pattern) && !string.IsNullOrEmpty(txtFilterText.Text.Trim()))
                {
                    errorProvider1.SetError(txtFilterText, "Invalid NationalNo ID! Only numbers and Letters are allowed.");
                    e.Cancel = true;
                    isValidInput = false;
                }
                else
                {
                    isValidInput = true;
                }
            }
        }

        private void _LoadEditedPerson(int PersonID)
        {
            PersonInfo = clsPerson.Find(PersonID);

            if (PersonInfo != null)
            {

                _Loaddata();

            }
        }
      
        private void OnEditPersonLinkLabelClicked(object sender, EventArgs e)
        {
            //EditPersonInfoInFrmEditUser?.Invoke();
            if (!int.TryParse(PersonID, out int ID)) { return; }
            frmEditAddPerson frm = new frmEditAddPerson(Convert.ToInt32(ID));
            frm.OnDataback += _LoadEditedPerson;
            frm.ShowDialog();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmEditAddPerson frm = new frmEditAddPerson(-1);
            frm.OnDataback += _LoadEditedPerson;
            frm.ShowDialog();
        }

        private void ucPersondetailsWithFilter_Load(object sender, EventArgs e)
        {
          
        }
    } 
}
