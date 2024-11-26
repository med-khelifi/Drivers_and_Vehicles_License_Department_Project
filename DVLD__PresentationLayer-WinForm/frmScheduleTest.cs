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
    public partial class frmScheduleTest : Form
    {
        public delegate void OnFormClosedEventHandler();
        public OnFormClosedEventHandler OnFormClosedAfterScheduleDelegated;
        enum enMode { addNew ,update}
        enMode Mode;

        
        clsLDLApplication _LDLAppApplication;
        clsTestAppointment _testAppointment;
        clsApplication _app;
        clsApplication _RetakeTestApp;
        int _LDLAppID;
        int _TestType;
        int _testAppointmentID = 0;
        bool _RetakeTestAppUsed = false;

        float _testFees = 0,_retakeTestFees = 0;
        public frmScheduleTest(int LDLAppID,int TestType,int testAppointmentID)
        {
            InitializeComponent();
            this._LDLAppID = LDLAppID;
            this._TestType = TestType;
            this._testAppointmentID = testAppointmentID;

            if(testAppointmentID == -1)
                Mode= enMode.addNew;
            else
                Mode= enMode.update;
        }
        private void _LoadTestLayout()
        {
            mainGroupeBox.Text = (_TestType == 1 ? "Vesion" : _TestType == 2 ? "Written" : "Driving") + " test";
            pbTestTypePic.Image = (_TestType == 1 ? Properties.Resources.VesionTest : _TestType == 2 ? Properties.Resources.DrivingTest : Properties.Resources.car);

        }
        private void _LoadData()
        {
            _LDLAppApplication = clsLDLApplication.Find(_LDLAppID);
            if (_LDLAppApplication == null)
            {
                MessageBox.Show("LDLApp is NULL ,Form Will Close.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);  
                this.Close();
                return;
            }
            lblLDLAppID.Text = _LDLAppID.ToString();
            lblDLClass.Text = clsLicenseClass.GetClassName(_LDLAppApplication.LicenseClassID);

            _app = clsApplication.Find(_LDLAppApplication.ApplicationID);
            if (_app == null)
            {
                MessageBox.Show("Application is NULL ,Form Will Close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblName.Text = clsPerson.getPersonFullName(_app.ApplicantPersonID);
            lblTrial.Text = clsTestAppointment.GetTestTrial(_LDLAppID, _TestType).ToString();
            _testFees = clsTestType.GetTestFees(_TestType);
            lblTestFees.Text = _testFees.ToString();

            if(Mode== enMode.addNew) 
            {
                dtpDate.Value = DateTime.Now;
                _testAppointment = new clsTestAppointment();
            }        
            else
            {
                _testAppointment = clsTestAppointment.Find(_testAppointmentID);
                if (_testAppointment == null)
                {
                    MessageBox.Show("testAppointment is NULL ,Form Will Close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                dtpDate.Value = _testAppointment.AppointmentDate;
            }
                
        }
        private void _LoadRetakeTestInfo()
        {
            _RetakeTestAppUsed = clsTest.isTestAlreadyFaild(_LDLAppID, _TestType);
            if (_RetakeTestAppUsed)
            {
                if(Mode == enMode.addNew)
                {
                    _RetakeTestApp = new clsApplication();
                    _RetakeTestApp.ApplicantPersonID = _app.ApplicantPersonID;
                    _RetakeTestApp.ApplicationDate = DateTime.Now;
                    _RetakeTestApp.ApplicationStatus = _app.ApplicationStatus;
                    _RetakeTestApp.ApplicationTypeID = 8;
                    _RetakeTestApp.LastStatusDate = DateTime.Now;
                    _RetakeTestApp.PaidFees = _retakeTestFees;
                    _RetakeTestApp.CreatedByUserID = clsCurrentUserInfo.CurrentUser.UserID;
                }
                if (Mode == enMode.update)
                {
                    lblRetakeTestAppID.Text = _testAppointment.RetakeTestApplicationID.ToString();
                    _RetakeTestApp = clsApplication.Find(_testAppointment.RetakeTestApplicationID);
                }
                _retakeTestFees = clsApplicationType.GetApplicationTypeFees(8);
                lblCaption.Text = "Schedule Retake Test";
                retakeTestGroupBox.Enabled = true;
            }
            else
            {
                _RetakeTestApp = null;
                retakeTestGroupBox.Enabled = false;
            }
            lblRetakeTestAppFees.Text = _retakeTestFees.ToString();
            lblTotalFees.Text = (_retakeTestFees + _testFees).ToString();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _testAppointment.TestTypeID = _TestType;
            _testAppointment.LocalDrivingLicenseApplicationID = _LDLAppID;
            _testAppointment.AppointmentDate = dtpDate.Value;
            _testAppointment.PaidFees = _retakeTestFees + _testFees;
            _testAppointment.CreatedByUserID = clsCurrentUserInfo.CurrentUser.UserID;
            _testAppointment.isLocked = false;
            
            
            if (_RetakeTestAppUsed)
            {
                if (_RetakeTestApp.Save())
                {
                    _testAppointment.RetakeTestApplicationID = _RetakeTestApp.ApplicationID; 
                    lblRetakeTestAppID.Text = _RetakeTestApp.ApplicationID.ToString();
                }
                else
                {
                    MessageBox.Show("Retake Test Appointment saving faild.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                _testAppointment.RetakeTestApplicationID = -1;
            }
     

            if (_testAppointment.Save())
            {
                MessageBox.Show("Test Scheduled Successfully.", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Test Scheduled Faild.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmScheduleTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnFormClosedAfterScheduleDelegated?.Invoke();
        }
        private void _CheckIfTestIsPassed()
        {
            if (clsTestAppointment.isAppointmentLocked(_testAppointmentID))
            {
                lbltestPassedMessage.Visible = true;
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
            }
        }
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
           // dtpDate.MinDate = DateTime.Now;
            _LoadTestLayout();
            _LoadData();
            _LoadRetakeTestInfo();
            _CheckIfTestIsPassed();
        }
    }
}
