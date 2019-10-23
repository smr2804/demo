using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSGS_EMS_WinForm_App
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SSGS_EMS_Business_Logic.EmployeeDataController empController = new SSGS_EMS_Business_Logic.EmployeeDataController();
            if (empController.AuthEmp(txtUser.Text, txtPwd.Text,0) )
            {
                //valid user
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.Show();
            }
            else 
            {
                label3.Visible = true;
                label3.Text = "This employee is not authorized for changed, Please reenter";
                txtUser.Text = "";
                txtPwd.Text = "";
                txtUser.Focus();
                label3.Text = "";
            }
        }
    }
}
