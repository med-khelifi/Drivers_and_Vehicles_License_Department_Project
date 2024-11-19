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
        public int LDLApplicationID {  get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID {  get; set; }    
        private clsLDLApplication(int lDL_ID, int applicationID, int licenseClassID)
        {   
            Mode = enMode.update;
            LDLApplicationID = lDL_ID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
        }
        public clsLDLApplication()
        {
            Mode = enMode.addNew;
            LDLApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
        }
        public static clsLDLApplication Find(int LDLAppID)
        {
            int applicationID = -1,licenseClassID = -1;
            if(clsLDLApplicationData.GetLDLApplicationInfo(LDLAppID,ref applicationID,ref licenseClassID))

            {
                return new clsLDLApplication(LDLAppID, applicationID,licenseClassID);
            }
            else
            {
                return null;
            }
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
            LDLApplicationID = clsLDLApplicationData.AddNewLDLApplication(ApplicationID, LicenseClassID);
            return  LDLApplicationID != -1;
        }
        private bool _Update()
        {
            return clsLDLApplicationData.UpdateLDLApplication(LDLApplicationID,ApplicationID,LicenseClassID);
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
        public static bool DeleteLDLApplication(int ID)
        {
            return clsLDLApplicationData.DeleteApplication(ID);
        }
        public static int GetPassedTetsNumber(int LDLAppID) 
        { 
            return clsLDLApplicationData.GetPassedTestsNumber(LDLAppID);
        }
        public static bool isLDLCancelled(int LDL_ID)
        {
            return clsLDLApplicationData.isLDLCancelled(LDL_ID);
        }
    }
}
