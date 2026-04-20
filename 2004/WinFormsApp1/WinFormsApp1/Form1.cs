using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<string> memes = new List<string>();
        private int currentMeme = 0;

        public Form1()
        {
            InitializeComponent();

            button1.Click += (s, e) => PrevMeme();
            button2.Click += (s, e) => NextMeme();

            button1.TabStop = false;
            button2.TabStop = false;

            LoadMemes();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Right)
            {
                NextMeme();
                return true;
            }
            if (keyData == Keys.Left)
            {
                PrevMeme();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoadMemes()
        {
            string path = Path.Combine(Application.StartupPath, "memes");

            if (Directory.Exists(path))
            {
                memes.AddRange(Directory.GetFiles(path, "*.jpg"));
                memes.AddRange(Directory.GetFiles(path, "*.png"));
                memes.AddRange(Directory.GetFiles(path, "*.jpeg"));

                if (memes.Count > 0) ShowMeme(0);
            }
            else
            {
                Directory.CreateDirectory(path);
                MessageBox.Show("Створено папку 'memes'. Закинь туди фото!");
            }
        }

        private void ShowMeme(int index)
        {
            if (pictureBox1 != null && memes.Count > 0)
            {
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();

                pictureBox1.Image = Image.FromFile(memes[index]);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                currentMeme = index;
            }
        }

        private void NextMeme()
        {
            if (memes.Count == 0) return;
            currentMeme = (currentMeme + 1) % memes.Count;
            ShowMeme(currentMeme);
        }

        private void PrevMeme()
        {
            if (memes.Count == 0) return;
            currentMeme--;
            if (currentMeme < 0) currentMeme = memes.Count - 1;
            ShowMeme(currentMeme);
        }
        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;

        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(174, 393);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(374, 393);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(221, 87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 248);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            ClientSize = new Size(597, 544);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }
    }
}