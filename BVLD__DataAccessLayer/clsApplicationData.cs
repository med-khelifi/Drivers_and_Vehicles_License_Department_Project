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
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus,
    DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int AddedID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
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

            SqlCommand command = new SqlCommand(query, connection);
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
                object result = command.ExecuteScalar();

                if (int.TryParse(result?.ToString(), out int Value))
                {
                    AddedID = Value;
                }
            }
            catch
            {
                // Optionally handle or log the exception
            }
            finally
            {
                connection.Close();
            }
            return AddedID;
        }



        public static bool UpdateApplication(int ApplicationID ,int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus,
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
            return effectedRow >0;
        }
    }
}
