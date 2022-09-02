namespace LOS
{
    public partial class SetupFormEnterApiKey : Form
    {
        public string returnValue { get; set; }
        private string apiKey = "";
        private bool isPlaceHolder;

        public SetupFormEnterApiKey(string apiKey, bool isPlaceHolder = false)
        {
            InitializeComponent();
            this.apiKey = apiKey;
            this.isPlaceHolder = isPlaceHolder;
        }

        private void EnterApiKey_Load(object sender, EventArgs e)
        {
            this.Text = GlobalContainer.Main.thisApplicationName;
            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = Color.AliceBlue;
            this.StartPosition = FormStartPosition.Manual;

            button1.BackColor = Color.AliceBlue;

            int x = Screen.PrimaryScreen.Bounds.Width / 2 - 135;
            int y = Screen.PrimaryScreen.Bounds.Height / 2 + 30;
            this.Location = new Point(x, y);

            if (!isPlaceHolder) textBox1.Text = apiKey;
            else textBox1.PlaceholderText = apiKey;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.CompareTo("") == 0) setPlaceholder();
            else
            {
                this.returnValue = textBox1.Text;
                textBox1.Text = "";
                this.Close();
            }
        }

        public void setPlaceholder()
        {
            textBox1.PlaceholderText = GlobalContainer.PlaceholderMessages.APIKeyFirstNullOnSet;
        }

        private void button1_MouseEnter(object sender, EventArgs e) { button1.FlatAppearance.BorderColor = Color.CornflowerBlue; button1.BackColor = Color.Black; }
        private void button1_MouseHover(object sender, EventArgs e) { button1.FlatAppearance.BorderColor = Color.CornflowerBlue; button1.BackColor = Color.Black; }
        private void button1_MouseLeave(object sender, EventArgs e) { button1.FlatAppearance.BorderColor = Color.White; button1.BackColor = Color.AliceBlue; }
    }
}
