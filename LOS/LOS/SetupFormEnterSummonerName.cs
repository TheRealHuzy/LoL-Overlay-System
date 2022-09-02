namespace LOS
{
    public partial class SetupFormEnterSummonerName : Form
    {
        public string returnValue { get; set; }
        private string name = "";
        public SetupFormEnterSummonerName(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void EnterSummonerName_Load(object sender, EventArgs e)
        {
            this.Text = GlobalContainer.Main.thisApplicationName;
            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = Color.AliceBlue;
            this.StartPosition = FormStartPosition.Manual;

            button1.BackColor = Color.AliceBlue;

            int x = Screen.PrimaryScreen.Bounds.Width / 2 - 135;
            int y = Screen.PrimaryScreen.Bounds.Height / 2 + 30;
            this.Location = new Point(x, y);

            textBox1.Text = name;
        }
        //delete somehow
        private void button1_Click(object sender, EventArgs e)
        {
            this.returnValue = textBox1.Text;
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.returnValue = textBox1.Text;
            this.Close();
        }
        private void button1_MouseEnter(object sender, EventArgs e) { button1.FlatAppearance.BorderColor = Color.CornflowerBlue; button1.BackColor = Color.Black; }
        private void button1_MouseHover(object sender, EventArgs e) { button1.FlatAppearance.BorderColor = Color.CornflowerBlue; button1.BackColor = Color.Black; }
        private void button1_MouseLeave(object sender, EventArgs e) { button1.FlatAppearance.BorderColor = Color.White; button1.BackColor = Color.AliceBlue; }
    }
}
