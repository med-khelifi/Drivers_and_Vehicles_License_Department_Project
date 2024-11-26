using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsInternationalLicensesData
    {
        public static DataTable GetInternationalDrivingLicenses(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT InternationalLicenses.InternationalLicenseID as [I.License ID], InternationalLicenses.ApplicationID, InternationalLicenses.IssuedUsingLocalLicenseID as [L.License ID], InternationalLicenses.IssueDate, InternationalLicenses.ExpirationDate, InternationalLicenses.IsActive
               
                    FROM     InternationalLicenses INNER JOIN
                    Applications ON InternationalLicenses.ApplicationID = Applications.ApplicationID
				    Where ApplicantPersonID = @PersonID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch { }
            finally { connection.Close(); }
            return dt;
        }
    }
}
