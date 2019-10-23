using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using SSGS_EMS_Entities;
using SSGS_EMS_Data_Access;


namespace SSGS_EMS_Business_Logic
{
    public class EmployeeDataController
    {
        public Employee GetBasicEmployee(int EmpId)
        {
            Employee employee = null;

            if (Validator.ValidateEmployeeId(EmpId))
            {
                EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
                employee = empDataAccess.GetBasicEmployeeData(EmpId);
            }
            return employee;
        }

        public EmployeeOptionalInfo GetExtendedEmployeeData(int EmpId)
        {
            EmployeeOptionalInfo empOptInfo = null;
            if (Validator.ValidateEmployeeId(EmpId))
            {
                EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
                empOptInfo = empDataAccess.GetExtendedEmployeeData(EmpId);
            }
            return empOptInfo;

        }
        public string SetOptionalEmployee(int empId,string eduInfo,string family, string hobbies)
        {
            string retVal = "";
            EmployeeOptionalInfo empOptInfo = new EmployeeOptionalInfo(empId, eduInfo, family, hobbies);
            SSGS_EMS_Data_Access.EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
            if (empDataAccess.UpdateEmpOptionalDetails(empOptInfo))
            {
                retVal = "optioanl info updated";
            }
            else
            {
                retVal = "optional info not updated";
            }
            return retVal;
        }
        public string SetBasicEmployee(int empid,string fname,string lname,string desig,string dept,string reportsTo,string pwd)
        {
            string retVal = "";
            Employee employee = new Employee(empid, fname, lname, desig, dept, reportsTo);
            SSGS_EMS_Data_Access.EmployeeDataAccess empDataAccess = new EmployeeDataAccess();

            #region Department Validity Check
            if (Validator.CheckDept(Convert.ToInt32(dept),fname,lname))
            {
                retVal = "Valid";
                //dept valid
                //check if report to fields is correct

            }
            else
            {
                retVal= "Department wrong";
            }
            #endregion

            if (empid == 0)
            {
                if (empDataAccess.AddEmployee(employee))
                    retVal = "Employee Added";
                else
                    retVal = "Employee Cannot be Added";
            }
            else if (empDataAccess.UpdateEmpDetails(employee))
                retVal = "Employee Data Updated";

            else
                retVal = "Employee Data Cannot be Updated";

            return retVal;
        }
        public string AddEmployee(int empid, string fname, string lname, string desig, string dept, string reportsTo, string pwd, string empEduInfo, string empFamily, string empHobbies)
        {
            string retVal = "";
            Employee employee = new Employee(empid, fname, lname, desig, dept, reportsTo);
            EmployeeOptionalInfo empOptInfo = new EmployeeOptionalInfo(empid, empEduInfo, empFamily, empHobbies);
            
            SSGS_EMS_Data_Access.EmployeeDataAccess empDataAccess = new EmployeeDataAccess();

            #region Department Validity Check
            if (Validator.CheckDept(Convert.ToInt32(dept), fname, lname))
            {
                retVal = "Valid";
                //dept valid
                //check if report to fields is correct

            }
            else
            {
                retVal = "Department wrong";
            }
            #endregion

            if (empDataAccess.AddEmployee(employee))
            {
                if (empDataAccess.AddEmployeeOptional(empOptInfo))
                {
                    retVal = "Employee Added";
                }
            }
            else
            {
                retVal = "Employee Cannot be Added";
            }
            

            return retVal;
        }
        public bool AuthEmp(string uname, string pwd, int id)
        {
            SSGS_EMS_Data_Access.EmployeeDataAccess empDataAccess = new SSGS_EMS_Data_Access.EmployeeDataAccess();
            return empDataAccess.AuthLogin(uname, pwd, 0);
        }

    }
}
