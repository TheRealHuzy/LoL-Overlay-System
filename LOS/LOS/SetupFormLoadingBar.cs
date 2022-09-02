using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOS
{
    public partial class SetupFormLoadingBar : Form
    {
        private int championCount = 0;
        public SetupFormLoadingBar(int championCount)
        {
            InitializeComponent();
            this.championCount = championCount;
        }

        private void SetupFormLoadingBar_Load(object sender, EventArgs e)
        {
            this.Text = GlobalContainer.Main.thisApplicationName;
            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = Color.AliceBlue;

            int x = Screen.PrimaryScreen.Bounds.Width / 2 - 135;
            int y = Screen.PrimaryScreen.Bounds.Height / 2 + 30;
            this.Location = new Point(x, y);

            pbDownloading.Maximum = championCount;
        }
        public void incrementProgressBar()
        {
            pbDownloading.Value++;
        }
    }
}
