using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__BusinessLayer
{
    public class clsInternationalLicenses
    {
        public static DataTable GetInternationalDrivingLicenses(int PersonID)
        {
            return clsInternationalLicensesData.GetInternationalDrivingLicenses(PersonID);
        }
    }
}
