using BVLD__BusinessLayer;
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
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void smPeople_Click(object sender, EventArgs e)
        {
            frmShowAllPeople frm = new frmShowAllPeople();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(clsBusinessAccessSettings.directoryPath))
            {
                Directory.CreateDirectory(clsBusinessAccessSettings.directoryPath); // Create directory if it doesn't exist
            }
        }

       

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowAllUsers frm = new frmShowAllUsers();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frm = new frmShowUserDetails(clsCurrentUserInfo.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePassworddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsCurrentUserInfo.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clsCurrentUserInfo.CurrentUser = null;
            Close();
        }

        private void manageApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }
    }
}
