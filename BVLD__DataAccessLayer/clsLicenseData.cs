using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsLicenseData
    {
        public static int AddNewLicense(int applicationID, int driverID, int licenseClass,
            DateTime issueDate, DateTime expirationDate, string notes, float paidFees, bool isActive,
            int issueReason, int createdByUserID)
        {
            int AddID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Licenses(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                            VALUES (
                            @ApplicationID,@DriverID,@LicenseClass,
                            @IssueDate,@ExpirationDate,@Notes,@PaidFees,
                            @IsActive,@IssueReason,@CreatedByUserID
                            );
                            select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@LicenseClass", licenseClass);

            command.Parameters.AddWithValue("@IssueDate", issueDate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            if(string.IsNullOrEmpty(notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", notes);
            command.Parameters.AddWithValue("@PaidFees", paidFees);

            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@IssueReason", issueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (int.TryParse(Result.ToString(), out int value))
                {
                    AddID = value;
                }
            }
            catch { }
            finally { connection.Close(); }
            return AddID;
        }


        //public static bool GetLicenseInfo(int license ,ref int applicationID,ref int driverID,ref int licenseClass,
        //    DateTime issueDate, DateTime expirationDate, string notes, float paidFees, bool isActive,
        //    int issueReason, int createdByUserID)
        //{

        //}

        public static bool isPersonAlreadyHasLicense(int PersonID, int LicenseClassID)
        {
            bool Result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT f=1  FROM Applications INNER JOIN
                            Licenses ON Applications.ApplicationID = Licenses.ApplicationID
                            where Applications.ApplicantPersonID = @PersonID and Licenses.LicenseClass = @LicenseClassID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        public static bool isLDLAlreadyHasLicense(int LocalDrivingLicenseAppID)
        {
            bool Result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT 1
                    FROM     Licenses INNER JOIN
                  Applications ON Licenses.ApplicationID = Applications.ApplicationID INNER JOIN
                  LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
				  where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseAppID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseAppID", LocalDrivingLicenseAppID);

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
