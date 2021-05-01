using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PresentationLayer.Common
{
    static public class ButtonHelper
    {
        static public void SetToBorderLess(Button button)
        {
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.MouseOverBackColor = button.BackColor;
            button.FlatAppearance.MouseDownBackColor = button.BackColor;

            button.MouseMove += new MouseEventHandler(OnBorderlessMouseMoveEventRaised);
            button.MouseLeave += new EventHandler(OnBorderlessMouseLeaveEventRaised);
        }

        static public void SetGroupToBorderless(List<Button> buttons)
        {
            foreach (Button btn in buttons)
            {
                SetToBorderLess(btn);
            }
        }
        private static void OnBorderlessMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
        private static void OnBorderlessMouseLeaveEventRaised(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
        static public void SetVisibilityOfButtons(List<Button> buttons, bool visibility, Label underlineLabel )
        {
            foreach (Button btn  in buttons)
            {
                btn.Visible = visibility;
            }

            if (underlineLabel != null)
            {
                underlineLabel.Visible = visibility;
            }
        }
        
        static public void SetSelectedButton(Button button)
        {
            button.BackColor = Color.FromArgb(0, 111, 156);
        }

        static public void SetUnselectedButton(Button button)
        {
            button.BackColor = Color.FromArgb(0, 120, 215);
        }





        static public void SetUnderlinePosition(Button button, Label underlineLabel )
        {
            underlineLabel.Width = button.Bounds.Width - (int)(button.Bounds.Width * .15); ;
            underlineLabel.Left = button.Bounds.Left + (int)(button.Bounds.Width * .08); ;
            underlineLabel.Top = button.Top + button.Height;
        }
    }
}
