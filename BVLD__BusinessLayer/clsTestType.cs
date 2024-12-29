using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__BusinessLayer
{
    public class clsTestType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public enTestType TestTypeID {  get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }
        private clsTestType(enTestType testTypeID, string testTypeTitle,string testTypeDescription,float testTypeFees) 
        {
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;

            Mode = enMode.Update;
        }

        public clsTestType()

        {
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;
            Mode = enMode.AddNew;

        }

        public static clsTestType Find(enTestType testTypeID)
        {
            float fees = 0;
            string testTypeTitle = "", testTypeDescription = "";
            if(clsTestTypeData.GetTestTypeWithID((int)testTypeID,ref testTypeTitle,ref testTypeDescription,ref fees))
            {
                return new clsTestType(testTypeID,testTypeTitle,testTypeDescription,fees);
            }
            else
            {
                return null;
            }
        }
        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType((int)TestTypeID,TestTypeTitle,TestTypeDescription,TestTypeFees);   
        }

        private bool _AddNewTestType()
        {
            //call DataAccess Layer 

            this.TestTypeID = (clsTestType.enTestType)clsTestTypeData.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

            return (this.TestTypeTitle != "" && (int)TestTypeID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestType();

            }

            return false;
        }

        public static DataTable GetAllTestTable()
        {
            return clsTestTypeData.GetAllTestTypes();
        }
      
    }
}
