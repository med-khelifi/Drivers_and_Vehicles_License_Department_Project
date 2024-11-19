using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsTestTypeData
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * from TestTypes;";
            SqlCommand cmd = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch
            {
                
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static bool GetTestTypeWithID(int TestTypeID,ref string TestTypeTitle,ref string TestTypeDescription,ref float TestTypeFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * from TestTypes where TestTypeID = @ID;";
            SqlCommand cmd = new SqlCommand(Query,connection);
            cmd.Parameters.AddWithValue("@ID",TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestTypeTitle = reader["TestTypeTitle"].ToString();
                    TestTypeDescription = reader["TestTypeDescription"].ToString();
                    TestTypeFees = Convert.ToSingle(reader["TestTypeFees"]);
                }
                reader.Close();
            }
            catch 
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        } 
        public static bool UpdateTestType(int TestTypeID,string TestTypeTitle,string TestTypeDescription,float TestTypeFees)
        {
            int effected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Update TestTypes SET TestTypeTitle = @Title,
                                                   TestTypeDescription = @Description,
                                                    TestTypeFees = @Fees
                                               Where TestTypeID = @ID;";
            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@Title", TestTypeTitle);
            command.Parameters.AddWithValue("@Description", TestTypeDescription);
            command.Parameters.AddWithValue("@Fees", TestTypeFees);
            command.Parameters.AddWithValue("@ID", TestTypeID);

            try
            {
                connection.Open();
                effected = command.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return effected > 0;
        }

        public static float GetTestFees(int TestID)
        {
            float fees = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select TestTypeFees from TestTypes where TestTypeID = @TestID;";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@TestID", TestID);
            try
            {
                connection.Open();
                object ReaderResult = sqlCommand.ExecuteScalar();
                if (float.TryParse(ReaderResult.ToString(), out float Result))
                {
                    fees = Result;
                }
            }
            catch { }
            finally { connection.Close(); }
            return fees;
        }

    }
}
