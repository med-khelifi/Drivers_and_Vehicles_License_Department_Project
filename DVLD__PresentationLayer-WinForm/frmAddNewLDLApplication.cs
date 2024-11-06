using BVLD__BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmAddNewLDLApplication : Form
    {
        public delegate void frmAddNewLDLApplicationClosedDelegate();
        public frmAddNewLDLApplicationClosedDelegate frmClosedDelegate;

        clsLDLApplication LDLApplication;
        clsApplication Application;
        float ApplicationTypeFees = -1;

        public frmAddNewLDLApplication()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCurrentUser.Text = clsCurrentUserInfo.CurrentUser.UserName;
            ApplicationTypeFees = clsApplicationType.GetApplicationTypeFees(1);
            if (ApplicationTypeFees != -1) 
            {
                lblFees.Text = ApplicationTypeFees.ToString() + '$';
            }
            else
            {
                MessageBox.Show("Error Retriving Application Type Data","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tabControlUser.SelectedIndex = 1; // Sets focus to Tab 2
        }

        private void frmAddNewLDLApplication_Load(object sender, EventArgs e)
        {
            cbLicenseClass.DataSource = clsLicenseClass.GetLicenseClassesList();
            _LoadData();

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (ucPersondetailsWithFilter1.isEmpty)
            {
                MessageBox.Show("Please Select Person to Complete The Process !.", "Select Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int PersonID = Convert.ToInt32(ucPersondetailsWithFilter1.PersonID);
            int LicenseClassID = cbLicenseClass.SelectedIndex + 1;
            if (clsLDLApplication.PersonHasInCompletedApplication(PersonID, LicenseClassID))
            {
                MessageBox.Show("Person Already Have Uncompleted Applicaation !.", "Select Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application = new clsApplication();
            Application.ApplicantPersonID = PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = 1;
            Application.ApplicationStatus = 1;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsLicenseClass.GetLicenseFees(LicenseClassID);
            Application.CreatedByUserID = clsCurrentUserInfo.CurrentUser.UserID;

            if (Application.Save())
            {
                lblID.Text = Application.ApplicationID.ToString();
                LDLApplication = new clsLDLApplication();
                LDLApplication.ApplicationID = Application.ApplicationID;
                LDLApplication.LicenseClassID = LicenseClassID;
                if (LDLApplication.Save())
                {
                    MessageBox.Show("Application Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("LDLApplication Save Faild.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Application Save Faild.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void frmAddNewLDLApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmClosedDelegate?.Invoke();
        }
    }
}

//ApplicantPersonID = applicantPersonID;
//ApplicationDate = applicationDate;
//ApplicationTypeID = applicationTypeID;
//ApplicationStatus = applicationStatus;
//LastStatusDate = lastStatusDate;
//PaidFees = paidFees;
//CreatedByUserID = createdByUserID;