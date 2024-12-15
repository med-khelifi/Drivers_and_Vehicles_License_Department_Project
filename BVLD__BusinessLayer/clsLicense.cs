using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__BusinessLayer
{
    public class clsLicense
    {
        enum enMode
        {
            AddNew, Update
        }
        enMode Mode;
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool isActive { get; set; }
        public int IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = -1;
            this.isActive = false;
            this.IssueReason = -1;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }
        private clsLicense(int licenseID, int applicationID, int driverID, int licenseClass,
            DateTime issueDate, DateTime expirationDate, string notes, float paidFees, bool isActive,
            int issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClassID = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            this.isActive = isActive;
            this.IssueReason = issueReason;
            CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }
        public static bool isPersonAlreadyHasLicense(int PersonID, int LicenseClassID)
        {
            return clsLicenseData.isPersonAlreadyHasLicense(PersonID, LicenseClassID);
        }
        public static bool isLDLAlreadyHasLicense(int LocalDrivingLicenseAppID)
        {
            return clsLicenseData.isLDLAlreadyHasLicense(LocalDrivingLicenseAppID);
        }
        private bool _AddNew()
        {
            LicenseID = clsLicenseData.AddNewLicense(ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, isActive, IssueReason, CreatedByUserID);
            return LicenseID != -1;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    return false;
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }
        public static int GetLicenseIDFromLDLApp(int LocalDrivingLicenseID)
        {
            return clsLicenseData.GetLicenseIDFromLDLApp(LocalDrivingLicenseID);
        }
        public static clsLicense Find(int LicenseID)
        {
            int appID = -1, driverID = -1, licenseClass = -1,issueReason = -1,createdByUserID =-1;
            DateTime issuedate = DateTime.MinValue,expirationDate = DateTime.MinValue;
            string notes = "";
            bool isActive = false;  
            float paidfees = -1;
            if( clsLicenseData.GetLicenseInfo(LicenseID, ref appID, ref driverID, ref licenseClass,ref issuedate, ref expirationDate, ref notes, ref paidfees, ref isActive, ref issueReason, ref createdByUserID))
            {
                return new clsLicense(LicenseID, appID, driverID, licenseClass, issuedate,expirationDate, notes, paidfees, isActive, issueReason, createdByUserID);
            }
            return null;
        }
        public static DataTable GetLocalDrivingLicenses(int PersonID)
        {
            return clsLicenseData.GetLocalDrivingLicenses(PersonID);
        }

        public static bool DeactivateLicense(int LicenseID) 
        {
            return clsLicenseData.DeactivateLisense(LicenseID);
        }

        public static bool isLicenseDetained(int LicenseID)
        {
            return clsLicenseData.isLicenseDetained(LicenseID);
        }
    }
}
