using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;

namespace BVLD__DataAccessLayer
{
    public class clsDetainedLicenseData
    {
        public static DataTable GetDetainedLicenses()
        {
            DataTable PeopleData = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select * from DetainedLicenses_View;";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                PeopleData.Load(reader);

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

        public static int AddNewDetainLicense(int LicenseID, DateTime DetainDate,float FineFees,int CreatedByUserID,bool IsReleased,DateTime ReleaseDate,int ReleasedByUserID,int ReleaseApplicationID)
        {
            int AddID = -1;
            string query = @"
        INSERT INTO DetainedLicenses 
        (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
        VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);
        SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters with explicit types
                    command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
                    command.Parameters.Add("@DetainDate", SqlDbType.DateTime).Value = DetainDate;
                    command.Parameters.Add("@FineFees", SqlDbType.Float).Value = FineFees;
                    command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                    command.Parameters.Add("@IsReleased", SqlDbType.Bit).Value = IsReleased;

                    // Handle nullable fields
                    command.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value =
                        ReleaseDate == DateTime.MinValue ? (object)DBNull.Value : ReleaseDate;
                    command.Parameters.Add("@ReleasedByUserID", SqlDbType.Int).Value =
                        ReleasedByUserID == -1 ? (object)DBNull.Value : ReleasedByUserID;
                    command.Parameters.Add("@ReleaseApplicationID", SqlDbType.Int).Value =
                        ReleaseApplicationID == -1 ? (object)DBNull.Value : ReleaseApplicationID;

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int value))
                    {
                        AddID = value;
                    }
                }
            }
            catch 
            {
                // Log or handle the exception as needed
                //Console.WriteLine($"Error: {ex.Message}");
            }

            return AddID;
        }

        public static bool FindDetainByID(int DetainID,ref int LicenseID,ref DateTime DetainDate,ref float FineFees,
            ref int CreatedByUserID,ref bool IsReleased,ref DateTime ReleaseDate,ref int ReleasedByUserID,
            ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from DetainedLicenses where DetainID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;

                    LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    DetainDate = Convert.ToDateTime( reader["DetainDate"]);
                    FineFees = Convert.ToSingle( reader["FineFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsReleased = Convert.ToBoolean( reader["IsReleased"]);

                    if (reader["ReleaseDate"] != DBNull.Value)
                        ReleaseDate = Convert.ToDateTime( reader["ReleaseDate"]);
                    else
                        ReleaseDate = DateTime.MinValue;

                    

                    if (reader["ReleasedByUserID"] != DBNull.Value)
                        ReleasedByUserID = Convert.ToInt32(reader["ReleasedByUserID"]);
                    else
                        ReleasedByUserID = -1; 


                    if (reader["ReleaseApplicationID"] != DBNull.Value)
                        ReleaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);
                    else
                        ReleaseApplicationID =-1;

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

        public static bool updateDetainLicense(int DetainID,bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int Result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Querry = @"UPDATE DetainedLicenses SET IsReleased =@IsReleased, ReleaseDate = @ReleaseDate, ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID
                                where DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(Querry, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

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

        static public int GetDetainID(int LicenseID)
        {
            int detainID = -1;
            string query = @"select DetainedLicenses.DetainID from DetainedLicenses where IsReleased = 0 and LicenseID = @LicenseID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters with explicit types
                    command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
                    

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int value))
                    {
                        detainID = value;
                    }
                }
            }
            catch
            {
                // Log or handle the exception as needed
                //Console.WriteLine($"Error: {ex.Message}");
            }

            return detainID;
        }


        public static bool isDetained(int DetainID)
        {
            bool Result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT 1
                  FROM     DetainedLicenses  where IsReleased = 0 and DetainID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", DetainID);

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