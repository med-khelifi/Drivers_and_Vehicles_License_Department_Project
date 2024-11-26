using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__BusinessLayer
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int MinimumAllowedAge { get; set; }
        public int DefaultValiditylength { get; set; }
        public float LicenseFees { get; set; }


        public static List<string> GetLicenseClassesList()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }
        public static float GetLicenseFees(int ClassID) 
        {
            return clsLicenseClassData.GetLicenseClassFees(ClassID);
        }
        public static string GetClassName(int ClassID) 
        {
            string className = string.Empty;
            if (clsLicenseClassData.GetClassName(ClassID, ref className)) 
            { 
                return className;
            }
            return null;
        }
        public static int GetLicenseClassDefaultValidityLength(int LiceseClassID)
        {
            return clsLicenseClassData.GetLicenseClassDefaultValidityLength(LiceseClassID);
        }
    }
}
