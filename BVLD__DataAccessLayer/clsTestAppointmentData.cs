using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsTestAppointmentData
    {
        public static DataTable GetAppointmentInfoAccordingToTestTypeAndLicenseID(int LDLicenseID,int TestType)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT TestAppointmentID as ""Appointment ID"", 
                        AppointmentDate as ""Appointment Date"", 
                        PaidFees as ""Paid Fees"", 
                        IsLocked as ""Is Locked""
                 FROM TestAppointments 
                 WHERE TestTypeID = @TestTypeID 
                   AND LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestType);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }
            return dt;
        }

        public static bool GetTestAppointmentInfo(int testAppointmentID,ref int testTypeID, 
            ref int localDrivingLicenseApplicationID,ref DateTime appointmentDate,ref float paidFees,
            ref int createdByUserID,ref bool isLocked,ref int retakeTestApplicationID)
        {


            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from TestAppointments where TestAppointmentID = @ID";
            SqlCommand command =new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID",testAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    testTypeID = Convert.ToInt32(reader["TestTypeID"]);
                    localDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    appointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    isLocked = Convert.ToBoolean(reader["isLocked"]);
                    retakeTestApplicationID = reader["RetakeTestApplicationID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["RetakeTestApplicationID"]);

                }
                reader.Close();
            }
            catch {  isFound = false; }
            finally { connection.Close(); }
            return isFound;
        }

        
        public static int AddNewAppointment(int testTypeID,
            int localDrivingLicenseApplicationID,DateTime appointmentDate,float paidFees,
            int createdByUserID,bool isLocked,int retakeTestApplicationID)
        {

            int AddedID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO TestAppointments
                   (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
                    VALUES (@testTypeID,@LDLApplicationID,@appointmentDate,@paidFees,@createdByUserID,@isLocked,@RTApplicationID);
                    select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);
            command.Parameters.AddWithValue("@LDLApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@appointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@paidFees", paidFees);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            command.Parameters.AddWithValue("@isLocked", isLocked);
            if (retakeTestApplicationID == -1)
            {
                command.Parameters.AddWithValue("@RTApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RTApplicationID", retakeTestApplicationID);
            }

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (int.TryParse(result.ToString(), out int Result))
                    AddedID = Result;
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return AddedID;
        }

        public static bool UpdateAppointment(int testAppointmentID, int testTypeID,
            int localDrivingLicenseApplicationID, DateTime appointmentDate, float paidFees,
            int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {

            int effectedRow = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE TestAppointments
                            SET
                            TestTypeID = @testTypeID,
                            LocalDrivingLicenseApplicationID = @LDLApplicationID,
                            AppointmentDate = @appointmentDate,
                            PaidFees = @paidFees, 
                            CreatedByUserID = @createdByUserID, 
                            IsLocked = @isLocked, 
                            RetakeTestApplicationID = @RTApplicationID
                            where TestAppointmentID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", testAppointmentID);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);
            command.Parameters.AddWithValue("@LDLApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@appointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@paidFees", paidFees);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            command.Parameters.AddWithValue("@isLocked", isLocked);
            if (retakeTestApplicationID == -1)
            {
                command.Parameters.AddWithValue("@RTApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RTApplicationID", retakeTestApplicationID);
            }

            try
            {
                connection.Open();
                effectedRow = command.ExecuteNonQuery();
                
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return effectedRow > 0;
        }

        public static bool hasUncompleAppointment(int LDLAppID,int TestType)
        {
            bool Result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select f=1 from TestAppointments 
                            where 
                            LocalDrivingLicenseApplicationID = @LDLAppID and IsLocked = 0 and TestTypeID = @TestType;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAppID",LDLAppID);
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
        public static int GetTestTrials(int LDLAppID, int TestType)
        {
            int Result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT COUNT(TestAppointmentID) 
                            FROM TestAppointments 
                            WHERE 
                            LocalDrivingLicenseApplicationID = @LDLAppID 
                            AND IsLocked = 1 
                            AND TestTypeID = @TestType;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestType", TestType);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(int.TryParse(result.ToString(), out int value))
                {
                    Result = value;
                }
                
            }
            catch { }
            finally { connection.Close(); }
            return Result;
        }
        public static DateTime GetAppointmentDate(int AppointmentID)
        {
            DateTime Result = DateTime.MinValue;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT AppointmentDate FROM TestAppointments Where TestAppointmentID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", AppointmentID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (DateTime.TryParse(result.ToString(), out DateTime value))
                {
                    Result = value;
                }

            }
            catch { }
            finally { connection.Close(); }
            return Result;
        }
        public static bool LockAppointment(int AppointmentID)
        {
            int effectedRow = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE TestAppointments SET IsLocked = 1 where TestAppointmentID = @ID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", AppointmentID);
            
            try
            {
                connection.Open();
                effectedRow = cmd.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }
            return effectedRow > 0;
        }
        public static bool isAppointmentLock(int AppointmentID)
        {
            bool islocked = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT f=1 FROM TestAppointments where IsLocked = 1 and TestAppointmentID = @ID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", AppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                islocked = reader.HasRows;
            }
            catch { }
            finally { connection.Close(); }
            return islocked;
        }
    }
}


