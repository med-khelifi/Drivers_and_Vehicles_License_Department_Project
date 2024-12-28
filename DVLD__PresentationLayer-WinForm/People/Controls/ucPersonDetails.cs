using BVLD__BusinessLayer;
using ContactBusinessLayer;
using DVLD__PresentationLayer_WinForm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class PersonDetailsControl : UserControl
    {
       
        private clsPerson _Person;
        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson Person
        {
            get { return _Person; }
        }
        public PersonDetailsControl()
        {
            InitializeComponent();
        }
        private void _LoadPersonImage()
        {
            string ImagePath = _Person.ImagePath;   
            if(ImagePath == "")
            {
                pbPersonImage.Image = (_Person.Gender == 0 ? Resources.Person :  Resources.person_girl);
                return;
            }
            if (File.Exists(ImagePath))
                pbPersonImage.ImageLocation = ImagePath;
            else
                MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _FillPersonInfo()
        {
            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblFullName.Text = _Person.FullName;
            lblGender.Text = _Person.Gender == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lblAddress.Text = _Person.Address;
            _LoadPersonImage();
        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (Person == null) 
            {
                llEditPersonInfo.Enabled = false;
                ResetPersonInfo();
                MessageBox.Show("No Person with Person ID. = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;            
            }
            _FillPersonInfo();
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "-";
            lblNationalNo.Text = "-";
            lblFullName.Text = "-";
            lblGender.Text = "-";
            lblEmail.Text = "-";
            lblPhone.Text = "-";
            lblDateOfBirth.Text = "-";
            lblCountry.Text = "-";
            lblAddress.Text = "-";
            pbPersonImage.Image = Resources.Person;

        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(PersonID);

            if (Person == null)
            {
                llEditPersonInfo.Enabled = false;
                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;               
            }
            _FillPersonInfo();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            // refresh person information after editing
            LoadPersonInfo(_PersonID);
               
        }
        
    }
}
