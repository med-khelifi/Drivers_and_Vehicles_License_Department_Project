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
    public partial class ucLicenseWithFilter : UserControl
    {
        public delegate void SearchLicenseBtnClickedEventHandler(string id);
        public event SearchLicenseBtnClickedEventHandler onSearchLicenseBtnClicked;

        
        public string LicenseClass { set { ucDriverLicenseInfo1.LicenseClass = value; } }
        public string FullName { set { ucDriverLicenseInfo1.FullName = value; } }
        public int LicenseID { set { ucDriverLicenseInfo1.LicenseID = value; } }
        public string NationalNo { set { ucDriverLicenseInfo1.NationalNo = value; } }
        public string Gender { set { ucDriverLicenseInfo1.Gender = value; } }
        public DateTime IssueDate { set { ucDriverLicenseInfo1.IssueDate = value; } }
        public string IssueReason { set { ucDriverLicenseInfo1.IssueReason = value; } }
        public string Notes { set { ucDriverLicenseInfo1.Notes = value; } }
        public string isActive { set { ucDriverLicenseInfo1.isActive = value; } }
        public DateTime DateOfBirth { set { ucDriverLicenseInfo1.DateOfBirth = value; } }
        public int DriverID { set { ucDriverLicenseInfo1.DriverID  = value; } }
        public DateTime ExpirationDate { set { ucDriverLicenseInfo1.ExpirationDate = value; } }
        public string isDetained { set { ucDriverLicenseInfo1.isDetained = value; } }
        public string ImagePath {set{ucDriverLicenseInfo1.ImagePath =value;}}


        public ucLicenseWithFilter()
        {
            InitializeComponent();
        }

        
        private void btnSearchLicense_Click(object sender, EventArgs e)
        {           
            onSearchLicenseBtnClicked?.Invoke(txtFilterText.Text);           
        }

        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) 
            { 
                e.Handled = true; 
            }
        }
    }
}
