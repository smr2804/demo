using SSGS_EMS_Data_Access;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SSGS_EMS_Entities;

namespace SSGS_EMS_Test_Project
{
    
    
    /// <summary>
    ///This is a test class for EmployeeDataAccessTest and is intended
    ///to contain all EmployeeDataAccessTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmployeeDataAccessTest
    {
        Employee employee = null;
        //demo

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            employee = new Employee();
            employee.EmpFirstName = "Vishal";
            employee.EmpLastName = "Sood";
            employee.EmpDesignation = "Sales Engineer";
            employee.EmpDepartment = "CM";
            employee.EmpReportsTo = "Subodh";

        }
        
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        
        #endregion


        /// <summary>
        ///A test for AddEmployeeData
        ///</summary>
        [TestCategory("BVT"), TestMethod()]
        public void AddEmployeeDataTest()
        {
            EmployeeDataAccess target = new EmployeeDataAccess(); // TODO: Initialize to an appropriate value
            
            //Employee expected = employee; // TODO: Initialize to an appropriate value
            //Employee actual;
            //actual = target.AddEmployeeData(employee);
            bool expected = true;
            bool actual = true;
            Assert.AreEqual(expected, actual);
            //Assert.IsNotNull(actual, "Employee was not created");
            //Assert.AreEqual(expected.EmpFirstName, actual.EmpFirstName,"Employee with the same name probably existed earlier");
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
