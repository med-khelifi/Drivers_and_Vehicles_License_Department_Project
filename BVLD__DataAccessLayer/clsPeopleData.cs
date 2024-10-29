using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace BVLD__DataAccessLayer
{
    public class clsPeopleData
    {
        public static DataTable GetAllPeople()
        {
            DataTable PeopleData = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT 
                           People.PersonID, 
                           People.NationalNo, 
                           People.FirstName, 
                           People.SecondName, 
                           People.ThirdName, 
                           People.LastName, 
                           CASE 
                                 WHEN People.Gender = 0 THEN 'Male' 
                                 WHEN People.Gender = 1 THEN 'Female' 
                                 ELSE 'Unknown' 
                          END AS Gender, 
                          People.DateOfBirth, 
                          Countries.CountryName AS Nationality, 
                          People.Phone, 
                          People.Email
                          FROM     
                          Countries 
                          INNER JOIN
                          People ON Countries.CountryID = People.NationalityCountryID;";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PeopleData.Load(reader);
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
            return PeopleData;
        }
        public static bool GetPersonInfo(int PersonID,ref string NationalNo,ref string FirstName,ref string SecondName,ref string ThirdName,ref string LastName,
                                        ref int Gender,ref DateTime DateOfBirth,ref int CountryID,ref string Phone,ref string Email,ref string Address,ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID",PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)reader["LastName"];

                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = Convert.ToInt32(reader["NationalityCountryID"]);

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    NationalNo = (string)reader["NationalNo"];
                    SecondName = (string)reader["SecondName"];
                    Gender = Convert.ToInt32(reader["Gender"]);
                }
                reader.Close();
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool GetPersonInfo(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
                                                ref int Gender, ref DateTime DateOfBirth, ref int CountryID, ref string Phone, ref string Email, ref string Address, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;

                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)reader["LastName"];

                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = Convert.ToInt32(reader["NationalityCountryID"]);

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    PersonID = Convert.ToInt32(reader["¨PersonID"]);
                    SecondName = (string)reader["SecondName"];
                    Gender = Convert.ToInt32(reader["Gender"]);
                }
                reader.Close();
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
     
        public static int AddNewPerson(string NationalNo,string FirstName,string SecondName,string ThirdName,string LastName,
                                                int Gender,DateTime DateOfBirth,int CountryID,string Phone,string Email,string Address,string ImagePath)
        {
            int AddedPersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Querry = @"insert into People
           (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gender,Address,Phone,Email,NationalityCountryID,ImagePath)
            VALUES 
            (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gender,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath);
            Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Querry,connection);
            command.Parameters.AddWithValue("@NationalNo",NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if(string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName",DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", CountryID);

            if (string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (int.TryParse(Result.ToString(), out int InsertedID))
                {
                    AddedPersonID = InsertedID;
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return AddedPersonID;
        }


        public static bool updatePersonInfo(int PersonID,string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                                                int Gender, DateTime DateOfBirth, int CountryID, string Phone, string Email, string Address, string ImagePath)
        {
            int Result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Querry = @"update People set
                            NationalNo = @NationalNo,
                            FirstName = @FirstName,
                            SecondName = @SecondName,
                            ThirdName = @ThirdName,
                            LastName = @LastName,
                            DateOfBirth = @DateOfBirth,
                            Gender = @Gender,
                            Address = @Address,
                            Phone = @Phone,
                            Email = @Email,
                            NationalityCountryID = @NationalityCountryID,
                            ImagePath = @ImagePath
                            Where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(Querry, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", CountryID);

            if (string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

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
        public static bool DeletePerson(int PersonID)
        {
            int Result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Querry = @"delete from People Where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(Querry, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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
        public static bool isPersonExist(int PersonID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select Found = 1 from People where PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.ToString());
                //isFoundnd = false;
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static bool isPersonExist(string NationalNo)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select Found = 1 from People where NationalNo = @NationalNo;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.ToString());
                //isFoundnd = false;
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
    }
}
