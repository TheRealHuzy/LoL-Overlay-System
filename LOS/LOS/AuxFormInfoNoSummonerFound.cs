namespace LOS
{
    public partial class AuxFormInfoNoSummonerFound : Form
    {
        public int returnValue;
        private string summonerName;
        private string apiKey;
        public AuxFormInfoNoSummonerFound(string summonerName, string apiKey)
        {
            InitializeComponent();
            this.summonerName = summonerName;
            this.apiKey = apiKey;
        }

        private void RunClientWarning_Load(object sender, EventArgs e)
        {
            this.Text = GlobalContainer.Main.thisApplicationName;
            lblTitle.Parent = pictureBox1;
            lblTitle.BackColor = Color.Transparent;
            lblMessage.Parent = pictureBox1;
            lblMessage.BackColor = Color.Transparent;
            tbxSummonerName.Parent = pictureBox1;
            tbxApiKey.Parent = pictureBox1;

            tbxSummonerName.Cursor = Cursors.Arrow;
            tbxApiKey.Cursor = Cursors.Arrow;

            tbxSummonerName.Text = summonerName;
            tbxApiKey.Text = apiKey;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            returnValue = 1;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            returnValue = 2;
            this.Close();
        }
        private void btnNewSummonerName_Click(object sender, EventArgs e)
        {
            returnValue = 3;
            this.Close();
        }

        private void btnNewAPIKey_Click(object sender, EventArgs e)
        {
            returnValue = 4;
            this.Close();
        }

        private void btnNewSummonerName_MouseEnter(object sender, EventArgs e) { btnNewSummonerName.FlatAppearance.BorderColor = Color.White; btnNewSummonerName.FlatAppearance.BorderSize = 1; }
        private void btnNewSummonerName_MouseHover(object sender, EventArgs e) { btnNewSummonerName.FlatAppearance.BorderColor = Color.White; btnNewSummonerName.FlatAppearance.BorderSize = 1; }
        private void btnNewSummonerName_MouseLeave(object sender, EventArgs e) { btnNewSummonerName.FlatAppearance.BorderSize = 0; }

        private void btnNewAPIKey_MouseEnter(object sender, EventArgs e) { btnNewAPIKey.FlatAppearance.BorderColor = Color.White; btnNewAPIKey.FlatAppearance.BorderSize = 1; }
        private void btnNewAPIKey_MouseHover(object sender, EventArgs e) { btnNewAPIKey.FlatAppearance.BorderColor = Color.White; btnNewAPIKey.FlatAppearance.BorderSize = 1; }
        private void btnNewAPIKey_MouseLeave(object sender, EventArgs e) { btnNewAPIKey.FlatAppearance.BorderSize = 0; }

        private void btnOK_MouseEnter(object sender, EventArgs e) { btnOK.FlatAppearance.BorderColor = Color.CornflowerBlue; }
        private void btnOK_MouseHover(object sender, EventArgs e) { btnOK.FlatAppearance.BorderColor = Color.CornflowerBlue; }
        private void btnOK_MouseLeave(object sender, EventArgs e) { btnOK.FlatAppearance.BorderColor = Color.White; }

        private void btnExit_MouseEnter(object sender, EventArgs e) { btnExit.FlatAppearance.BorderColor = Color.White; btnExit.FlatAppearance.BorderSize = 1; }
        private void btnExit_MouseHover(object sender, EventArgs e) { btnExit.FlatAppearance.BorderColor = Color.White; btnExit.FlatAppearance.BorderSize = 1; }
        private void btnExit_MouseLeave(object sender, EventArgs e) { btnExit.FlatAppearance.BorderSize = 0; }
    }
}
