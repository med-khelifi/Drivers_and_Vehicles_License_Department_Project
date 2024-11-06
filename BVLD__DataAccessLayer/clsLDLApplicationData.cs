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
        public static bool HasIncompleteApplication(int LDL_ID,int LicenseClassID)
        {
            bool isFound = false;
            string Query = @"SELECT F = 1 FROM Applications INNER JOIN  
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            where ApplicantPersonID = @ApplicantPersonID 
                              and LicenseClassID = @LicenseClassID 
                              and ApplicationStatus = 1;";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", LDL_ID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            //command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
            }
            catch { }
            finally { connection.Close(); } 
            return isFound;

        }
        public static int AddNewLDLApplication(int ApplicationID, int LicenseClassID)
        {
            int AddID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            INSERT INTO LocalDrivingLicenseApplications
            (ApplicationID, LicenseClassID)
            VALUES
            (@ApplicationID, @LicenseClassID);
            SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();
                    object Result = command.ExecuteScalar();

                    if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    {
                        AddID = InsertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Optional: Log the exception for debugging
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return AddID;
        }
        public static bool UpdateLDLApplication(int DVLDApplication,int ApplicationID, int LicenseClassID)
        {
            int effectedRow = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                Update LocalDrivingLicenseApplications set
                ApplicationID = @ApplicationID,
                LicenseClassID = @LicenseClassID
                Where LocalDrivingLicenseApplicationID = @ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", DVLDApplication);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                effectedRow = command.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }
            return effectedRow > 0;
        }
        public static bool CancelLDLApplication(int LDLApplicationID, DateTime CurrentTime) 
        {
            int effectedRow = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Applications
                                SET Applications.ApplicationStatus = 2,
                                Applications.LastStatusDate = @CurrentTime
                            FROM Applications
                            JOIN LocalDrivingLicenseApplications 
                            ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDLApplicationID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CurrentTime", CurrentTime);
            cmd.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            try
            {
                connection.Open();
                effectedRow = cmd.ExecuteNonQuery();
            }
            catch {}
            finally { connection.Close(); }
            return effectedRow > 0;
        }
    
    }
}
