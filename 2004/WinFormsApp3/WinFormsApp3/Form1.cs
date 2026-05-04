namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            private void btnRunaway_MouseEnter(object sender, EventArgs e)
        {
            // Створюємо генератор випадкових чисел
            Random rnd = new Random();

            // Обчислюємо максимальні межі, щоб кнопка не вилізла за краї форми
            // Формула: Ширина/Висота форми мінус відповідний розмір кнопки
            int maxX = this.ClientSize.Width - btnRunaway.Width;
            int maxY = this.ClientSize.Height - btnRunaway.Height;

            // Встановлюємо нові випадкові координати
            btnRunaway.Left = rnd.Next(0, maxX);
            btnRunaway.Top = rnd.Next(0, maxY);
        }
    }
    }
}
