using ContactsDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBusinessLayer
{
    public class clsCountry
    {
        public enum enMode { AddNew = 1, Update = 2 }
        enMode Mode;
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountry()
        {
            CountryID = -1;
            CountryName = string.Empty;

            Mode = enMode.AddNew;
        }
        private clsCountry(int countryID, string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;

            Mode = enMode.Update;
        }

        //private bool _AddNewCountry()
        //{
        //    this.CountryID = clsCountryData.AddNewCountry(this.CountryName, this.Code, this.PhoneCode);

        //    return (this.CountryID != -1);
        //}

        //private bool _UpdateCountry()
        //{
        //    return clsCountryData.UpdateCountry(this.CountryID, this.CountryName, this.Code, this.PhoneCode);
        //}
        public static clsCountry Find(int countryID)
        {
            string countryName = "";

            if (clsCountryData.GetCountryInfoByCountryID(countryID, ref countryName))
            {
                return new clsCountry(countryID, countryName);
            }
            else
            {
                return null;
            }
        }
        public static clsCountry Find(string countryName)
        {
            int countryID = -1;

            if (clsCountryData.GetCountryInfoByCountryName(ref countryID, countryName))
            {
                return new clsCountry(countryID, countryName);
            }
            else
            {
                return null;
            }
        }

        //public bool Save()
        //{
        //    switch (Mode)
        //    {
        //        case enMode.AddNew:
        //            if (this._AddNewCountry())
        //            {
        //                Mode = enMode.Update;
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        case enMode.Update:
        //            return _UpdateCountry();

        //        default:
        //            return false;
        //    }

        //}

        //public static bool DeleteCountry(int countryID)
        //{
        //    return clsCountryData.DeleteCountry(countryID);
        //}

        public static DataTable GetAllCountries()
        {
            return clsCountryData.getAllCountries();
        }

        public static List<string> GetAllCountriesNameList()
        {
            return clsCountryData.getAllCountriesNameList();
        }

        //public static bool isCountryExist(int countryID)
        //{
        //    return clsCountryData.isCountryExist(countryID);
        //}

        //public static bool isCountryExist(string countryName)
        //{
        //    return clsCountryData.isCountryExist(countryName);
        //}
    }
}
