using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace SSGS_Password_Validator
{
    public class PwdValidator
    {
        //demo
        public bool PasswdValidation(string password)
        {
            //Requirement states that length of password to be within 6 to 10 characters
            if (password.Length > 6 && password.Length <= 10)
            {
                if (!password.Contains("."))
                {
                    if (!password.Contains(" "))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool UserNameValidation(string UName)
        {
            throw new NotImplementedException();
        }
    }
}
