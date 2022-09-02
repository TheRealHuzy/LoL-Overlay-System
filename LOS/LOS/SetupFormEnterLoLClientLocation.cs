namespace LOS
{
    public partial class SetupFormEnterLoLClientLocation : Form
    {
        public string returnValue { get; set; }

        public SetupFormEnterLoLClientLocation()
        {
            InitializeComponent();
        }

        private void EnterLoLClientLocation_Load(object sender, EventArgs e)
        {
            this.Text = GlobalContainer.Main.thisApplicationName;
            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = Color.AliceBlue;
            this.StartPosition = FormStartPosition.Manual;

            button1.BackColor = Color.AliceBlue;

            int x = Screen.PrimaryScreen.Bounds.Width / 2 - 135;
            int y = Screen.PrimaryScreen.Bounds.Height / 2 + 30;
            this.Location = new Point(x, y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.returnValue = textBox1.Text;
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.exe)|*.exe";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = open.FileName;
            }
        }

        private void btnBrowse_MouseEnter(object sender, EventArgs e) {btnBrowse.FlatAppearance.BorderColor = Color.CornflowerBlue; }
        private void btnBrowse_MouseHover(object sender, EventArgs e) {btnBrowse.FlatAppearance.BorderColor = Color.CornflowerBlue; }
        private void btnBrowse_MouseLeave(object sender, EventArgs e) {btnBrowse.FlatAppearance.BorderColor = Color.White; }

        private void button1_MouseEnter(object sender, EventArgs e) { button1.FlatAppearance.BorderColor = Color.CornflowerBlue; button1.BackColor = Color.Black; }
        private void button1_MouseHover(object sender, EventArgs e) { button1.FlatAppearance.BorderColor = Color.CornflowerBlue; button1.BackColor = Color.Black; }
        private void button1_MouseLeave(object sender, EventArgs e) { button1.FlatAppearance.BorderColor = Color.White; button1.BackColor = Color.AliceBlue; }
    }
}
