﻿using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__BusinessLayer
{
    public class clsUser
    {
        enum enMode { AddNew ,Update}
        enMode Mode;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }    
        public string Password { get; set; }
        public bool isActive { get; set; }
        public clsUser() 
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            this.isActive = false;

            Mode = enMode.AddNew;
        }
        private clsUser(int userID,int personInfo,string userName,string password,bool isActive) 
        { 
            UserID = userID;
            PersonID = personInfo;
            UserName = userName;
            Password = password;
            this.isActive = isActive; 

            Mode = enMode.Update;
        }
        private bool _AddNew()
        {
            UserID = clsUsersData.AddNewUser(PersonID, UserName,Password,isActive);
            return UserID != -1;
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }
        private bool _Update()
        {
            return clsUsersData.UpdateUser(UserID,PersonID,UserName,Password,isActive);
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
        public static bool isThisPersonUser(int personID) 
        { 
            return clsUsersData.isUser(personID);
        }
        public static bool isUserNameExist(string UserName)
        {
            return clsUsersData.isUserNameExist(UserName);
        }
        public static clsUser Find(int userID)
        {
            int personID = -1;
            string userName = "",password = "";
            bool isActive = false;
            if (clsUsersData.GetUserInfo(userID,ref personID,ref userName,ref password,ref isActive))
            {
                return new clsUser(userID,personID,userName,password,isActive);
            }
            else
            {
                return null;
            }
        }
        public static clsUser Find(string userName)
        {
            int personID = -1,userID = -1;
            string password = "";
            bool isActive = false;
            if (clsUsersData.GetUserInfo(ref userID, ref personID, userName, ref password, ref isActive))
            {
                return new clsUser(userID, personID, userName, password, isActive);
            }
            else
            {
                return null;
            }
        }
        
        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }
    }
}