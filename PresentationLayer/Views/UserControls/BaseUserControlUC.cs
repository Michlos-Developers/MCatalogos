using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public class BaseUserControlUC : UserControl
    {
        public AnchorStyles SetAnchorStylesTopBottomLeftRight()
        {
            return ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left)| AnchorStyles.Right)));
        }
        public void SetParentSizeLocationAnchor(Panel parentPanel)
        {
            Parent = parentPanel;
            Height = parentPanel.Height;
            Width = parentPanel.Width;
            Location = new Point(0, 0);
            Anchor = SetAnchorStylesTopBottomLeftRight();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseUserControlUC
            // 
            this.Name = "BaseUserControlUC";
            this.Size = new System.Drawing.Size(173, 169);
            this.ResumeLayout(false);

        }
    }
}
