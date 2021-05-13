using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Commons
{
    public class TextBoxHelper
    {
        public void SetBorderTextBox(TextBox textBox)
        {

        }

        public void SetBackGroundTextBox(TextBox textBox)
        {

        }

        public void SetMaskedTextBox(MaskedTextBox textBox)
        {
            textBox.Mask = @"000\.000\.000\-00";
        }

        public void SetUnmaskedTextBox(MaskedTextBox textBox)
        {
            textBox.Mask = null;
        }
    }
}
