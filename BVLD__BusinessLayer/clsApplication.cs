using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BVLD__BusinessLayer
{
    public class clsApplication
    {
        enum enMode { addNew, update }
        enMode Mode;
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        private clsApplication(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, 
            int applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            Mode = enMode.update;
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
        }
        public clsApplication()
        {
            Mode = enMode.addNew;
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = -1;
            LastStatusDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
        }
        private bool _AddNewApplication()
        {
            //int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,string ApplicationStatus,
            //DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
            ApplicationID = clsApplicationData.AddNewApplication
                (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

            return ApplicationID != -1;
        }
        private bool _Update()
        {
            return clsApplicationData.UpdateApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.addNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.update;
                        return true;
                    }
                    else return false;

                case enMode.update:
                        return _Update();

                default:
                    return false;
                        
            }
        }
    }
}
