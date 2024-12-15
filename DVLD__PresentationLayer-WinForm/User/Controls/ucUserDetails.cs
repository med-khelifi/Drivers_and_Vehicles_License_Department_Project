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
    public partial class ucUserDetails : UserControl
    {
        public delegate void EditPersonInfoEventHandler();
        public EditPersonInfoEventHandler EditPersonInfoInFrmEditUser;
        public string PersonID { set { PersonDetails.PersonID = value.ToString(); }/* get { return Person1.PersonID; } */}
        public string NationalNo { set { PersonDetails.NationalNo = value; } }
        public string FullName { set { PersonDetails.FullName = value; } }
        public string Gender { set { PersonDetails.Gender = value; } }
        public string Address { set { PersonDetails.Address = value; } }
        public string Email { set { PersonDetails.Email = value; } }
        public string Country { set { PersonDetails.Country = value; } }
        public string Phone { set { PersonDetails.Phone = value; } }
        public DateTime DateOfBirth { set { PersonDetails.DateOfBirth = value; } }
        public string ImagePath { set { PersonDetails.ImagePath = value; } }
        public string UserID { set { lblID.Text = value; } }
        public string UserName { set { lblUserName.Text = value; } }
        public string isActive { set { lblisActive.Text = value; } }
        public ucUserDetails()
        {
            InitializeComponent();
            PersonDetails.EditPersonDetailsEventFired += EditPersonClicked;
        }
        private void EditPersonClicked(object s ,EventArgs e)
        {
            EditPersonInfoInFrmEditUser?.Invoke();
        }
    }
}
