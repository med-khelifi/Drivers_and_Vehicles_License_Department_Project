using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsApplicationData
    {
        public static int AddNewApplication(int applicantPersonID, DateTime applicationDate, int applicationTypeID,
                                    int applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            int addedID = -1;
            string query = @"INSERT INTO Applications
                     (ApplicantPersonID,
                      ApplicationDate,
                      ApplicationTypeID,
                      ApplicationStatus,
                      LastStatusDate,
                      PaidFees,
                      CreatedByUserID)
                     VALUES
                     (@ApplicantPersonID,
                      @ApplicationDate,
                      @ApplicationTypeID,
                      @ApplicationStatus,
                      @LastStatusDate,
                      @PaidFees,
                      @CreatedByUserID);
                     SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters
                command.Parameters.AddWithValue("@ApplicantPersonID", applicantPersonID);
                command.Parameters.AddWithValue("@ApplicationDate", applicationDate);
                command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
                command.Parameters.AddWithValue("@ApplicationStatus", applicationStatus);
                command.Parameters.AddWithValue("@LastStatusDate", lastStatusDate);
                command.Parameters.AddWithValue("@PaidFees", paidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    // Parse the result to get the inserted ID
                    if (result != null && int.TryParse(result.ToString(), out int value))
                    {
                        addedID = value;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in AddNewApplication: {ex.Message}");
                    throw; // Optionally re-throw to propagate the error
                }

            }

            return addedID;
        }


        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus,
            DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int effectedRow = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update Applications SET
           ApplicantPersonID = @ApplicantPersonID,
           ApplicationDate   = @ApplicationDate,
           ApplicationTypeID = @ApplicationTypeID,
           ApplicationStatus = @ApplicationStatus,
           LastStatusDate    = @LastStatusDate,
           PaidFees          = @PaidFees,
           CreatedByUserID   = @CreatedByUserID
           Where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                effectedRow = command.ExecuteNonQuery();


            }
            catch { }
            finally { connection.Close(); }
            return effectedRow > 0;
        }


        public static bool GetApplicationInfo(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref int ApplicationStatus,
            ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select * from Applications where ApplicationID = @ID";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@ID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicantPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                    ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                    ApplicationTypeID = Convert.ToInt32(reader["ApplicationTypeID"]);
                    ApplicationStatus = Convert.ToInt32(reader["ApplicationStatus"]);
                    LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                }
            }
            catch {}
            finally
            {
                connection.Close();
            }
            return isFound;
        }
    }
}
  