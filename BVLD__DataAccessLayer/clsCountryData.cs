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
        public static bool GetCountryInfoByCountryName(ref int , string CountryName)
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
    }
}
