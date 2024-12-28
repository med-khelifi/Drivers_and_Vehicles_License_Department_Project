using BVLD__BusinessLayer;
using ContactBusinessLayer;
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
    public partial class frmShowUserDetails : Form
    {
        int UserID = -1;
     
        public frmShowUserDetails(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {
            UserDetails.LoadUserInfo(UserID);
        }

    }
}
