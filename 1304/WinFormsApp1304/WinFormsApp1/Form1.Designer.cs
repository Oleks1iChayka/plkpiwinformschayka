namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            label1 = new Label();
            button11 = new Button();
            button12 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(78, 71);
            button1.Name = "button1";
            button1.Size = new Size(108, 23);
            button1.TabIndex = 0;
            button1.Text = "Тікаюча кнопка";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(472, 71);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = true;
            button2.Click += GameButtonClick;
            // 
            // button3
            // 
            button3.Location = new Point(570, 71);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.UseVisualStyleBackColor = true;
            button3.Click += GameButtonClick;
            // 
            // button4
            // 
            button4.Location = new Point(667, 71);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 3;
            button4.UseVisualStyleBackColor = true;
            button4.Click += GameButtonClick;
            // 
            // button5
            // 
            button5.Location = new Point(472, 121);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 4;
            button5.UseVisualStyleBackColor = true;
            button5.Click += GameButtonClick;
            // 
            // button6
            // 
            button6.Location = new Point(570, 121);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 5;
            button6.UseVisualStyleBackColor = true;
            button6.Click += GameButtonClick;
            // 
            // button7
            // 
            button7.Location = new Point(667, 121);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 6;
            button7.UseVisualStyleBackColor = true;
            button7.Click += GameButtonClick;
            // 
            // button8
            // 
            button8.Location = new Point(472, 172);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 7;
            button8.UseVisualStyleBackColor = true;
            button8.Click += GameButtonClick;
            // 
            // button9
            // 
            button9.Location = new Point(570, 172);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 8;
            button9.UseVisualStyleBackColor = true;
            button9.Click += GameButtonClick;
            // 
            // button10
            // 
            button10.Location = new Point(667, 172);
            button10.Name = "button10";
            button10.Size = new Size(75, 23);
            button10.TabIndex = 9;
            button10.UseVisualStyleBackColor = true;
            button10.Click += GameButtonClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(557, 26);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 10;
            label1.Text = "хрестики нолики";
            label1.Click += label1_Click;
            // 
            // button11
            // 
            button11.Location = new Point(42, 273);
            button11.Name = "button11";
            button11.Size = new Size(75, 23);
            button11.TabIndex = 11;
            button11.Text = "Open";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(264, 273);
            button12.Name = "button12";
            button12.Size = new Size(75, 23);
            button12.TabIndex = 12;
            button12.Text = "Save";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(42, 333);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(297, 23);
            textBox1.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 540);
            Controls.Add(textBox1);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(label1);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Label label1;
        private Button button11;
        private Button button12;
        private TextBox textBox1;
    }
}
