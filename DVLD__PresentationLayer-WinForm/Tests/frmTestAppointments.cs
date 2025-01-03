using BVLD__BusinessLayer;
using DVLD__PresentationLayer_WinForm.Properties;
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
        private DataTable _dtLicenseTestAppointments;
        private int _LocalDrivingLicenseApplicationID;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;

        public frmTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;

        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestType.enTestType.VisionTest:
                    {
                        lblCaption.Text = "Vision Test Appointments";
                        this.Text = lblCaption.Text;
                        pbTestType.Image = Resources.VesionTest;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        lblCaption.Text = "Written Test Appointments";
                        this.Text = lblCaption.Text;
                        pbTestType.Image = Resources.DrivingTest;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblCaption.Text = "Street Test Appointments";
                        this.Text = lblCaption.Text;
                        pbTestType.Image = Resources.car;
                        break;
                    }
            }
        }

        
       
        private void frmScheduleTests_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();


            ucLDLApplicationDetails1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            _dtLicenseTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            dgvAppointments.DataSource = _dtLicenseTestAppointments;
            lblAllRecords.Text = "All Records = " + dgvAppointments.Rows.Count.ToString();

            if (dgvAppointments.Rows.Count > 0)
            {
                dgvAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvAppointments.Columns[2].HeaderText = "Paid Fees";  
                dgvAppointments.Columns[3].HeaderText = "Is Locked";
                
            }
        }
        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {

            if (clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID,_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //if person already passed the test s/he cannot retak it.
            if (clsLocalDrivingLicenseApplication.DoesPassTestType(_LocalDrivingLicenseApplicationID,_TestType))
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm2 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();
            frmScheduleTests_Load(null, null);

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;


            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, TestAppointmentID);
            frm.ShowDialog();
            frmScheduleTests_Load(null, null);
        }
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;

            frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestType);
            frm.ShowDialog();
            frmScheduleTests_Load(null, null);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}