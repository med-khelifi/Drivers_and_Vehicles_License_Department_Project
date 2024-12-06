using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsLicenseData
    {
        public static DataTable GetLocalDrivingLicenses(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive
                    FROM     Applications INNER JOIN
                  Licenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN
                  LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
				  where ApplicantPersonID = @PersonID;";
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


        public static bool GetLicenseInfo(int licenseID, ref int applicationID, ref int driverID, ref int licenseClass,
            ref DateTime issueDate,ref DateTime expirationDate,ref string notes, ref float paidFees,ref bool isActive,
            ref int issueReason,ref int createdByUserID)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT * from Licenses where LicenseID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", licenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    applicationID = Convert.ToInt32(reader["ApplicationID"]);
                    driverID = Convert.ToInt32(reader["DriverID"]);
                    licenseClass = Convert.ToInt32(reader["LicenseClass"]);
                    issueDate = Convert.ToDateTime(reader["IssueDate"]);
                    expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    notes = (reader["Notes"] == DBNull.Value ? "" : reader["Notes"].ToString());
                    paidFees = Convert.ToInt32(reader["PaidFees"]);
                    isActive = Convert.ToBoolean(reader["IsActive"]);
                    issueReason = Convert.ToInt32(reader["IssueReason"]);
                    createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                }
                
            }
            catch { }
            finally { connection.Close(); }
            return isfound;
            
        }

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
        public static int GetLicenseIDFromLDLApp(int LocalDrivingLicenseID)
        {
            int AddID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select LicenseID
                from LocalDrivingLicenseApplications inner join Applications on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                join Licenses on Licenses.ApplicationID = Applications.ApplicationID
                where LocalDrivingLicenseApplicationID = @ID;;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", LocalDrivingLicenseID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null &&int.TryParse(Result.ToString(), out int value))
                {
                    AddID = value;
                }
            }
            catch { }
            finally { connection.Close(); }
            return AddID;
        }

        public static bool DeactivateLisense(int LicenseID)
        {
            int effectedRow = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE Licenses SET IsActive = 0 where LicenseID = @ID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", LicenseID);
            
            try
            {
                connection.Open();
                effectedRow = command.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                //Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return (effectedRow > 0);
        }
    }
}
