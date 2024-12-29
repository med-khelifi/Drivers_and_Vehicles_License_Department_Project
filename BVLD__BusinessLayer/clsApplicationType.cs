using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVLD__BusinessLayer
{
    public class clsApplicationType
    {
        enum enMode { AddNew,Update}
        enMode _Mode;
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public float ApplicationFees { get; set; }

        public clsApplicationType() 
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = string.Empty;
            ApplicationFees = -1;

            _Mode = enMode.AddNew;  
        }
        private clsApplicationType(int applicationTypeID, string applicationTypeTitle, float applicationFees)
        {
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;

            _Mode = enMode.Update;
        }
        public static DataTable GetApplicationTypesTable()
        {
            return clsApplicationTypeData.GetAllUsers();
        }
        private bool _UpdateApplicationType() 
        {
            return clsApplicationTypeData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationType();

            }

            return false;
        }
        public static clsApplicationType Find(int applicationTypeID) 
        { 
            float applicationFees = -1;
            string applicationTypeTitle = string.Empty;
            if (clsApplicationTypeData.GetApplicationtypeInfo(applicationTypeID, ref applicationTypeTitle, ref applicationFees))
            {
                return new clsApplicationType(applicationTypeID, applicationTypeTitle, applicationFees);
            }
            else { return null; }
        }

        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.ApplicationTypeID = clsApplicationTypeData.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationFees);


            return (this.ApplicationTypeID != -1);
        }

    }
}
