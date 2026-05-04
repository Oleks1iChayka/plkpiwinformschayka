namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        int index = 1;
        int totalMemes = 3; // —к≥льки у тебе картинок у папц≥
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index++;
            if (index > totalMemes) index = 1; // якщо картинки зак≥нчилис€, йдемо на першу

            // ¬икликаЇмо оновленн€ картинки
            ShowMeme();
        }
        private void ShowMeme()
        {
            // ÷ей р€док шукаЇ файл за номером 1, 2 або 3 у папц≥ з програмою
            string[] files = System.IO.Directory.GetFiles(Application.StartupPath, index + ".*");
            if (files.Length > 0)
            {
                pictureBox1.ImageLocation = files[0];
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
