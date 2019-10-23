using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace SSGS_EMS_Entities
{
    public class EmployeeOptionalInfo
    {
        public EmployeeOptionalInfo()
        {
            EmpId = 0;
            EmpEduInfo = "";
            EmpFamilyInfo = "";
            EmpHobbies = "";
        }
        public EmployeeOptionalInfo(int empId, string empEduInfo, string empFamilyInfo, string empHobbies)
        {
            EmpId = empId;
            EmpEduInfo = empEduInfo;
            EmpFamilyInfo = empFamilyInfo;
            EmpHobbies = empHobbies;
        }
        public int EmpId;
        public string EmpEduInfo;
        public string EmpFamilyInfo;
        public string EmpHobbies;
    }
}
