using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class MainForm : Form
    {
        private const int GridSize = 5;
        private const int MineCount = 5;
        private Button[,] buttons = new Button[GridSize, GridSize];
        private bool[,] mines = new bool[GridSize, GridSize];

        public MainForm()
        {
            this.Text = "Простий Сапер (5x5)";
            this.Size = new Size(300, 350);
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Очищення поля, якщо гра перезапускається
            this.Controls.Clear();

            Random rnd = new Random();
            int placedMines = 0;

            // Генерація мін
            while (placedMines < MineCount)
            {
                int r = rnd.Next(GridSize);
                int c = rnd.Next(GridSize);
                if (!mines[r, c])
                {
                    mines[r, c] = true;
                    placedMines++;
                }
            }

            // Створення кнопок
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Size = new Size(50, 50),
                        Location = new Point(i * 50 + 20, j * 50 + 20),
                        Tag = new Point(i, j), // Зберігаємо координати в Tag
                        Font = new Font("Arial", 12, FontStyle.Bold)
                    };

                    buttons[i, j].Click += Button_Click;
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Point p = (Point)btn.Tag;

            if (mines[p.X, p.Y])
            {
                btn.Text = "b";
                btn.BackColor = Color.Red;
                MessageBox.Show("БАБАХ! Ви програли.", "Кінець гри");
                ResetGame();
            }
            else
            {
                btn.Text = "✓";
                btn.BackColor = Color.LightGray;
                btn.Enabled = false; // Вимикаємо кнопку після успішного ходу
            }
        }

        private void ResetGame()
        {
            mines = new bool[GridSize, GridSize];
            InitializeGame();
        }
    }
}

