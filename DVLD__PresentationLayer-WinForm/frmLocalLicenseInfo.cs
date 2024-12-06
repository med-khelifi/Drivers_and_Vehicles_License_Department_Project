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
    public partial class frmLocalLicenseInfo : Form
    {
        clsLicense _License;
        int _LicenseID =-1;

        string IssueReasonString(int Reason)
        {
            switch (Reason) 
            {
                case 1: return "First Time";
                case 2: return "Renew";
                case 3: return "Replacement for Damaged";
                case 4: return "Replacement for Lost";
                default: return "";
            } 
        }
        private void _LoadData()
        {
            if(_LicenseID == -1)
            {
                MessageBox.Show("Lisense ID Was Not Valid ,Form Will Closed ?","Invalid License ID",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Close();
                return;
            }

            _License = clsLicense.Find(_LicenseID);
            if (_License == null)
            {
                MessageBox.Show("Lisense obj Was NULL ,Form Will Closed ?", "Invalid License ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            int PersonID = clsDriver.GetPersonIDOfDriver(_License.DriverID);
            short Gender = clsPerson.getPersonGendor(PersonID);
            
            ucDriverLicenseInfo1.LicenseID = _License.LicenseID;
            ucDriverLicenseInfo1.LicenseClass = clsLicenseClass.GetClassName(_License.LicenseClassID);
            ucDriverLicenseInfo1.FullName = clsPerson.getPersonFullName(PersonID);
            ucDriverLicenseInfo1.NationalNo = clsPerson.getPersonNationalNo(PersonID);
            ucDriverLicenseInfo1.Gender = (Gender == 0 ? "Male" : (Gender == -1 ? "NULL" : "Female"));
            ucDriverLicenseInfo1.IssueDate = _License.IssueDate;    
            ucDriverLicenseInfo1.IssueReason = IssueReasonString(_License.IssueReason); 
            ucDriverLicenseInfo1.Notes = _License.Notes;    
            ucDriverLicenseInfo1.isActive = (_License.isActive ? "Yes" :"No");
            ucDriverLicenseInfo1.DateOfBirth = clsPerson.getPersonBirthDate(PersonID);
            ucDriverLicenseInfo1.DriverID = _License.DriverID;
            ucDriverLicenseInfo1.ExpirationDate = _License.ExpirationDate;
            ucDriverLicenseInfo1.isDetained = "....";
            ucDriverLicenseInfo1.ImagePath = clsPerson.getPersonImagePath(PersonID);
        } 
        public frmLocalLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
