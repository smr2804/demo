using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SSGS_EMS_Entities
{
    public class Employee
    {
        public Employee()
        {
            EmpId = 0;
            EmpFirstName = "";
            EmpLastName = "";
            EmpDesignation = "";
            EmpDepartment = "";
            EmpReportsTo = "";
        }
        
        public Employee(int empId, string empFirstName, string empLastName, string empDesignation, string empDepartment, string empReportsTo)
        {
            EmpId = empId;
            EmpFirstName = empFirstName;
            EmpLastName = empLastName;
            EmpDesignation = empDesignation;
            EmpDepartment = empDepartment;
            EmpReportsTo = empReportsTo;
        }

        public Employee(string FirstName, string LastName)
        {
            
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=SSGS EMS Data;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand("SELECT * FROM EmpMaster WHERE EmpFirstName='" + FirstName + "' AND EmpLastName='" + LastName + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dr.Read();
            this.EmpId = int.Parse(dr["EmpId"].ToString());
            this.EmpFirstName = dr["EmpFirstName"].ToString();
            this.EmpLastName = dr["EmpLastName"].ToString();
            this.EmpDesignation = dr["EmpDesignation"].ToString();
            this.EmpDepartment = dr["EmpDepartment"].ToString();
            this.EmpReportsTo = dr["EmpReportsTo"].ToString();
            dr.Close();
        }

        

        public int EmpId;
        public string EmpFirstName;
        public string EmpLastName;
        public string EmpDesignation;
        public string EmpDepartment;
        public string EmpReportsTo;
    }
}
