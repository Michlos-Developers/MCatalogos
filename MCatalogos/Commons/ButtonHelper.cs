using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.Commons
{
    public class ButtonHelper: EventArgs
    {

        public void SetSelectedButton(Button button)
        {
            button.BackColor = Color.FromArgb(0, 111, 156);
        }

        public void SetUnselectedButton(Button button)
        {
            button.BackColor = Color.FromArgb(0, 120, 215);

        }

        public void SetUnselectedButtons(List<Button> buttons)
        {
            foreach (var btn in buttons)
            {
                btn.BackColor = Color.FromArgb(0, 120, 215);
            }


        }

        public void SetPictureSelectedButton(Button button, PictureBox pictureBox)
        {
            Point pictureLocation = new Point(button.Location.X + button.Width, button.Location.Y);

            pictureBox.Location = pictureLocation;
        }

        public void PictureBoxVisibilityEventArgs(bool visible)
        {
            this.Visibility = visible;
        }

        public bool Visibility { get; private set; }
    }

    public delegate void UpdateParentButtonVisibilityEventHandler(object sender, ButtonHelper args);
}
