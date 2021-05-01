using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Common
{
    static public class FormHelper
    {
        static public void SetDialogApparecne(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.BackColor = System.Drawing.Color.White;
            form.Icon = Properties.Resources.catlog;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

        }

        static public void SetFormAppearance(Form form)
        {
            SetDialogApparecne(form);
            form.MinimizeBox = true;
            form.MaximizeBox = true;
        }
    }
}
