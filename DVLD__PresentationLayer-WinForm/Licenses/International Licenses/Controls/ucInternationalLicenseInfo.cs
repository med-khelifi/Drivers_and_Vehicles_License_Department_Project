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
    public partial class ucInternationalLicenseInfo : UserControl
    {
        public string FullName { set { lblFullName.Text = value; } }
        public int InternationalLicenseID { set { lblIntLicenseID.Text = value.ToString(); } }
        public int LocalLicenseID { set { lblLicenseID.Text = value.ToString(); } }
        public string NationalNo { set { lblNationalNo.Text = value; } }
        public string Gender { set { lblGender.Text = value; } }
        public DateTime IssueDate { set { lblIssueDate.Text = value.ToString("dd/MMM/yyyy");} }
        public int ApplicationID { set { lblAppID.Text = value.ToString(); } }
        public string isActive { set { lblisActive.Text = value; } }
        public DateTime DateOfBirth { set { lblDateOfBirth.Text = value.ToString("dd/MMM/yyyy"); } }
        public int DriverID { set { lblDriverID.Text = value.ToString(); } }
        public DateTime ExpirationDate { set { lblExpirationDate.Text = value.ToString("dd/MMM/yyyy"); } }
        public string ImagePath
        {
            set
            {
                if (string.IsNullOrEmpty(value) || !File.Exists(value))
                {
                    pbPersonPicture.Image = (lblGender.Text == "Male" ? Properties.Resources.Person : Properties.Resources.person_girl);
                }
                else
                {
                    pbPersonPicture.Image = _LoadImageWithoutLocking(value);
                }
            }
        }
        private static Image _LoadImageWithoutLocking(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return Image.FromStream(stream); // Return a copy of the image
            }
        }
        public ucInternationalLicenseInfo()
        {
            InitializeComponent();
        }
    }
}
