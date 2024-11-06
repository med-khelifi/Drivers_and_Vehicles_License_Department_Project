using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsLicenseClassData
    {
        public static List<string> GetAllLicenseClasses()
        {
            List<string> list = new List<string>();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select ClassName from LicenseClasses";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["ClassName"].ToString());
                }
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }
            return list;
        }

        public static float GetLicenseClassFees(int LiceseClassID)
        {
            float fees = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select ClassFees from LicenseClasses;";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object ReaderResult = sqlCommand.ExecuteScalar();
                if(float.TryParse(ReaderResult.ToString(),out float Result))
                {
                    fees = Result;
                }
            }
            catch {}
            finally { connection.Close(); }
            return fees;

        }
    } 
}
