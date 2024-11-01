using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BVLD__DataAccessLayer;

namespace ContactsDataLayer
{
    public class clsCountryData
    {
        public static bool GetCountryInfoByCountryID(int CountryID, ref string CountryName)
        {
            bool isCountryFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * from Countries where CountryID = @CountryID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isCountryFound = true;
                    CountryName = (string)reader["CountryName"];
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                isCountryFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isCountryFound;
        }
        public static bool GetCountryInfoByCountryName(ref int CountryID, string CountryName)
        {
            bool isCountryFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * from Countries where CountryName = @CountryName;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isCountryFound = true;
                    CountryID = (int)reader["CountryID"];
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                isCountryFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isCountryFound;
        }

        //public static int AddNewCountry(string CountryName, string Code, string PhoneCode)
        //{
        //    int countryID = -1;
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //    string Query = @"insert into Countries (CountryName,Code,PhoneCode) values (@CountryName,@Code,@PhoneCode);
        //                    Select Scope_Identity();";
        //    SqlCommand command = new SqlCommand(Query, connection);
        //    command.Parameters.AddWithValue("@CountryName", CountryName);
        //    if (Code != "")
        //    {
        //        command.Parameters.AddWithValue("@Code", Code);
        //    }
        //    else
        //    {
        //        command.Parameters.AddWithValue("@Code", DBNull.Value);
        //    }
        //    if (PhoneCode != "")
        //    {
        //        command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
        //    }
        //    else
        //    {
        //        command.Parameters.AddWithValue("@PhoneCode", DBNull.Value);
        //    };

        //    try
        //    {
        //        connection.Open();
        //        object Result = command.ExecuteScalar();
        //        if (int.TryParse(Result.ToString(), out int insertedCountryID))
        //        {
        //            countryID = insertedCountryID;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        //Console.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return countryID;
        //}
        //public static bool UpdateCountry(int CountryID, string CountryName, string Code, string PhoneCode)
        //{
        //    int effectedRow = 0;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //    string Query = @"update Countries 
        //                    set CountryName = @CountryName,
        //                        Code = @Code,
        //                        PhoneCode = @PhoneCode
        //                    where CountryID = @CountryID;";

        //    SqlCommand command = new SqlCommand(Query, connection);
        //    command.Parameters.AddWithValue("@CountryName", CountryName);
        //    command.Parameters.AddWithValue("@CountryID", CountryID);
        //    if (Code != "")
        //    {
        //        command.Parameters.AddWithValue("@Code", Code);
        //    }
        //    else
        //    {
        //        command.Parameters.AddWithValue("@Code", DBNull.Value);
        //    }
        //    if (PhoneCode != "")
        //    {
        //        command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
        //    }
        //    else
        //    {
        //        command.Parameters.AddWithValue("@PhoneCode", DBNull.Value);
        //    };
        //    try
        //    {
        //        connection.Open();
        //        effectedRow = command.ExecuteNonQuery();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        //Console.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return (effectedRow > 0);
        //}
        //public static bool DeleteCountry(int CountryID)
        //{
        //    int effectedRow = 0;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //    string Query = "delete Countries where CountryID = @CountryID;";

        //    SqlCommand command = new SqlCommand(Query, connection);
        //    command.Parameters.AddWithValue("@CountryID", CountryID);

        //    try
        //    {
        //        connection.Open();
        //        effectedRow = command.ExecuteNonQuery();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        //Console.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return (effectedRow > 0);
        //}
        public static DataTable getAllCountries()
        {
            DataTable allCountries = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * from Countries;";
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                allCountries.Load(reader);
                
                reader.Close();
            }
            catch (System.Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return allCountries;
        }

        public static List<string> getAllCountriesNameList()
        {
            List<string> allCountriesName = new List<string>();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select CountryName from Countries;";
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allCountriesName.Add((string)reader["CountryName"].ToString());
                }
                reader.Close();
            }
            catch (System.Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return allCountriesName;
        }

        //public static bool isCountryExist(int ID)
        //{
        //    bool isExist = false;
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //    string query = "Select found = 1 from Countries where CountryID = @CountryID;";
        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    cmd.Parameters.AddWithValue("@CountryID", ID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        isExist = reader.HasRows;
        //        reader.Close();
        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return isExist;

        //}
        //public static bool isCountryExist(string CountryName)
        //{
        //    bool isExist = false;
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //    string query = "Select found = 1 from Countries where CountryName = @CountryName;";
        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    cmd.Parameters.AddWithValue("@CountryName", CountryName);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        isExist = reader.HasRows;
        //        reader.Close();
        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return isExist;

        //}
    }
}
