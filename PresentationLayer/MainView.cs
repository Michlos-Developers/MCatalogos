using CommonComponents;

using PresentationLayer.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MainView : Form, IMainView
    {
        public event EventHandler MainViewLoadedEventRaised;
        public event EventHandler VendedoraListBtnClickEventRaised;
        public event EventHandler HelpAboutMenuClickEventRaised;

        private Point _userControlPanelMovingLocation;
        private int _userControlPanelTimerLoopCount             = 0;
        private const int _userControlPanelStretchIncrement     = 55;
        private const int _userControlPanelEndingStretchTopYPos = 60;

        private Panel _userControlPanelOrigValues = null;

        private List<Button> NavigationButtonList = null;

        public MainView()
        {
            InitializeComponent();
        }

        public Button GetUserInfoPictureBox()
        {
            return UserBtn;
        }
        public Panel GetOptionsPanel()
        {
            return optionsPanel;
        }
        public void ResetUserControlPanelSizeAndLocation()
        {
            userControlPanel.Height = _userControlPanelOrigValues.Height;
            userControlPanel.Width = _userControlPanelOrigValues.Width;
            userControlPanel.Location = _userControlPanelOrigValues.Location;
            SetVisibilityOfControlsForPanelSliding(true);
        }
        public void ShowMainVeiw()
        {
            this.Show();
        }

        public void ExpandUserControlPanel()
        {
            SetVisibilityOfControlsForPanelSliding(false);

            VendedoraDetailTimer.Enabled = true;
        }

        public Panel GetUserControlPanel()
        {
            return userControlPanel;
        }

        private void SetVisibilityOfControlsForPanelSliding(bool visibility)
        {
            ButtonHelper.SetVisibilityOfButtons(NavigationButtonList, visibility, underlineLabel: null);
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            NavigationButtonList = new List<Button>() { VendedorasBtn, UserBtn };
            ButtonHelper.SetGroupToBorderless(NavigationButtonList);

            PictureBoxHelper.SetClickableBehavior(pictureMenu);

            _userControlPanelOrigValues = new Panel();

            _userControlPanelOrigValues.Height = userControlPanel.Height;
            _userControlPanelOrigValues.Width= userControlPanel.Width;
            _userControlPanelOrigValues.Location = new Point(userControlPanel.Location.X, userControlPanel.Location.Y);

            //TODO: Lembrar de fazer isso com os demais botões
            ButtonHelper.SetUnselectedButton(VendedorasBtn);

            FormHelper.SetFormAppearance(this);
            
            EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: MainViewLoadedEventRaised, eventArgs: e);

        }

        private void VendedorasBtn_Click(object sender, EventArgs e)
        {
            //EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: VendedorasBtnClickEventRaised, eventArgs: e);
            EventHelpers.RaiseEvent(this, VendedoraListBtnClickEventRaised, e);
            
            //ButtonHelper.SetUnselectedButton(<btnname>); //fazer isso com os outros botões
            ButtonHelper.SetSelectedButton(VendedorasBtn);
        }
        private void vendedoraDetailTimer_Tick(object sender, EventArgs e)
        {
            if (_userControlPanelTimerLoopCount == 0)
            {
                _userControlPanelTimerLoopCount++;
                userControlPanel.Location = new Point(5, this.Height);

                _userControlPanelMovingLocation = new Point(_userControlPanelOrigValues.Location.X,
                    _userControlPanelOrigValues.Location.Y);
            }

            if (_userControlPanelMovingLocation.Y > _userControlPanelEndingStretchTopYPos)
            {
                _userControlPanelMovingLocation.Y = _userControlPanelMovingLocation.Y - _userControlPanelStretchIncrement;
                userControlPanel.Location = _userControlPanelMovingLocation;
                userControlPanel.Height += _userControlPanelStretchIncrement;
            }
            else
            {
                _userControlPanelTimerLoopCount = 0;
                VendedoraDetailTimer.Enabled = false;
            }
        }
        private void pictureMenu_Click(object sender, EventArgs e)
        {
            PictureBoxHelper.DisplayContextMenu(pictureMenu, moreOptionContextMenuStrip, this);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, HelpAboutMenuClickEventRaised, e);
        }
        
        
        
        private void UserBtn_Click(object sender, EventArgs e)
        {
            /*UserInfoView userInfoView = new UserInfoView(this);
             * userInfoView.ShowDialog();
             */
        }
        
        
        


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void pictureLogo_Click(object sender, EventArgs e)
        {
            //PictureBoxHelper.DisplayContextMenu(pictureLogo, ContextMenuStrip, this);
        }

    }
}
