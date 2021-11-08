using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MCatalogos.Commons
{
    public class ButtonHelper: EventArgs
    {
        public Button GenerateButtons(string text, int tag)
        {
            Button button = new Button();
            ToolTip toolTip = new ToolTip();
            button = ImageButton(button, tag);
            toolTip.Tag = text;
            button.Text = text;
            button.Tag = tag;
            button.Dock = DockStyle.Top;
            button.Margin = new Padding(3, 3, 3, 3);
            button.Size = new Size(165, 47);
            button.TextAlign = ContentAlignment.MiddleRight;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.BackColor = Color.FromArgb(0, 120, 215);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;

            return button;

        }

        private Button ImageButton(Button button, int tag)
        {
            switch (tag)
            {
                case 1:
                    button.Image = Properties.Resources.IconPedido35x35;
                    break;
                case 2:
                    button.Image = Properties.Resources.IconVendedora35x35;
                    break;
                case 3:
                    button.Image = Properties.Resources.iconFornecedor35X35;
                    break;
                case 4:
                    button.Image = Properties.Resources.IconCatalogo35x35;
                    break;
                case 5:
                    button.Image = Properties.Resources.IconProduto35x35;
                    break;
                case 6:
                    button.Image = Properties.Resources.IconFinanceiro35x35;
                    break;
                case 7:
                    button.Image = Properties.Resources.IconEstoque35x35;
                    break;
                case 8:
                    button.Image = Properties.Resources.IconRotas35x35;
                    break;
                case 9:
                    button.Image = Properties.Resources.IconReport35x35;
                    break;
                case 10:
                    button.Image = Properties.Resources.IconConfig35x35;
                    break;
            }
            return button;
        }

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

        public void SetDesabledButtons(List<Button> buttons, Button buttonEnabled)
        {
            foreach (var btn in buttons)
            {
                if (btn != buttonEnabled)
                {
                    btn.Enabled = false;
                }
            }
        }

        public void SetEnabledButtons(List<Button> buttons)
        {
            foreach (var btn in buttons)
            {
                btn.Enabled = true;
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
