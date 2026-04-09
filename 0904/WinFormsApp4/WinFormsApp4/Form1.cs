namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Red;

        }
        private void button1_Click2(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Red;
            if (textBox1.BackColor == Color.Red)
            {
                textBox1.BackColor = Color.Green;
            }
        }
         
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
