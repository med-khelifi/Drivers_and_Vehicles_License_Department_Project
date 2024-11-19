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
        public int TestTypeID {  get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }
        private clsTestType(int testTypeID, string testTypeTitle,string testTypeDescription,float testTypeFees) 
        {
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
        }
        public static clsTestType Find(int testTypeID)
        {
            float fees = 0;
            string testTypeTitle = "", testTypeDescription = "";
            if(clsTestTypeData.GetTestTypeWithID(testTypeID,ref testTypeTitle,ref testTypeDescription,ref fees))
            {
                return new clsTestType(testTypeID,testTypeTitle,testTypeDescription,fees);
            }
            else
            {
                return null;
            }
        }
        private bool _Update()
        {
            return clsTestTypeData.UpdateTestType(TestTypeID,TestTypeTitle,TestTypeDescription,TestTypeFees);   
        }
        public bool Save()
        {
            return _Update();
        }

        public static DataTable GetAllTestTable()
        {
            return clsTestTypeData.GetAllTestTypes();
        }
        public static float GetTestFees(int TestID)
        {
            return clsTestTypeData.GetTestFees(TestID);
        }
    }
}
