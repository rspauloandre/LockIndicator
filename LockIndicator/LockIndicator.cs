using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockIndicator
{
    public partial class LockIndicator : Form
    {
        public LockIndicator()
        {
            InitializeComponent();
        }

        int windowHeight = 10;
        int windowWidth = 90;
        int windowRightIndent = 140;
        int windowActiveHeight = 32;

        Color ActiveColor = Color.White;
        Color PassiveColor = Color.FromArgb(132, 151, 176);
        Color LightRedColor = Color.FromArgb(255, 215, 0);

        private void LockIndicator_Load(object sender, EventArgs e)
        {
            this.Height = windowHeight;
            this.Width = windowWidth;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - windowWidth - windowRightIndent, 0);
            this.TopMost = true;

            KeyLockController();
        }

        private void LockIndicator_Activated(object sender, EventArgs e)
        {
            ShowIcons();
            label_close.BackColor = LightRedColor;
        }

        private void LockIndicator_Deactivate(object sender, EventArgs e)
        {
            HideIcons();
        }

        private void ShowIcons()
        {
            this.Height = windowActiveHeight;
        }

        private  void HideIcons()
        {
            this.Height = windowHeight;
        }

        private void label_closeIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void KeyLockController()
        {
            while (true)
            {
                label_capsLock.BackColor = Control.IsKeyLocked(Keys.CapsLock) ? ActiveColor : PassiveColor;
                label_numLock.BackColor = Control.IsKeyLocked(Keys.NumLock) ? ActiveColor : PassiveColor;
                label_scrollLock.BackColor = Control.IsKeyLocked(Keys.Scroll) ? ActiveColor : PassiveColor;
                await Task.Delay(100);
            }
        }

        private void label_numLockIcon_Click(object sender, EventArgs e)
        {

        }
    }
}
