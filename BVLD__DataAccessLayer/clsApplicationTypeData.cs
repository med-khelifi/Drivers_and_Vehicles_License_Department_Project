using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsApplicationTypeData
    {

        public static DataTable GetAllUsers()
        {
            DataTable UsersData = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select * from ApplicationTypes;";
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                UsersData.Load(reader); // Load all data at once, no loop needed
                reader.Close();
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return UsersData;
        }
        public static bool UpdateApplicationType(int ApplicationTypeID, string NewTitle, float NewFees)
        {
            int effectedRow = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Update ApplicationTypes 
                     SET ApplicationTypeTitle = @NewTitle,
                         ApplicationFees = @NewFees
                     WHERE ApplicationTypeID = @ApplicationID;";
            SqlCommand cmd = new SqlCommand(Query, connection);

            // Explicitly set parameter types
            cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationTypeID;
            cmd.Parameters.Add("@NewTitle", SqlDbType.NVarChar, 100).Value = NewTitle; // Adjust length if necessary
            cmd.Parameters.Add("@NewFees", SqlDbType.SmallMoney).Value = NewFees;

            try
            {
                connection.Open();
                effectedRow = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               // Console.WriteLine("An error occurred: " + ex.Message); // Log the error for debugging
            }
            finally
            {
                connection.Close();
            }

            return effectedRow > 0;
        }
        public static bool GetApplicationtypeInfo(int ApplicationID, ref string ApplicationTitle, ref float Fees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * from ApplicationTypes where ApplicationTypeID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationTitle = reader["ApplicationTypeTitle"].ToString();
                    Fees = Convert.ToSingle(reader["ApplicationFees"]);
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("An error occurred: " + ex.Message);
                isFound=false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static int AddNewApplicationType(string Title, float Fees)
        {
            int ApplicationTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                            Values (@Title,@Fees)
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return ApplicationTypeID;

        }
    }

}
