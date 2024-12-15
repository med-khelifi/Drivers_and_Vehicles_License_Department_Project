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
    public partial class frmInternationalLicenseInfo : Form
    {
        clsInternationalLicense _InternationalLicense;
        int _InternationalLicenseID = 0;
        public frmInternationalLicenseInfo(int internationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID=internationalLicenseID;
        }
        private void _LoadData()
        {
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);
            if (_InternationalLicense == null)
            {
                MessageBox.Show("Lisense obj Was NULL ,Form Will Closed ?", "Invalid License ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            int PersonID = clsDriver.GetPersonIDOfDriver(_InternationalLicense.DriverID);
            short Gender = clsPerson.getPersonGendor(PersonID);

            ucInternationalLicenseInfo1.InternationalLicenseID = _InternationalLicense.InternationalLicenseID;
            ucInternationalLicenseInfo1.LocalLicenseID = _InternationalLicense.IssuedUsingLocalDrivingLicense;
            ucInternationalLicenseInfo1.FullName = clsPerson.getPersonFullName(PersonID);
            ucInternationalLicenseInfo1.NationalNo = clsPerson.getPersonNationalNo(PersonID);
            ucInternationalLicenseInfo1.Gender = (Gender == 0 ? "Male" : (Gender == -1 ? "NULL" : "Female"));
            ucInternationalLicenseInfo1.IssueDate = _InternationalLicense.IssueDate;
            ucInternationalLicenseInfo1.isActive = (_InternationalLicense.isActive ? "Yes" : "No");
            ucInternationalLicenseInfo1.DateOfBirth = clsPerson.getPersonBirthDate(PersonID);
            ucInternationalLicenseInfo1.ApplicationID = _InternationalLicense.ApplicationID;
            ucInternationalLicenseInfo1.DriverID = _InternationalLicense.DriverID;
            ucInternationalLicenseInfo1.ExpirationDate = _InternationalLicense.ExpirationDate;
            ucInternationalLicenseInfo1.ImagePath = clsPerson.getPersonImagePath(PersonID);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
