﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__DataAccessLayer
{
    public class clsLicenseClassData
    {
        public static List<string> GetAllLicenseClasses()
        {
            List<string> list = new List<string>();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select ClassName from LicenseClasses";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["ClassName"].ToString());
                }
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }
            return list;
        }
        public static float GetLicenseClassFees(int LiceseClassID)
        {
            float fees = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select ClassFees from LicenseClasses Where LicenseClassID = @ID;";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@ID",LiceseClassID);
            try
            {
                connection.Open();
                object ReaderResult = sqlCommand.ExecuteScalar();
                if(float.TryParse(ReaderResult.ToString(),out float Result))
                {
                    fees = Result;
                }
            }
            catch {}
            finally { connection.Close(); }
            return fees;

        }
        public static bool GetClassName(int ClassID,ref string ClassName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select ClassName from LicenseClasses where LicenseClassID = @ID;";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@ID",ClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read()) 
                {
                    isFound = true;
                    ClassName = reader["ClassName"].ToString();
                }
            }
            catch { }
            finally { connection.Close(); }
            return isFound;
        }

        public static int GetLicenseClassDefaultValidityLength(int LiceseClassID)
        {
            int validity = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT DefaultValidityLength FROM LicenseClasses WHERE LicenseClassID = @ID;";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@ID", LiceseClassID);
            try
            {
                connection.Open();
                object ReaderResult = sqlCommand.ExecuteScalar();
                if (int.TryParse(ReaderResult.ToString(), out int Result))
                {
                    validity = Result;
                }
            }
            catch { }
            finally { connection.Close(); }
            return validity;

        }
    } 
}
