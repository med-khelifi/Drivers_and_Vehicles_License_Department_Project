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
    public partial class frmTestAppointments : Form
    {
        public delegate void OnFormClosedEventHandler();
        public OnFormClosedEventHandler OnFormClosedDelegated;

        int SelectedAppointmentID = -1;

        int _LDLApplicationID = 0;
        int _TestType = 0;

        clsLDLApplication _LDLApp;
        clsApplication _Application;
        public frmTestAppointments(int LDLAppID, int ScheduleTestType)
        {
            InitializeComponent();
            _LDLApplicationID = LDLAppID;
            _TestType = ScheduleTestType;
        }
        private void _LoadDGVAppointments()
        {
            dgvAppointments.DataSource = clsTestAppointment.GetAppointmentInfo(_LDLApplicationID, _TestType);
            lblAllRecords.Text = "All Records = " + dgvAppointments.Rows.Count.ToString();
        }
        private void _LoadTestLayout()
        {
            string caption = (_TestType == 1 ? "Vesion" : _TestType == 2 ? "Written" : "Driving") + " test";
            lblCaption.Text = caption + " Appointments";
            pbTestType.Image = (_TestType == 1 ? Properties.Resources.VesionTest : _TestType == 2 ? Properties.Resources.DrivingTest : Properties.Resources.car);
            this.Text = caption;
        }
        private void _LoadLDLApplicationData()
        {
            _LDLApp = clsLDLApplication.Find(_LDLApplicationID);

            if (_LDLApp == null)
            {
                MessageBox.Show("Error Was Happen ,Object Is Empty (clsLDLApplication) ==> Form Will Close", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            ucLDLApplicationDetails1.LDLAppID = _LDLApp.LDLApplicationID;
            string ClassName = clsLicenseClass.GetClassName(_LDLApp.LicenseClassID);
            if (ClassName == null) { ucLDLApplicationDetails1.LicenseClass = "Error getting Class Name"; }
            else { ucLDLApplicationDetails1.LicenseClass = ClassName; }
            ucLDLApplicationDetails1.PassedTests = clsLDLApplication.GetPassedTetsNumber(_LDLApplicationID);

            _Application = clsApplication.Find(_LDLApp.ApplicationID);

            if (_Application == null)
            {
                MessageBox.Show("Error Was Happen ,Object Is Empty (clsApplication) ==> Form Will Close", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            ucLDLApplicationDetails1.AppID = _Application.ApplicationID;
            ucLDLApplicationDetails1.AppDate = _Application.ApplicationDate;
            ucLDLApplicationDetails1.AppStatusDate = _Application.LastStatusDate;
            ucLDLApplicationDetails1.AppStatus = _Application.ApplicationStatus == 1 ? "New" : _Application.ApplicationStatus == 2 ? "Cancelled" : "Commpleted";
            ucLDLApplicationDetails1.AppFees = _Application.PaidFees;
            ucLDLApplicationDetails1.AppType = clsApplicationType.Find(1)?.ApplicationTypeTitle;
            ucLDLApplicationDetails1.CreatedByUser = clsUser.GetUserName(_Application.CreatedByUserID);
            ucLDLApplicationDetails1.Applicant = clsPerson.getPersonFullName(_Application.ApplicantPersonID);
        }
        private void _FrmTakeTestDelegate()
        {
            ucLDLApplicationDetails1.PassedTests = clsLDLApplication.GetPassedTetsNumber(_LDLApplicationID);
            _LoadDGVAppointments();
        }
        private void frmScheduleTests_Load(object sender, EventArgs e)
        {
            _LoadLDLApplicationData();
            _LoadDGVAppointments();
            _LoadTestLayout();

            ucLDLApplicationDetails1.OnShowPersonDetailsClicked += ShowPersonDetails;
        }
        private void ShowPersonDetails()
        {
            frmShowPersonDetails frm = new frmShowPersonDetails(_Application.ApplicantPersonID);
            frm.FormClosedEvent += _LoadDGVAppointments;
            frm.ShowDialog();
        }
        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            if (clsTest.isTestAlreadyPassed(_LDLApplicationID, _TestType))
            {
                MessageBox.Show("This Applicant Already Passed This Test !", "Test Passed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsTestAppointment.hasUncompleAppointment(_LDLApplicationID, _TestType))
            {
                MessageBox.Show("This Applicant Has Uncomplete Test.\nTake Test First !", "Uncomplete Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm = new frmScheduleTest(_LDLApplicationID, _TestType, -1);
            frm.OnFormClosedAfterScheduleDelegated += _LoadDGVAppointments;
            frm.ShowDialog();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(_LDLApplicationID, _TestType, SelectedAppointmentID);
            frm.OnFormClosedAfterScheduleDelegated += _LoadDGVAppointments;
            frm.ShowDialog();
        }
        private void dgvAppointments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check if the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Ensure the click is on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the row that was right-clicked
                    SelectedAppointmentID = Convert.ToInt32(dgvAppointments.Rows[e.RowIndex].Cells[0].Value);
                }
            }
        }
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest(SelectedAppointmentID,_LDLApplicationID, _TestType);
            frm.OnFormClosedDelegated += _FrmTakeTestDelegate;
            frm.ShowDialog();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmTestAppointments_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnFormClosedDelegated?.Invoke();
        }
    }
}