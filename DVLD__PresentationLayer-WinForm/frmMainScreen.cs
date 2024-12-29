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
        public frmMainScreen(frmLoggingScrren frm)
        {
            InitializeComponent();
            _loginForm = frm;
        }
        frmLoggingScrren _loginForm;
        private void smPeople_Click(object sender, EventArgs e)
        {
            frmShowAllPeople frm = new frmShowAllPeople();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

       

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowAllUsers frm = new frmShowAllUsers();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frm = new frmShowUserDetails(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePassworddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _loginForm.Show();
            Close();           
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

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseReplacement frm = new frmLicenseReplacement();    
            frm.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense(-1);
            frm.ShowDialog();   
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplication frm = new frmManageLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void frmMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(clsGlobal.CurrentUser != null)
            {
                Application.Exit();
            }
        }
    }
}
