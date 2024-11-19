using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__BusinessLayer
{
    public class clsDriver
    {

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver() { }
        public static DataTable GetAllDriversTable()
        {
            return clsDriverData.GetAllDriversTable();
        }
        private bool _AddNewDriver()
        {
            DriverID = clsDriverData.AddNewDriver(PersonID, CreatedByUserID,CreatedDate);
            return DriverID != -1;
        }
        public bool Save()
        {
            return _AddNewDriver();
        }
    }


}
