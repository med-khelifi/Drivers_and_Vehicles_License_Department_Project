using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsLDLApplicationData
    {
        public static DataTable GetAllLDLApplicationsTable()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from dbo.LocalDrivingLicenseApplications_View ;";
            SqlCommand cmd = new SqlCommand(query,connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }
            return dt;
        }
    }
}
