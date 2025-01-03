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
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private int _AppointmentID = -1;
        public frmScheduleTest(int LDLAppID, clsTestType.enTestType TestType,int testAppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LDLAppID;
            _TestTypeID = TestType;
            _AppointmentID = testAppointmentID;
        }
       
        
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
           ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID,_AppointmentID);
        }

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
