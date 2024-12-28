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
    public partial class ucUserDetails : UserControl
    {
        clsUser _User;
        private int _UserID = -1;
        public int UserID { get { return _UserID; } }
        public ucUserDetails()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);
            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        private void _FillUserInfo()
        {

            PersonDetails.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();

            if (_User.isActive)
                lblisActive.Text = "Yes";
            else
                lblisActive.Text = "No";

        }

        private void _ResetUserInfo()
        {

            PersonDetails.ResetPersonInfo();
            lblUserID.Text = "-";
            lblUserName.Text = "-";
            lblisActive.Text = "-";
        }
    }
}
