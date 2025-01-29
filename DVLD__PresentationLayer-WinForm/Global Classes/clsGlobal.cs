using BVLD__BusinessLayer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public static class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            string keyPath = @"HKEY_CURRENT_USER\Software\DVLD";
            string UserName_ValueName = "UserName";
            string Password_ValueName = "Password";
            
            
            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, UserName_ValueName, Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, Password_ValueName, Password, RegistryValueKind.String);
            }
            catch (Exception ex)
            {
               // Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
            return true;
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\Software\DVLD";
            string UserName_ValueName = "UserName";
            string Password_ValueName = "Password";

            try
            {
                // Read the value from the Registry
                Password = Registry.GetValue(keyPath, Password_ValueName, null) as string;
                Username = Registry.GetValue(keyPath, UserName_ValueName, null) as string;


                if (Username == null || Password == null)
                {
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                Log( "Getting Stored Credential Error : " + ex.ToString(),EventLogEntryType.Error);
                return false;
            }
            return true;

        }

        public static void Log(string ex, EventLogEntryType type)
        {
            string sourceName = "DVLD";


            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }


            // Log an information event
            EventLog.WriteEntry(sourceName, ex, EventLogEntryType.Information);

        }
    }
    
}
