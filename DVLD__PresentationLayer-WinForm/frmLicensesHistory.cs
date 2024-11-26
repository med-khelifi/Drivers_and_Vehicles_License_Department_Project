using BVLD__BusinessLayer;
using ContactBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmLicensesHistory : Form
    {
        int _LDLAppID = -1;
        int _PersonID = -1;
        clsPerson _Person;
        public frmLicensesHistory(int LDLAppID)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
        }

        private void _LoadPersonData(int x = 0)
        {


            _Person = clsPerson.Find(_PersonID);
            if (_Person != null)
            {
                p1.PersonID = $"#{_Person.PersonId}";
                p1.FullName = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
                p1.NationalNo = _Person.NationalNo;
                p1.Gender = (_Person.Gender == 0 ? "Male" : "Female");
                p1.Address = _Person.Address;
                p1.Email = _Person.Email;
                p1.DateOfBirth = _Person.DateOfBirth;
                p1.Phone = _Person.Phone;
                p1.ImagePath = _Person.ImagePath;

                clsCountry Country = clsCountry.Find(_Person.NationalityCountryID);
                if (Country != null)
                {
                    p1.Country = Country.CountryName;
                }
                else
                {
                    p1.Country = "_____";
                }
            }
        }

        private void _LoadLocalDrivingLicensesHistory()
        {
            dgvLocalLicenses.DataSource = clsLicense.GetLocalDrivingLicenses(_PersonID);
            lblAllLocalDrivingRecords.Text = "All Records = " + dgvLocalLicenses.Rows.Count;
        }
        private void _InternationalDrivingLicensesHistory()
        {
            dgvInternationalLicenses.DataSource = clsInternationalLicenses.GetInternationalDrivingLicenses(_PersonID);
            lblAllInternationalLSRecords.Text = "All Records = " + dgvInternationalLicenses.Rows.Count;
        }
        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            _PersonID = clsLDLApplication.GetApplicantPersonID(_LDLAppID);
            if (_PersonID == -1)
            {
                MessageBox.Show("Invalid PersonID (-1) ,Form Will Closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            _LoadPersonData();
            _LoadLocalDrivingLicensesHistory();
            _InternationalDrivingLicensesHistory();
            p1.EditPersonDetailsEventFired += _ShowEditPersonForn;
        }

        void _ShowEditPersonForn(object s, EventArgs x)
        {
            frmEditAddPerson frm = new frmEditAddPerson(_PersonID);
            frm.OnDataback += _LoadPersonData;
            frm.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
