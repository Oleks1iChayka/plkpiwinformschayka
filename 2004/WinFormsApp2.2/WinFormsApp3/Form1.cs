using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        const int mapSize = 10;
        const int cellSize = 35;
        const int minesCount = 12;

        int[,] map = new int[mapSize, mapSize];
        Button[,] buttons = new Button[mapSize, mapSize];
        int cellsOpened = 0;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Сапер";

            this.KeyPreview = true;

            StartNewGame();
        }

        private void StartNewGame()
        {
            this.Controls.Clear();
            cellsOpened = 0;
            Array.Clear(map, 0, map.Length);

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(cellSize, cellSize);
                    btn.Location = new Point(j * cellSize, i * cellSize);
                    btn.Tag = new Point(i, j);
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Standard;

                    btn.Click += OnCellClick;

                    buttons[i, j] = btn;
                    this.Controls.Add(btn);
                }
            }

            PlaceMines();
            CalculateNumbers();
        }

        private void PlaceMines()
        {
            Random rnd = new Random();
            int placed = 0;
            while (placed < minesCount)
            {
                int x = rnd.Next(mapSize);
                int y = rnd.Next(mapSize);
                if (map[x, y] != -1)
                {
                    map[x, y] = -1;
                    placed++;
                }
            }
        }

        private void CalculateNumbers()
        {
            for (int i = 0; i < mapSize; i++)
                for (int j = 0; j < mapSize; j++)
                    if (map[i, j] != -1)
                        map[i, j] = CountAround(i, j);
        }

        private int CountAround(int x, int y)
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                    if (i >= 0 && i < mapSize && j >= 0 && j < mapSize && map[i, j] == -1)
                        count++;
            return count;
        }

        private void OnCellClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Point p = (Point)btn.Tag;

            if (map[p.X, p.Y] == -1)
            {
                btn.BackColor = Color.Red;
                btn.Text = "b";
                MessageBox.Show("Ой! Це була міна.");
                StartNewGame();
            }
            else
            {
                OpenCell(p.X, p.Y);
                CheckWin();
            }
        }

        private void OpenCell(int x, int y)
        {
            if (x < 0 || x >= mapSize || y < 0 || y >= mapSize || !buttons[x, y].Enabled) return;

            buttons[x, y].Enabled = false;
            buttons[x, y].BackColor = Color.WhiteSmoke;
            cellsOpened++;

            if (map[x, y] > 0)
            {
                buttons[x, y].Text = map[x, y].ToString();
                if (map[x, y] == 1) buttons[x, y].ForeColor = Color.Blue;
                if (map[x, y] == 2) buttons[x, y].ForeColor = Color.Green;
                if (map[x, y] >= 3) buttons[x, y].ForeColor = Color.DarkRed;
            }
            else
            {
                for (int i = x - 1; i <= x + 1; i++)
                    for (int j = y - 1; j <= y + 1; j++)
                        OpenCell(i, j);
            }
        }

        private void CheckWin()
        {
            if (cellsOpened == (mapSize * mapSize) - minesCount)
            {
                MessageBox.Show("Перемога! Ви розмінували поле.");
                StartNewGame();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.R)
            {
                StartNewGame();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}