using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSGS_EMS_Web_App.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            SSGS_EMS_Data_Access.EmployeeDataAccess empDataAccess = new SSGS_EMS_Data_Access.EmployeeDataAccess();
            int Userid=empDataAccess.AuthLogin(UserName.Text, Password.Text);
            if (Userid!=0)
            {
                //valid user
                System.Web.Security.FormsAuthentication.SetAuthCookie(UserName.Text, false);
                Session["UserId"] = Userid;
                //adding one form for User Information
                Response.Redirect("../UserInfo.aspx");
               
            }
            else
            {
                //invalid usert
            }

        }
    }
}
