using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class ucDriverLicenseInfo : UserControl
    {
        public string LicenseClass { set { lblClassName.Text = value; } }
        public string FullName { set { lblFullName.Text = value; } }
        public int LicenseID { set { lblLicenseID.Text = value.ToString(); } }
        public string NationalNo { set { lblNationalNo.Text = value; } }
        public string Gender { set { lblGendor.Text = value; } }
        public DateTime IssueDate { set { lblIssueDate.Text = value.ToString("dd/MMM/yyyy"); } }
        public string IssueReason { set { lblIssueReason.Text = value; } }
        public string Notes { set { lblNotes.Text = value; } }
        public string isActive { set { lblisActive.Text = value; } }
        public DateTime DateOfBirth {set{ lblDateOfbirth.Text = value.ToString("dd/MMM/yyyy"); } } 
        public int DriverID { set{ lblDriverID.Text = value.ToString(); } }
        public DateTime ExpirationDate { set{ lblExpirationDate.Text = value.ToString("dd/MMM/yyyy"); } }
        public string isDetained { set{ lblisDetained.Text = value; } }
        public string ImagePath { set
            {
                if (string.IsNullOrEmpty(value) || !File.Exists(value))
                {
                    pbPersonPicture.Image = (lblGendor.Text == "Male" ? Properties.Resources.Person : Properties.Resources.person_girl);
                }
                else
                {
                    pbPersonPicture.Image = _LoadImageWithoutLocking(value);
                }
            }
        }

        public ucDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private static Image _LoadImageWithoutLocking(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return Image.FromStream(stream); // Return a copy of the image
            }
        }
    }
}
