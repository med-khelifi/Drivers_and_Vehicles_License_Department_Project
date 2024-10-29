﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BVLD__DataAccessLayer;
namespace BVLD__BusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode { get; set; }

        public int PersonId { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        private clsPerson(int personID, string nationalNo, string firstName, string secondName, string thirdName, string lastName,
         int gender, DateTime dateOfBirth, int countryID, string phone, string email, string address, string imagePath)
        {
            PersonId = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            NationalityCountryID = countryID;
            Address = address;
            Phone = phone;
            Email = email;
            ImagePath = imagePath;

            Mode = enMode.Update;
        }
        public clsPerson()
        {
            PersonId = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            Gender = -1;
            DateOfBirth = DateTime.Now;
            NationalityCountryID = -1;
            Address = "";
            Phone = "";
            Email = "";
            ImagePath = "";

            Mode = enMode.AddNew;
        }
        public static DataTable GetAllPeople()
        {
            return clsPeopleData.GetAllPeople();
        }
        public static clsPerson Find(int ID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Email = "";
            string Address = "", ImagePath = "";
            int Gender = -1, CountryID = -1;
            DateTime DateOfBirth = DateTime.Now;
            if (clsPeopleData.GetPersonInfo(ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Gender, ref DateOfBirth, ref CountryID, ref Phone, ref Email, ref Address, ref ImagePath))
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, Gender, DateOfBirth, CountryID, Phone, Email, Address, ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Email = "";
            string Address = "", ImagePath = "";
            int Gender = -1, CountryID = -1, PersonID = -1;
            DateTime DateOfBirth = DateTime.Now;
            if (clsPeopleData.GetPersonInfo(ref PersonID, NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Gender, ref DateOfBirth, ref CountryID, ref Phone, ref Email, ref Address, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, Gender, DateOfBirth, CountryID, Phone, Email, Address, ImagePath);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNew()
        {
            this.PersonId = clsPeopleData.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName, Gender, DateOfBirth, NationalityCountryID, Phone, Email, Address, ImagePath);
            return (this.PersonId != 0);
        }
        private bool _Update()
        {
            return clsPeopleData.updatePersonInfo(PersonId, NationalNo, FirstName, SecondName, ThirdName, LastName, Gender, DateOfBirth, NationalityCountryID, Phone, Email, Address, ImagePath);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }

        public static bool Delete(int PersonId)
        {
            return clsPeopleData.DeletePerson(PersonId);
        }

        public static bool isPersonExist(int PersonId) 
        { 
            return clsPeopleData.isPersonExist(PersonId);
        }

        public static bool isPersonExist(string NationalNo)
        {
            return clsPeopleData.isPersonExist(NationalNo);
        }
    }
}