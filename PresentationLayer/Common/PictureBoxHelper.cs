using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Common
{
    public static class PictureBoxHelper
    {
        public static void SetClickableBehavior(PictureBox pictureBox)
        {
            pictureBox.MouseMove += new MouseEventHandler(OnPictureBoxMouseMoveEventRaised);
            pictureBox.MouseLeave += new EventHandler(OnPictureBoxMouseLeaveEventRaised);
        }
        private static void OnPictureBoxMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private static void OnPictureBoxMouseLeaveEventRaised(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }


        public static void DisplayContextMenu(PictureBox pictureBox, ContextMenuStrip contextMenuStrip, Form form)
        {
            Point pointForContextMenu = form.PointToScreen(
                new Point(pictureBox.Location.X + 30 +  contextMenuStrip.Width + pictureBox.Width,
                          pictureBox.Location.Y + pictureBox.Height));

            contextMenuStrip.Show(pointForContextMenu.X, pointForContextMenu.Y);
        }
    }
}
