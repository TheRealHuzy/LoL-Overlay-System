namespace LOS
{
    public partial class AuxFormInfoMessageBox : Form
    {
        private string message;
        public AuxFormInfoMessageBox(string message)
        {
            InitializeComponent();
            this.message = message;
        }

        private void RunClientWarning_Load(object sender, EventArgs e)
        {
            this.Text = GlobalContainer.Main.thisApplicationName;
            lblTitle.Parent = pictureBox1;
            lblTitle.BackColor = Color.Transparent;
            lblMessage.Parent = pictureBox1;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Text = message;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_MouseEnter(object sender, EventArgs e) { btnOK.FlatAppearance.BorderColor = Color.CornflowerBlue; }
        private void btnOK_MouseHover(object sender, EventArgs e) { btnOK.FlatAppearance.BorderColor = Color.CornflowerBlue; }
        private void btnOK_MouseLeave(object sender, EventArgs e) { btnOK.FlatAppearance.BorderColor = Color.White; }
    }
}
