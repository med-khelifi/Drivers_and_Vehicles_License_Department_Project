using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsDriverData
    {
        public static DataTable GetAllDriversTable()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Drivers_View.* FROM Drivers_View;";
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
        public static int AddNewDriver(int PersonID ,int CreatedByUserID,DateTime CreatedDate)
        {
            int AddID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                             VALUES (@PersonID,@CreatedByUserID,@CreatedDate);
                             select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if(int.TryParse(Result.ToString(), out int value))
                {
                    AddID = value;
                }
            }
            catch {}
            finally { connection.Close(); }
            return AddID;
        }
        public static bool isPersonADriver(int PersonID)
        {
            bool Result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select f=1 from Drivers where PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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
        public static int GetDriverIDOfPerson(int PersonID)
        {
            int Result = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select DriverID from Drivers where PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if(int.TryParse(reader.ToString(), out int value))
                {
                    Result = value;
                }
            }
            catch { }
            finally { connection.Close(); }
            return Result;
        }
        public static int GetPersonIDOfDriver(int driverID)
        {
            int Result = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select PersonID from Drivers where DriverID = @DriverID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DriverID", driverID);

            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();
                if (reader != null && int.TryParse(reader.ToString(), out int value))
                {
                    Result = value;
                }
            }
            catch { }
            finally { connection.Close(); }
            return Result;
        }
    }
}
