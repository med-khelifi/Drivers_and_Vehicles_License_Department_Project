using BVLD__BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmAddNewLDLApplication : Form
    {
        public delegate void frmAddNewLDLApplicationClosedDelegate();
        public frmAddNewLDLApplicationClosedDelegate frmClosedDelegate;

        clsLDLApplication _LDLApplication;
        clsApplication _Application;
        float ApplicationTypeFees = -1;

        public frmAddNewLDLApplication()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCurrentUser.Text = clsGlobal.CurrentUser.UserName;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
       
            if (ucPersondetailsWithFilter1.isEmpty)
            {
                MessageBox.Show("Please Select Person to Complete The Process !.", "Select Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int PersonID = ucPersondetailsWithFilter1.PersonInfo.PersonId;
            int LicenseClassID = cbLicenseClass.SelectedIndex + 1;

            if (clsLicense.isPersonAlreadyHasLicense(PersonID, LicenseClassID))
            {
                MessageBox.Show("This Person Already Has This License !.", "License Owned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (clsLDLApplication.PersonHasInCompletedApplication(PersonID, LicenseClassID))
            {
                MessageBox.Show("Person Already Have Uncompleted Applicaation !.", "Select Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Application = new clsApplication();
            _Application.ApplicantPersonID = PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = 1;
            _Application.ApplicationStatus = 1;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = clsLicenseClass.GetLicenseFees(LicenseClassID);
            _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Application.Save())
            {
                lblID.Text = _Application.ApplicationID.ToString();
                _LDLApplication = new clsLDLApplication();
                _LDLApplication.ApplicationID = _Application.ApplicationID;
                _LDLApplication.LicenseClassID = LicenseClassID;
                if (_LDLApplication.Save())
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