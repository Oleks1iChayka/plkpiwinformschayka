namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number = int.Parse(textBox1.Text);
            if (number >= 10 && number <= 100)
            {
                MessageBox.Show("×èñëî â ä³àïàçîí³ â³ä 10 äî 100");
            }
            else
            {
                MessageBox.Show("×èñëî íå â ä³àïàçîí³ â³ä 10 äî 100");
            }
        }
    }
}
