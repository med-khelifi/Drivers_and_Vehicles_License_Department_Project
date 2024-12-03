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
            
        }

        private void manageTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplication frm = new frmManageLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void drivingLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewLDLApplication frm = new frmAddNewLDLApplication();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.ShowDialog();
        }

        private void frmMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void licenseInternaticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueIDLicense frm = new frmIssueIDLicense();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageIDLicenseApplications frm = new frmManageIDLicenseApplications();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalLicense frm = new frmRenewLocalLicense();
            frm.ShowDialog();
        }
    }
}
