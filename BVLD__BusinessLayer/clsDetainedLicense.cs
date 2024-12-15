using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__BusinessLayer
{
    public class clsDetainedLicense
    {
        enum enMode
        {
            eAddNew,eUpdate
        }

        enMode Mode;
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        public clsDetainedLicense() 
        { 
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.MinValue;
            FineFees = -1;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = DateTime.MinValue;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;

            Mode = enMode.eAddNew;
        }
        private clsDetainedLicense(int detainID, int licenseID, DateTime detainDate, float fineFees, int createdByUserID, bool isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;

            Mode = enMode.eUpdate;
        }
        public static DataTable GetDetainedLicenses()
        {
            return clsDetainedLicenseData.GetDetainedLicenses();
        }       
        private bool _AddNew()
        {
            DetainID = clsDetainedLicenseData.AddNewDetainLicense(LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased,ReleaseDate,ReleasedByUserID, ReleaseApplicationID);
            return DetainID != -1;
        }
        private bool _Update()
        {
            return clsDetainedLicenseData.updateDetainLicense(DetainID,IsReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicationID);
        }
        public bool Save()
        {
            switch (Mode) 
            { 
                case enMode.eAddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.eUpdate;
                        return true;
                    }
                    else return false;

                case enMode.eUpdate:    
                    return _Update();

                default: return false;
            }
        }
        public static clsDetainedLicense Find(int id)
        {
            int licenseID = -1;
            DateTime detainDate = DateTime.MinValue;
            float fineFees = -1;
            int createdByUserID = -1;
            bool isReleased =false;
            DateTime releaseDate = DateTime.MinValue;
            int releasedByUserID = -1;
            int releaseApplicationID = -1;

            if (clsDetainedLicenseData.FindDetainByID(id,ref licenseID, ref detainDate, ref fineFees, ref createdByUserID, ref isReleased,
                ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
            {
                return new clsDetainedLicense(id,licenseID,detainDate,fineFees,createdByUserID,isReleased,releaseDate,releasedByUserID,releaseApplicationID);
            }
            return null;
        }
        static public int GetDetainID(int LicenseID)
        {
            return clsDetainedLicenseData.GetDetainID(LicenseID);
        }
        public static bool isDetained(int DetainID)
        {
            return clsDetainedLicenseData.isDetained(DetainID);
        }
    }
}
