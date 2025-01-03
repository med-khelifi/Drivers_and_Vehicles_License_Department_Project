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
using static BVLD__BusinessLayer.clsTestType;

namespace DVLD__PresentationLayer_WinForm.Tests.Controls
{
    public partial class ctrlSecheduledTest : UserControl
    {
        private enTestType _TestTypeID;
        private int _TestID = -1;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestType.enTestType.VisionTest:
                        {
                            mainGroupeBox.Text = "Vision Test";
                            pbTestTypePic.Image = Resources.VesionTest;
                            break;
                        }

                    case clsTestType.enTestType.WrittenTest:
                        {
                            mainGroupeBox.Text = "Written Test";
                            pbTestTypePic.Image = Resources.DrivingTest;
                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            mainGroupeBox.Text = "Street Test";
                            pbTestTypePic.Image = Resources.car;
                            break;


                        }
                }
            }
        }

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointment _TestAppointment;

        public void LoadInfo(int TestAppointmentID)
        {

            _TestAppointmentID = TestAppointmentID;


            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            //incase we did not find any appointment .
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDLClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblName.Text = _LocalDrivingLicenseApplication.PersonFullName;


            //this will show the trials for this test before 
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();



            lblAppointmentDate.Text = clsFormat.DateToShort(_TestAppointment.AppointmentDate);
            lblTestFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();



        }

        public ctrlSecheduledTest()
        {
            InitializeComponent();
        }
    }
}
