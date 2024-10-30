using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsUsersData
    {
        public static DataTable GetAllUsers()
        {
            DataTable UsersData = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT Users.UserID, 
                          People.PersonID, 
                          (People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName) AS FullName, 
                          Users.UserName, 
                          Users.IsActive
                          FROM People 
                          INNER JOIN Users ON People.PersonID = Users.PersonID;";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UsersData.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return UsersData;
        }
        public static int AddNewUser(int personID,string userName ,string password,bool isActive)
        {
            int AddedUserID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Users
              (PersonID,UserName,Password,IsActive)
              VALUES
              (@PersonID,@UserName,@Password,@IsActive);
               Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@IsActive", (isActive) ? 1 :0);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (int.TryParse(result.ToString(), out int InsertedID))
                {
                    AddedUserID = InsertedID;
                }

            }
            catch { }
            finally 
            { 
                connection.Close(); 
            }

            return AddedUserID;
        }
        public static bool UpdateUser(int UserID,int personID, string userName, string password, bool isActive)
        {
            int effectedRow = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE Users
             SET PersonID = @PersonID, 
                 UserName = @UserName,
                 Password = @Password,
                 IsActive = @IsActive
            WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@IsActive", (isActive) ? 1 : 0);

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
        public static bool isUser(int PersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select F=1 from Users where PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID",PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
            }
            catch 
            { 
                isFound = false;
            }
            finally { connection.Close(); } 
            return isFound;
        }
        public static bool isUserNameExist(string UserName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select F=1 from Users where UserName = @UserName;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
            }
            catch
            {
                isFound = false;
            }
            finally { connection.Close(); }
            return isFound;
        }
        public static bool GetUserInfo(int userID,ref int personID,ref string userName,ref string password,ref bool isActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select * from Users where UserID = @UserID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID",userID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) 
                { 
                    isFound = true;
                    personID = Convert.ToInt32(reader["PersonID"]);
                    userName = reader["UserName"].ToString();
                    password = reader["Password"].ToString();
                    isActive = Convert.ToBoolean(reader["IsActive"]);
                }
                reader.Close();
            }
            catch
            {
                isFound = false;
            }
            finally { connection.Close(); }

            return isFound;
        }
        public static bool GetUserInfo(ref int userID, ref int personID,string userName, ref string password, ref bool isActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select * from Users where UserName = @UserName;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", userName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    personID = Convert.ToInt32(reader["PersonID"]);
                    userID = Convert.ToInt32(reader["UserID"]);
                    password = reader["Password"].ToString();
                    isActive = Convert.ToBoolean(reader["IsActive"]);
                }
                reader.Close();
            }
            catch
            {
                isFound = false;
            }
            finally { connection.Close(); }

            return isFound;
        }
        public static bool DeleteUser(int UserID)
        {
            int Result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Querry = @"delete from Users Where UserID = @UserID;";

            SqlCommand command = new SqlCommand(Querry, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                Result = command.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return Result > 0;
        }
        public static bool GetUserInfoByUserNameAndPassword(ref int userID, ref int personID, string userName,string password, ref bool isActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select * from Users where UserName = @UserName and Password = @Password;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    personID = Convert.ToInt32(reader["PersonID"]);
                    userID = Convert.ToInt32(reader["UserID"]);
                    password = reader["Password"].ToString();
                    isActive = Convert.ToBoolean(reader["IsActive"]);
                }
                reader.Close();
            }
            catch
            {
                isFound = false;
            }
            finally { connection.Close(); }

            return isFound;
        }

    }
    
}
