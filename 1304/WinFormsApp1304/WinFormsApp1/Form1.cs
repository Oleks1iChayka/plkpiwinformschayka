namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isXTurn = true;
        int stepCount = 0;

        string currentFilePath = "";
        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            button1.Location = new Point(random.Next(0, this.ClientSize.Width - button1.Width), random.Next(0, this.ClientSize.Height - button1.Height));

        }

        private void GameButtonClick(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            if (isXTurn)
                btn.Text = "X";
            else
                btn.Text = "O";


            isXTurn = !isXTurn;


            btn.Enabled = false;
            stepCount++;


            CheckWinner();
        }
        private void CheckWinner()
        {
            bool winnerFound = false;


            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled)) winnerFound = true;
            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (!button4.Enabled)) winnerFound = true;
            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (!button7.Enabled)) winnerFound = true;


            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled)) winnerFound = true;
            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled)) winnerFound = true;
            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled)) winnerFound = true;


            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled)) winnerFound = true;
            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (!button3.Enabled)) winnerFound = true;

            if (winnerFound)
            {
                string finalWinner = isXTurn ? "O" : "X";
                MessageBox.Show("Переміг гравець: " + finalWinner, "Кінець гри!");
                ResetGame();
            }
            else if (stepCount == 9)
            {
                MessageBox.Show("Нічия!", "Кінець гри!");
                ResetGame();
            }
        }
        private void ResetGame()
        {
            isXTurn = true;
            stepCount = 0;

            button1.Text = ""; button1.Enabled = true;
            button2.Text = ""; button2.Enabled = true;
            button3.Text = ""; button3.Enabled = true;
            button4.Text = ""; button4.Enabled = true;
            button5.Text = ""; button5.Enabled = true;
            button6.Text = ""; button6.Enabled = true;
            button7.Text = ""; button7.Enabled = true;
            button8.Text = ""; button8.Enabled = true;
            button9.Text = ""; button9.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text files (*.txt)|*.txt";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFile.FileName);
                currentFilePath = openFile.FileName;
                this.Text = "File: " + Path.GetFileName(currentFilePath);

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                File.WriteAllText(currentFilePath, textBox1.Text);
                MessageBox.Show("Файл збережено: " ,"Success!");
            }
            else
            {
                MessageBox.Show("Немає відкритого файлу для збереження.");
            }   
        }
    }
}

