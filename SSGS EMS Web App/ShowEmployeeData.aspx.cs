using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSGS_EMS_Business_Logic;
using SSGS_EMS_Entities;

namespace SSGS_EMS_Web_App
{
    public partial class ShowEmployeeData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            TextBox1.Text = Convert.ToInt32(Session["UserId"]).ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Employee employee = this.GetBasicData(int.Parse(TextBox1.Text));
            
            Label1.Text = "First Name: " + employee.EmpFirstName;
            Label2.Text = "Last Name: " + employee.EmpLastName;
            Label3.Text = "Designation: " + employee.EmpDesignation;
            Label4.Text = "Department: " + employee.EmpDepartment;
            Label5.Text = "Reports to: " + employee.EmpReportsTo;
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Button2.Visible = true;
        }

        private Employee GetBasicData(int EmpId)
        {
            //Validator.ValidateEmployeeId(EmpId);
            EmployeeDataController employeeDataController = new EmployeeDataController();
            Employee employee = employeeDataController.GetBasicEmployee(EmpId);
            return employee;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EmployeeDataController employeeDataController = new EmployeeDataController();
            EmployeeOptionalInfo employeeOptInfo = employeeDataController.GetExtendedEmployeeData(int.Parse(TextBox1.Text));
            if (employeeOptInfo != null)
            {
                Label6.Text = "Educational Info: " + employeeOptInfo.EmpEduInfo;
                Label7.Text = "Family Details: ";// +employeeOptInfo.EmpFamilyInfo;
                Label8.Text = "Hobbies: ";// +employeeOptInfo.EmpHobbies;
                Label6.Visible = true;
                Label7.Visible = true;
                Label8.Visible = true;
            }

        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            if (txtconfPwd.Text == txtNewPwd.Text)
            {
                //check password validity
                SSGS_Password_Validator.PwdValidator passwordValidator = new SSGS_Password_Validator.PwdValidator();
                if (passwordValidator.PasswdValidation(txtNewPwd.Text))
                {
                    //change the password in table
                    SSGS_EMS_Data_Access.EmployeeDataAccess empDataAccess = new SSGS_EMS_Data_Access.EmployeeDataAccess();
                    if (empDataAccess.ChangePassword(txtNewPwd.Text,Convert.ToInt32(Session["UserId"].ToString())))
                    {
                        PwdLabel.Text = "Password changed successfully";
                    }
                    else
                    {
                        PwdLabel.Text="Password change failed";
                    }
                }
                else
                {
                    //password does not satisfy conditions so ask to reenter
                    PwdLabel.Text = "password is not valid. need to be between 6 to 10 chars";
                }
            }
            else
            {
                txtNewPwd.Text = "";
                txtconfPwd.Text = "";
                txtNewPwd.Focus();
            }

        }
    }
}