using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__BusinessLayer
{
    public class clsInternationalLicense
    {
        enum enMode { addnew,update}
        enMode Mode;
        public int InternationalLicenseID {  get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalDrivingLicense {  get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool isActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalDrivingLicense = -1;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            isActive = false;
            CreatedByUserID = -1;

            Mode = enMode.addnew;
        }

        private clsInternationalLicense
            (
            int internationalLicenseID,
            int applicationID,
            int driverID,
            int issuedUsingLocalDrivingLicense,
            DateTime issueDate,
            DateTime expirationDate,
            bool isActive,
            int createdByUserID
            )
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            IssuedUsingLocalDrivingLicense = issuedUsingLocalDrivingLicense;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            this.isActive =isActive;
            CreatedByUserID = createdByUserID;

            Mode = enMode.update;
        }
        public static DataTable GetInternationalDrivingLicenses(int PersonID)
        {
            return clsInternationalLicenseData.GetInternationalDrivingLicenses(PersonID);
        }
        public static DataTable GetAllInternationalData()
        {
            return clsInternationalLicenseData.GetAllInternationalData();
        }
        public bool _AddNew()
        {
            InternationalLicenseID = clsInternationalLicenseData.AddNewInternationalDrivingLicense(ApplicationID,DriverID,IssuedUsingLocalDrivingLicense,IssueDate,ExpirationDate,isActive,CreatedByUserID);
            return InternationalLicenseID > 0;
        }
        public bool Save() 
        {
            switch (Mode) 
            {
                case enMode.addnew:
                    if (_AddNew())
                    {
                        Mode = enMode.update;
                        return true;
                    }
                    return false;

                case enMode.update: return false;
                default: return false;
            }
        }
        public static bool isPersonHasInternationalLicense(int PersonID)
        {
            return clsInternationalLicenseData.isPersonHasInternationalLicense(PersonID);
        }
        public static clsInternationalLicense Find(int LicenseID)
        {
            int appID = -1, driverID = -1, issuedUsingLicenseID = -1, createdByUserID = -1;
            DateTime issuedate = DateTime.MinValue, expirationDate = DateTime.MinValue;
            bool isActive = false;

            if (clsInternationalLicenseData.GetLicenseInfo(LicenseID, ref appID, ref driverID, ref issuedUsingLicenseID, ref issuedate, ref expirationDate, ref isActive,ref createdByUserID))
            {
                return new clsInternationalLicense(LicenseID, appID, driverID, issuedUsingLicenseID, issuedate, expirationDate, isActive, createdByUserID);
            }
            return null;
        }
    }
}