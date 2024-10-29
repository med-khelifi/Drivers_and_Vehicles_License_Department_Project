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

        public delegate void EditPersonDetailsEventHandler(object sender, EventArgs e);
        public event EditPersonDetailsEventHandler EditPersonDetailsEventFired;
        public string PersonID { set { lblID.Text = value.ToString(); } get { return lblID.Text; } }
        public string NationalNo { set { lblNationalNo.Text = value; } }
        public string FullName { set { lblFullName.Text = value; } }
        public string Gender { set { lblGender.Text = value; } get{ return lblGender.Text; } }
        public string Address { set { lblAddress.Text = value; } }
        public string Email { set { lblEmail.Text = value; } }
        public string Country { set { lblCountry.Text = value; } }
        public string Phone { set { lblPhone.Text = value; } }
        public DateTime DateOfBirth { set { lblDateOfBirth.Text = value.ToString("yyy-MM-dd"); } }

        public string ImagePath { set
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
        
        public PersonDetailsControl()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditPersonDetailsEventFired?.Invoke(sender,e);
               
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
