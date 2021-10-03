using System.Drawing;
using System.Windows.Forms;

namespace MCatalogos.Commons
{
    public class BtnClass
    {
        
        public Button generateButtons(string text, int tag)
        {
            Button btnDefault = new Button();
            btnDefault = generateImage(btnDefault, tag);
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
            btnDefault.ForeColor = Color.White;
            btnDefault.ImageAlign = ContentAlignment.MiddleLeft;

            return btnDefault;
        }

        private Button generateImage(Button btn, int tagModulo)
        {
            
            switch (tagModulo)
            {
                case 1:
                    btn.Image = Properties.Resources.IconPedido35x35;
                    break;
                case 2:
                    btn.Image = Properties.Resources.IconVendedora35x35;
                    break;
                case 3:
                    btn.Image = Properties.Resources.iconFornecedor35X35;
                    break;
                case 4:
                    btn.Image = Properties.Resources.IconCatalogo35x35;
                    break;
                case 5:
                    btn.Image = Properties.Resources.IconProduto35x35;
                    break;
                case 6:
                    btn.Image = Properties.Resources.IconFinanceiro35x35;
                    break;
                case 7:
                    btn.Image = Properties.Resources.IconEstoque35x35;
                    break;
                case 8:
                    btn.Image = Properties.Resources.IconRotas35x35;
                    break;
                case 9:
                    btn.Image = Properties.Resources.IconReport35x35;
                    break;
                case 10:
                    btn.Image = Properties.Resources.IconConfig35x35;
                    break;
            }

            return btn;
        }

    }
}
