using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSGS_EMS_WinForm_App
{
    class FormReset
    {
        public static void ResetFields(Control form)
        {
            foreach (Control cntrl in form.Controls)
            {
                if (cntrl.Controls.Count > 0)
                    ResetFields(cntrl);
                Reset(cntrl);
            }
        }
        public static void Reset(Control cntrl)
        {
            if (cntrl is TextBox)
            {
                TextBox tb = (TextBox)cntrl;
                if (tb != null)
                    tb.ResetText();
            }
        }
    }
}
