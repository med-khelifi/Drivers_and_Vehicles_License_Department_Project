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
        public int LDL_ID {  get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID {  get; set; }  
        
        public static DataTable GetLDLApplications()
        {
            return clsLDLApplicationData.GetAllLDLApplicationsTable();
        }
    }
}
