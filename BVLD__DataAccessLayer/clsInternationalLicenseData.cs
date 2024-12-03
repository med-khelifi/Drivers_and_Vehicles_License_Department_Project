using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsInternationalLicenseData
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
        public static DataTable GetAllInternationalData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT InternationalLicenses.InternationalLicenseID, InternationalLicenses.ApplicationID, Drivers.DriverID, InternationalLicenses.IssuedUsingLocalLicenseID, InternationalLicenses.IssueDate, InternationalLicenses.ExpirationDate, 
                            InternationalLicenses.IsActive
                            FROM     InternationalLicenses INNER JOIN
                            Drivers ON InternationalLicenses.DriverID = Drivers.DriverID";
            SqlCommand cmd = new SqlCommand(query, connection);
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
        public static int AddNewInternationalDrivingLicense(
                int ApplicationID,
                int DriverID,
                int IssuedUsingLocalDrivingLicense,
                DateTime IssueDate,
                DateTime ExpirationDate,
                bool isActive,
                int CreatedByUserID)
        {
            int AddID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO InternationalLicenses
                        (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                        VALUES (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalDrivingLicense);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        // Parse the result
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            AddID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception
                        Console.WriteLine($"Error: {ex.Message}");
                        throw; // Optionally re-throw the exception if needed
                    }
                }
            }

            return AddID;
        }

        public static bool isPersonHasInternationalLicense(int PersonID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM     
                            InternationalLicenses INNER JOIN Applications ON InternationalLicenses.ApplicationID = Applications.ApplicationID
                            where ApplicantPersonID = @ID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID",PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                result = reader.HasRows;
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }
            return result;
        }

        public static bool GetLicenseInfo(int internationaliLicenseID, ref int applicationID, ref int driverID, ref int issuedUsingLocalDrivingLicenseID,
            ref DateTime issueDate, ref DateTime expirationDate, ref bool isActive,
            ref int createdByUserID)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT InternationalLicenses.* FROM InternationalLicenses where InternationalLicenses.InternationalLicenseID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", internationaliLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    applicationID = Convert.ToInt32(reader["ApplicationID"]);
                    driverID = Convert.ToInt32(reader["DriverID"]);
                    issuedUsingLocalDrivingLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                    issueDate = Convert.ToDateTime(reader["IssueDate"]);
                    expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    isActive = Convert.ToBoolean(reader["IsActive"]);
                    createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                }

            }
            catch { }
            finally { connection.Close(); }
            return isfound;

        }
    }
}
