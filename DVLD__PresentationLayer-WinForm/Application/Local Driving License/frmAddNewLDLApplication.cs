using BVLD__BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmAddNewLDLApplication : Form
    {
        public delegate void frmAddNewLDLApplicationClosedDelegate();
        public frmAddNewLDLApplicationClosedDelegate frmClosedDelegate;
        enum enMode { addNew,update}
        enMode Mode;
        clsLDLApplication _LDLApplication;
        clsApplication _Application;
        float ApplicationTypeFees = -1;
        int _LDLappID = -1;
        public frmAddNewLDLApplication()
        {
            InitializeComponent();
            Mode = enMode.addNew;  
        }

        public frmAddNewLDLApplication(int LDLAppID)
        {
            InitializeComponent();
            Mode = enMode.update;
            _LDLappID = LDLAppID;
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
            
            if(Mode == enMode.addNew)
            {
                _LDLApplication = new clsLDLApplication();
                _Application = new clsApplication();
                _LoadData();
            }
            else
            {
                _LDLApplication = clsLDLApplication.Find(_LDLappID);
                _Application = clsApplication.Find(_LDLApplication.ApplicationID);
                ucPersondetailsWithFilter1.LoadPersonInfo(_Application.ApplicantPersonID);
                lblID.Text  = _LDLappID.ToString();
                lblApplicationDate.Text=_Application.ApplicationDate.ToShortDateString();
                lblCurrentUser.Text = clsUser.GetUserName(_Application.CreatedByUserID);
                cbLicenseClass.SelectedIndex = _LDLApplication.LicenseClassID -1;
                lblFees.Text = _Application.PaidFees.ToString();    
                lblCaption.Text = "Update Local Driving Application";
            }
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
            int LicenseClassID = cbLicenseClass.SelectedIndex + 1; // better to retrive id from data base

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

            
            if(Mode == enMode.addNew)
            {
                _Application.ApplicantPersonID = PersonID;
                _Application.ApplicationDate = DateTime.Now;
                _Application.ApplicationTypeID = 1;
                _Application.ApplicationStatus = 1;
                _Application.LastStatusDate = DateTime.Now;
                _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _Application.PaidFees = clsLicenseClass.GetLicenseFees(LicenseClassID);
            }

            

            if (_Application.Save())
            {
                if(Mode == enMode.addNew)
                {
                    lblID.Text = _Application.ApplicationID.ToString();
                    _LDLApplication = new clsLDLApplication();
                    _LDLApplication.ApplicationID = _Application.ApplicationID;
                }
                _LDLApplication.LicenseClassID = LicenseClassID;
                if (_LDLApplication.Save())
                {
                    MessageBox.Show("Application Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mode = enMode.update;
                    lblCaption.Text = "Update Local Driving Application";
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

        private void frmAddNewLDLApplication_Activated(object sender, EventArgs e)
        {
            ucPersondetailsWithFilter1.SetFocus();
        }
    }
}
