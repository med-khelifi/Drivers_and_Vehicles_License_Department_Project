using BVLD__DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BVLD__BusinessLayer
{
    public class clsTest
    {
        enum enMode { addNew,update}
        enMode Mode;
        public int TestID { get; set; }
        public int TestAppointmentID {  get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUser { get; set; }

        private clsTest(int testID,int testAppointmentID,bool testResult,string notes,int createdByUser)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUser = createdByUser;
            Mode = enMode.update;
        }
        public clsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUser = -1;
            Mode = enMode.addNew;
        }

        private bool _AddNew()
        {
            TestID = clsTestData._AddNewTest(TestAppointmentID,TestResult,Notes,CreatedByUser);
            return TestID != -1;
        }

        public bool Save()
        {
            switch (Mode)
             {
                    case enMode.addNew:
                    if (_AddNew())
                    {
                        Mode = enMode.update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    default: 
                    return false;
            }
        }
        public static bool isTestAlreadyPassed(int LDLAppID, int TestType)
        {
            return clsTestData.isTestAlreadyPassed(LDLAppID, TestType);
        }
        public static bool isTestAlreadyFaild(int LDLAppID, int TestType)
        {
            return clsTestData.isTestAlreadyFaild(LDLAppID, TestType);
        }
    }
}
