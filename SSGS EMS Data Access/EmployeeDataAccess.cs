using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SSGS_EMS_Entities;

namespace SSGS_EMS_Data_Access
{
    public class EmployeeDataAccess
    {
        //The following method adds an employee in the EmpMaster table
        public Employee AddEmployeeData(Employee employee)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=SSGS EMS Data;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand("INSERT INTO EmpMaster (EmpFirstName,EmpLastName,EmpDesignation,EmpDepartment,EmpReportsTo,Pwd) VALUES ('" + employee.EmpFirstName + "','" + employee.EmpLastName + "','" + employee.EmpDesignation + "','" + employee.EmpDepartment + "','" + employee.EmpReportsTo + "', 'Password')", con);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
            }
            con.Close();
            Employee AddedEmployee = new Employee(employee.EmpFirstName,employee.EmpLastName);
            return AddedEmployee;
        }
        public Employee GetBasicEmployeeData(int EmpId)
        {
            Employee employee = new Employee();
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=SSGS EMS Data;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand("SELECT * FROM EmpMaster WHERE EmpId=" + EmpId,con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dr.Read();
            employee.EmpId = int.Parse(dr["EmpId"].ToString());
            employee.EmpFirstName = dr["EmpFirstName"].ToString();
            employee.EmpLastName = dr["EmpLastName"].ToString();
            employee.EmpDesignation = dr["EmpDesignation"].ToString();
            employee.EmpDepartment = dr["EmpDepartment"].ToString();
            employee.EmpReportsTo = dr["EmpReportsTo"].ToString();

            return employee;
        }
        public bool ChangePassword(string password, int empid)
        {
            bool retVal = false;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=SSGS EMS Data;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand("UPDATE EmpMaster SET Pwd='"+ password + "' WHERE EmpId=" + empid,con);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
                retVal = true;
            else
                retVal = false;
            return retVal;
        }
        public EmployeeOptionalInfo GetExtendedEmployeeData(int EmpId)
        {
            EmployeeOptionalInfo employeeOptionalInfo = new EmployeeOptionalInfo();
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=SSGS EMS Data;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand("SELECT * FROM EmpOptionalData WHERE EmpId=" + EmpId,con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())
            {
                employeeOptionalInfo.EmpId = int.Parse(dr["EmpId"].ToString());
                employeeOptionalInfo.EmpEduInfo = dr["EmpEduInfo"].ToString();
                employeeOptionalInfo.EmpFamilyInfo = dr["EmpFamilyInfo"].ToString();
                employeeOptionalInfo.EmpHobbies = dr["EmpHobbies"].ToString();
                return employeeOptionalInfo;
            }
            else
                return null;
            
        }
        public int AuthLogin(string uname, string pwd)
        {
            int retVal=0;
            SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=SSGS EMS Data;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand("SELECT * FROM EmpMaster WHERE EmpFirstName='" + uname + "' AND Pwd='" + pwd + "'", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())
            {
                retVal = Int32.Parse(dr["EmpID"].ToString());
                dr.Close();                
            }
            else
            {
                dr.Close();
                retVal = 0;
            }
            return retVal;

        }
        public bool UpdateEmpOptionalDetails(EmployeeOptionalInfo empOptInfo)
        {
            bool retVal = false;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=SSGS EMS Data;Integrated Security=SSPI");
            SqlCommand cmd;
            cmd = new SqlCommand("UPDATE EmpOptionalData SET EmpEduInfo='" + empOptInfo.EmpEduInfo + "',EmpFamilyInfo='" + empOptInfo.EmpFamilyInfo + "', EmpHobbies='" + empOptInfo.EmpHobbies + "' WHERE EmpId=" + empOptInfo.EmpId, con);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                retVal = true;
            }
            else
            {
                con.Close();
                retVal = false;
            }
            return retVal;
        }
        public bool UpdateEmpDetails(Employee employee)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=SSGS EMS Data;Integrated Security=SSPI");
            SqlCommand cmd;
            if (employee.EmpReportsTo == "")
            {
                cmd = new SqlCommand("UPDATE EmpMaster SET EmpFirstName='" + employee.EmpFirstName + "', EmpLastName='" + employee.EmpLastName + "', EmpDesignation='" + employee.EmpDesignation + "', EmpDepartment=" + employee.EmpDepartment + ", EmpReportsTo=null WHERE EmpId=" + employee.EmpId, con);
            }
            else
            {
                cmd = new SqlCommand("UPDATE EmpMaster SET EmpFirstName='" + employee.EmpFirstName + "', EmpLastName='" + employee.EmpLastName + "', EmpDesignation='" + employee.EmpDesignation + "', EmpDepartment=" + employee.EmpDepartment + ", EmpReportsTo='" + employee.EmpReportsTo + "' WHERE EmpId=" + employee.EmpId, con);
            }
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                //update the optional details
                return true;
            }
            con.Close();
            return false;
        }

        //The following method adds an employee in the EmpMaster table
        public bool AddEmployee(Employee employee)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=SSGS EMS Data;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand("INSERT INTO EmpMaster (EmpFirstName,EmpLastName,EmpDesignation,EmpDepartment,EmpReportsTo,Pwd) VALUES ('" + employee.EmpFirstName + "','" + employee.EmpLastName + "','" + employee.EmpDesignation + "','" + employee.EmpDepartment + "','" + employee.EmpReportsTo + "', 'Password')", con);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
        public bool AddEmployeeOptional(EmployeeOptionalInfo empOptInfo)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=SSGS EMS Data;Integrated Security=SSPI");
            SqlCommand cmd1 = new SqlCommand("SELECT EmpId FROM EmpMaster WHERE EmpId = IDENT_CURRENT('EmpMaster')",con);
            con.Open();
            int empID = Convert.ToInt32(cmd1.ExecuteScalar());
            con.Close();
            SqlCommand cmd = new SqlCommand("INSERT INTO EmpOptionalData (EmpId, EmpEduInfo,EmpFamilyInfo, EmpHobbies) VALUES ('" + empID + "', '" + empOptInfo.EmpEduInfo +"' , '"+ empOptInfo.EmpFamilyInfo + "','" + empOptInfo.EmpHobbies + "')", con);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
        public bool AuthLogin(string uname, string pwd,int id)
        {
            bool retVal = false;
            SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=SSGSEMSData;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM EmpMaster WHERE EmpFirstName='" + uname + "' AND Pwd='" + pwd + "'", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())
            {
                if (dr["EmpDepartment"].ToString() == "HR")
                {

                    retVal = true;
                }
               
            }
            else
            {
                retVal = false;
            }
            return retVal;

        }
        //public void SetBasicEmployeeData(Employee employee)
        //{
        //    Employee employee = new Employee();
        //    SqlConnection con = new SqlConnection("Data Source=ssgs-lt5\\SQLEXPRESS;Initial Catalogue=SSGS EMS Data;Integrated Security=SSPI");
        //    SqlCommand cmd = new SqlCommand("INSERT INTO EmpMaster ('
        //}
    }
}
