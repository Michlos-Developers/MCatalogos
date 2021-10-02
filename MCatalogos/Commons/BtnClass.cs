using System.Drawing;
using System.Windows.Forms;

namespace MCatalogos.Commons
{
    public class BtnClass
    {
        public Button generateButtons(string text, string tag)
        {
            Button btnDefault = new Button();
            ToolTip toolTipBtn = new ToolTip();
            toolTipBtn.Tag = tag;
            btnDefault.Text = text;
            btnDefault.Tag = tag;
            btnDefault.Dock = DockStyle.Top;
            btnDefault.Margin = new Padding(3, 3, 3, 3);
            btnDefault.Size = new Size(165, 47);
            btnDefault.TextAlign = ContentAlignment.MiddleRight;
            btnDefault.BackColor = Color.FromArgb(0, 120, 215);
            btnDefault.FlatStyle = FlatStyle.Flat;

            return btnDefault;
        }
    }
}
