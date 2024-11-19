using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsTestData
    {
        public static int _AddNewTest(int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            int AddedID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                     VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                     SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            // Add parameters
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
            command.Parameters.AddWithValue("@TestResult", testResult);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            // Handle nullable Notes
            if (string.IsNullOrEmpty(notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", notes);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                // Try to parse the result to get the added ID
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    AddedID = id;
                }
            }
            catch (Exception ex)
            {
                // Log exception if needed
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return AddedID;
        }
        public static bool isTestAlreadyPassed(int LDLAppID, int TestType)
        {
            bool Result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select f=1 from TestAppointments 
                            INNER JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            where LocalDrivingLicenseApplicationID = @LDLAppID and TestTypeID = @TestType and Tests.TestResult = 1;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestType", TestType);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Result = reader.HasRows;
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }
            return Result;
        }
        public static bool isTestAlreadyFaild(int LDLAppID, int TestType)
        {
            bool Result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select f=1 from TestAppointments 
                            INNER JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            where LocalDrivingLicenseApplicationID = @LDLAppID and TestTypeID = @TestType and Tests.TestResult = 0;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestType", TestType);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Result = reader.HasRows;
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }
            return Result;
        }

    }
}
