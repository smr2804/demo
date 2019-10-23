using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SSGS_EMS_Entities;
using SSGS_EMS_Business_Logic;

namespace SSGS_EMS_WinForm_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            button1.Enabled = false;
          
            Employee employee = this.GetBasicData(int.Parse(textBox1.Text));

            textBox2.Text = employee.EmpFirstName;
            textBox3.Text = employee.EmpLastName;
            textBox4.Text = employee.EmpDesignation;
            textBox5.Text = employee.EmpDepartment;
            textBox6.Text = employee.EmpReportsTo;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            button2.Visible = true;
        }
        private Employee GetBasicData(int EmpId)
        {
            //Validator.ValidateEmployeeId(EmpId);
            EmployeeDataController employeeDataController = new EmployeeDataController();
            Employee employee = employeeDataController.GetBasicEmployee(EmpId);
            btnNew.Enabled = false;
            
            return employee;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeDataController employeeDataController = new EmployeeDataController();
            EmployeeOptionalInfo employeeOptInfo = employeeDataController.GetExtendedEmployeeData(int.Parse(textBox1.Text));
            if (employeeOptInfo != null)
            {
                textBox7.Text = employeeOptInfo.EmpEduInfo;
                textBox8.Text = employeeOptInfo.EmpFamilyInfo;
                textBox9.Text = employeeOptInfo.EmpHobbies;
            }
            btnUpdate.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            btnUpdate.Enabled = false;
            SSGS_EMS_Business_Logic.EmployeeDataController empController = new 
                EmployeeDataController();
                
            string ret = empController.SetBasicEmployee(Int32.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, "password");
            empController.SetOptionalEmployee(Int32.Parse(textBox1.Text),textBox7.Text, textBox8.Text, textBox9.Text);
            MessageBox.Show(ret);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SSGS_EMS_Business_Logic.EmployeeDataController empController = new EmployeeDataController();
            string msg = empController.AddEmployee(0, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, "password", textBox7.Text, textBox8.Text, textBox9.Text);
            MessageBox.Show(msg, "Employee Addition Result", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void ResetButtons()
        {
            button1.Enabled = true;
            button2.Visible = false;
            btnNew.Enabled = true;
            btnUpdate.Enabled = false;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.ResetButtons();
            FormReset.ResetFields(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
