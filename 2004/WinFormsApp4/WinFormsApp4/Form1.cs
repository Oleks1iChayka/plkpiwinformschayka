namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int maxX = this.ClientSize.Width - button1.Width;
            int maxY = this.ClientSize.Height - button1.Height;

            button1.Left = rnd.Next(0, maxX);
            button1.Top = rnd.Next(0, maxY);
        }
    }
}
