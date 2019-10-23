using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSGS_Password_Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SSGS_Password_Validator.Tests
{
    [TestClass()]
    public class PwdValidatorTests
    {
        //[DataSource("System.Data.SqlClient", "Data Source=.;Initial Catalog=\"SSGS EMS Data\"; Integrated Security=True;Pooling=False", "ValidPwd",  DataAccessMethod.Sequential),
        [TestMethod]
        public void PasswdValidationTestNew()
        {
            bool actual;
            bool expcted = true;
//                Convert.ToBoolean(TestContext.DataRow["Valid"]);
            string pwd;
            pwd = "P2ssw0rd"; // TestContext.DataRow["Pwd"].ToString();
            PwdValidator validator = new PwdValidator();
            actual = validator.PasswdValidation(pwd);
            Assert.AreEqual(actual, expcted);
            
        }
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
    }
}
