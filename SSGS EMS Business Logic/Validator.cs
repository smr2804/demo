using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using SSGS_EMS_Entities;
using SSGS_EMS_Data_Access;
using System.Data.SqlClient;
using System.Data;
namespace SSGS_EMS_Business_Logic
{
    public class Validator
    {
        public static bool ValidateEmployeeId(int EmpId)
        {
            if (EmpId != 0)
                return true;
            else
                return false;
        }
        public static bool CheckDept(int dept, string fname, string lname)
        {
            bool retVal = false;
            SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=SSGS EMS Data;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Departments WHERE DepId=" + dept, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())
            {
                dr.Close();
                retVal = true;
            }
            else
            {
                dr.Close();
                retVal = false;
            }
            return retVal;
        }
        public static bool CheckEmpl(string fname, string lname)
        {
            bool retVal = false;
            //this method checks id empl with fname and last name already exists
            SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=SSGS EMS Data;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand("SELECT * FROM EmpMaster WHERE EmpFirstName='" + fname + "' AND EmpLastName='" + lname + "'", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())
            {
                dr.Close();

                retVal= false;
            }
            else
            {
                dr.Close();
                retVal= true;
            }
            return retVal;
        }

        
    }
}
