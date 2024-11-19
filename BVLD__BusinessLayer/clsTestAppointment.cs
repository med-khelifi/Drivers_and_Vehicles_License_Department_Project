using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__BusinessLayer
{
    public class clsTestAppointment
    {
        enum enMode { addNew,Update}
        enMode Mode;
        public int TestAppointmentsID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool isLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        private clsTestAppointment(int testAppointmentID,int testTypeID,int localDrivingLicenseApplicationID,DateTime appointmentDate,float paidFees,int createdByUserID,bool isLocked,int retakeTestApplicationID ) 
        { 
            TestAppointmentsID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            this.isLocked =isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;

            Mode = enMode.Update;
        }
        public clsTestAppointment()
        {
            TestAppointmentsID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
            this.isLocked = false;
            RetakeTestApplicationID = -1;

            Mode = enMode.addNew;
        }

        public static DataTable GetAppointmentInfo(int LDLAppID,int Testtype)
        {
            return clsTestAppointmentData.GetAppointmentInfoAccordingToTestTypeAndLicenseID( LDLAppID, Testtype );
        }
        public static clsTestAppointment Find(int testAppointmentID) 
        {
            int testTypeID = -1,LDLAppID =-1,createdByUserID = -1,retakeTestAppID = -1;
            DateTime appointmentDate = DateTime.Now;
            bool isLocked = false;  
            float paidFees = -1;    
            if(clsTestAppointmentData.GetTestAppointmentInfo(testAppointmentID,ref testTypeID,ref LDLAppID,ref appointmentDate,ref paidFees,ref createdByUserID,ref isLocked,ref retakeTestAppID))
            {
                return new clsTestAppointment(testAppointmentID,testTypeID,LDLAppID,appointmentDate,paidFees,createdByUserID,isLocked,retakeTestAppID);
            }
            return null;
        }

        private bool _AddNew()
        {
            this.TestAppointmentsID = clsTestAppointmentData.AddNewAppointment(TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,isLocked,RetakeTestApplicationID);
            return this.TestAppointmentsID != -1;
        }
        private bool _Update() 
        {
            return clsTestAppointmentData.UpdateAppointment(TestAppointmentsID,TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, isLocked, RetakeTestApplicationID);
        }
        public bool Save()
        {
            switch (Mode) 
            {
                case enMode.addNew:
                    if (_AddNew()) 
                    { 
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _Update();
                default: return false;
            }
        }
        public static bool hasUncompleAppointment(int LDLAppID, int TestType)
        {
            return clsTestAppointmentData.hasUncompleAppointment(LDLAppID, TestType);
        }
        public static int GetTestTrial(int LDLAppID, int TestType)
        {
            return clsTestAppointmentData.GetTestTrials(LDLAppID, TestType);
        }
        public static DateTime GetAppointmentDate(int AppointmentID)
        {
            return clsTestAppointmentData.GetAppointmentDate(AppointmentID);
        }
        public static bool LockAppointment(int AppointmentID)
        {
            return clsTestAppointmentData.LockAppointment(AppointmentID);
        }
        public static bool isAppointmentLocked(int TestAppointmentsID)
        {
            return clsTestAppointmentData.isAppointmentLock(TestAppointmentsID);
        }
    }
}
