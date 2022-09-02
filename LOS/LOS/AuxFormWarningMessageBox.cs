namespace LOS
{
    public partial class AuxFormWarningMessageBox : Form
    {
        public int returnValue;
        private string message;
        private string button1Text;
        private string button2Text;
        public AuxFormWarningMessageBox(string message, string button1Text = "OK", string button2Text = "Exit")
        {
            InitializeComponent();
            this.message = message;
            this.button1Text = button1Text;
            this.button2Text = button2Text;
        }

        private void RunClientWarning_Load(object sender, EventArgs e)
        {
            this.Text = GlobalContainer.Main.thisApplicationName;
            lblTitle.Parent = pictureBox1;
            lblTitle.BackColor = Color.Transparent;
            lblMessage.Parent = pictureBox1;
            lblMessage.BackColor = Color.Transparent;

            lblMessage.Text = message;
            btnOK.Text = button1Text;
            btnExit.Text = button2Text;
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

        private void btnOK_MouseEnter(object sender, EventArgs e) { btnOK.FlatAppearance.BorderColor = Color.CornflowerBlue; }
        private void btnOK_MouseHover(object sender, EventArgs e) { btnOK.FlatAppearance.BorderColor = Color.CornflowerBlue; }
        private void btnOK_MouseLeave(object sender, EventArgs e) { btnOK.FlatAppearance.BorderColor = Color.White; }

        private void btnExit_MouseEnter(object sender, EventArgs e) { btnExit.FlatAppearance.BorderColor = Color.White; btnExit.FlatAppearance.BorderSize = 1; }
        private void btnExit_MouseHover(object sender, EventArgs e) { btnExit.FlatAppearance.BorderColor = Color.White; btnExit.FlatAppearance.BorderSize = 1; }
        private void btnExit_MouseLeave(object sender, EventArgs e) { btnExit.FlatAppearance.BorderSize = 0; }
    }
}
