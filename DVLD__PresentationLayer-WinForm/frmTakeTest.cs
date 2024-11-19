using BVLD__BusinessLayer;
using Microsoft.VisualBasic;
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
    public partial class frmTakeTest : Form
    {
        public delegate void OnFormClosedEventHandler();
        public OnFormClosedEventHandler OnFormClosedDelegated;


        clsLDLApplication _LDLAppApplication;
        clsTest _TestInfo;
        clsApplication _app;
        int _LDLAppID = 0;
        int _TestType = 0;
        int _AppointmentID = 0;
        float _testFees = 0;
        public frmTakeTest(int AppointmentID,int LDLAppID,int testType)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
            _TestType = testType;
            _AppointmentID = AppointmentID;
        }
        private void _LoadTestLayout()
        {
            pbTestTypePic.Image = (_TestType == 1 ? Properties.Resources.VesionTest : _TestType == 2 ? Properties.Resources.DrivingTest : Properties.Resources.car);
        }
        private void _LoadData()
        {
            _LDLAppApplication = clsLDLApplication.Find(_LDLAppID);
            if (_LDLAppApplication == null)
            {
                MessageBox.Show("LDLApp is NULL ,Form Will Close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            lblAppointmentDate.Text = clsTestAppointment.GetAppointmentDate(_AppointmentID).ToString();

        }
        private void _CheckIfTestIsPassed()
        {
            if (clsTestAppointment.isAppointmentLocked(_AppointmentID))
            { 
                lbltestPassedMessage.Visible = true;
                btnSave.Enabled = false;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                txtNotes.Enabled = false;
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadTestLayout();
            _LoadData();
            _CheckIfTestIsPassed();
            _TestInfo = new clsTest();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestInfo.TestResult =rbPass.Checked;
            _TestInfo.Notes = txtNotes.Text;
            _TestInfo.TestAppointmentID = _AppointmentID;
            _TestInfo.CreatedByUser = clsCurrentUserInfo.CurrentUser.UserID;
            if (MessageBox.Show("Are You Sure ? When You Save You Can't Change It Later", "Save Result", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) 
            {
                if (_TestInfo.Save())
                {
                    if (!clsTestAppointment.LockAppointment(_AppointmentID))
                    {
                        MessageBox.Show("Error Was Happend < Cannot Lock This Appointment ! >", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Was Happend < Cannot Save >", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void frmTakeTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnFormClosedDelegated?.Invoke();
        }
    }
}
