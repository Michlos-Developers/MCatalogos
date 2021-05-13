using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCatalogos.UserControls
{
    public class BaseUserControlUC : UserControl
    {
        public AnchorStyles SetAnchorStylesTopBottomLeftRight()
        {
            return ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                    | AnchorStyles.Left)
                    | AnchorStyles.Right)));
        }

        public void SetParentSizeLocationAnchor(Panel parentPanel)
        {
            Parent = parentPanel;
            Height = parentPanel.Height;
            Width = parentPanel.Width;
            Location = new Point(0, 0);
            Anchor = SetAnchorStylesTopBottomLeftRight();
        }
    }
}
