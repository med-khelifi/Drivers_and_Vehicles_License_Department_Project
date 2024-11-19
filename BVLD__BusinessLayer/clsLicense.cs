using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__BusinessLayer
{
    public class clsLicense
    {
        enum enMode
        {
            AddNew,Update
        }
        enMode Mode;
        public int LicenseID {  get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass {  get; set; }
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
            LicenseClass = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = -1;
            this.isActive = false;
            this.IssueReason = -1;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }
        private clsLicense(int licenseID, int applicationID, int driverID, int licenseClass ,
            DateTime issueDate, DateTime expirationDate,string notes,float paidFees,bool isActive,
            int issueReason,int createdByUserID) 
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClass = licenseClass;
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
    }
}
