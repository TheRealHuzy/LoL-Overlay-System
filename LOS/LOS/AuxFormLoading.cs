namespace LOS
{
    public partial class AuxFormLoading : Form
    {
        public AuxFormLoading()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = GlobalContainer.Main.thisApplicationName;
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label1.Visible = false;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            this.TopMost = true;
        }
    }
}