namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int vart = Convert.ToInt32(textBox1.Text); 
            int kilk = Convert.ToInt32(textBox2.Text);
            int suma = vart * kilk;
            MessageBox.Show("¬арт≥сть: " + suma);
            if (suma > 1000)
            {
                MessageBox.Show("¬арт≥сть>1000");
                
            }
        }
    }
}
