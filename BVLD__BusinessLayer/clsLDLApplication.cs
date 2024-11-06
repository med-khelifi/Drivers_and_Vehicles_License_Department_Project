using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__BusinessLayer
{
    public class clsLDLApplication
    {
        enum enMode { addNew,update };
        enMode Mode;
        public int LDL_ID {  get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID {  get; set; }    
        private clsLDLApplication(int lDL_ID, int applicationID, int licenseClassID)
        {   
            Mode = enMode.update;
            LDL_ID = lDL_ID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
        }
        public clsLDLApplication()
        {
            Mode = enMode.addNew;
            LDL_ID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
        }
        public static DataTable GetLDLApplications()
        {
            return clsLDLApplicationData.GetAllLDLApplicationsTable();
        }
        public static bool PersonHasInCompletedApplication(int ApplicantPersonID, int LicenseClassID)
        {
            return clsLDLApplicationData.HasIncompleteApplication(ApplicantPersonID, LicenseClassID);
        }        
        private bool _AddNew()
        {
            LDL_ID = clsLDLApplicationData.AddNewLDLApplication(ApplicationID, LicenseClassID);
            return  LDL_ID != -1;
        }
        private bool _Update()
        {
            return clsLDLApplicationData.UpdateLDLApplication(LDL_ID,ApplicationID,LicenseClassID);
        }
        public bool Save()
        {
            switch (Mode) { 
                case enMode.update:
                    return _Update();
                case enMode.addNew:
                    if (_AddNew()) 
                    { 
                        Mode = enMode.update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    default: return false;
            }
        }     
        public static bool CancelApplication(int LDLApplicationID,DateTime CurrentDate)
        {
            return clsLDLApplicationData.CancelLDLApplication(LDLApplicationID, CurrentDate);
        }
    }
}
