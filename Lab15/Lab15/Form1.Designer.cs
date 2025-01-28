namespace Lab15
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            label3 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            label4 = new Label();
            button12 = new Button();
            label5 = new Label();
            label6 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            button13 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(457, 20);
            label1.Name = "label1";
            label1.Size = new Size(149, 20);
            label1.TabIndex = 0;
            label1.Text = "Приоритет потока 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(639, 20);
            label2.Name = "label2";
            label2.Size = new Size(149, 20);
            label2.TabIndex = 1;
            label2.Text = "Приоритет потока 2";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 20F);
            textBox1.Location = new Point(356, 292);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(432, 52);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 20F);
            textBox2.Location = new Point(236, 367);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(552, 52);
            textBox2.TabIndex = 3;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 20F);
            button1.Location = new Point(12, 110);
            button1.Name = "button1";
            button1.Size = new Size(209, 73);
            button1.TabIndex = 4;
            button1.Text = "Старт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F);
            label3.Location = new Point(12, 367);
            label3.Name = "label3";
            label3.Size = new Size(218, 46);
            label3.TabIndex = 5;
            label3.Text = "Значение W:";
            // 
            // button2
            // 
            button2.Location = new Point(457, 93);
            button2.Name = "button2";
            button2.Size = new Size(149, 29);
            button2.TabIndex = 6;
            button2.Text = "Lowest";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(457, 128);
            button3.Name = "button3";
            button3.Size = new Size(149, 29);
            button3.TabIndex = 7;
            button3.Text = "BelowNormal";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(457, 163);
            button4.Name = "button4";
            button4.Size = new Size(149, 29);
            button4.TabIndex = 8;
            button4.Text = "Normal";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(457, 198);
            button5.Name = "button5";
            button5.Size = new Size(149, 29);
            button5.TabIndex = 9;
            button5.Text = "AboveNormal";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(457, 233);
            button6.Name = "button6";
            button6.Size = new Size(149, 29);
            button6.TabIndex = 10;
            button6.Text = "Highest";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(639, 233);
            button7.Name = "button7";
            button7.Size = new Size(149, 29);
            button7.TabIndex = 15;
            button7.Text = "Highest";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(639, 198);
            button8.Name = "button8";
            button8.Size = new Size(149, 29);
            button8.TabIndex = 14;
            button8.Text = "AboveNormal";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(639, 163);
            button9.Name = "button9";
            button9.Size = new Size(149, 29);
            button9.TabIndex = 13;
            button9.Text = "Normal";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(639, 128);
            button10.Name = "button10";
            button10.Size = new Size(149, 29);
            button10.TabIndex = 12;
            button10.Text = "BelowNormal";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(639, 93);
            button11.Name = "button11";
            button11.Size = new Size(149, 29);
            button11.TabIndex = 11;
            button11.Text = "Lowest";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F);
            label4.Location = new Point(12, 295);
            label4.Name = "label4";
            label4.Size = new Size(338, 46);
            label4.TabIndex = 16;
            label4.Text = "Введите значение X:";
            // 
            // button12
            // 
            button12.Font = new Font("Segoe UI", 20F);
            button12.Location = new Point(236, 110);
            button12.Name = "button12";
            button12.Size = new Size(209, 73);
            button12.TabIndex = 17;
            button12.Text = "Стоп";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(205, 20);
            label5.TabIndex = 18;
            label5.Text = "Поток 1 - расчёт, состояние:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 43);
            label6.Name = "label6";
            label6.Size = new Size(203, 20);
            label6.TabIndex = 19;
            label6.Text = "Поток 2 - вывод, состояние:";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 13F);
            textBox3.Location = new Point(457, 43);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(149, 36);
            textBox3.TabIndex = 20;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 13F);
            textBox4.Location = new Point(639, 43);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(149, 36);
            textBox4.TabIndex = 21;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(223, 6);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 22;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(223, 39);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 23;
            // 
            // button13
            // 
            button13.Font = new Font("Segoe UI", 20F);
            button13.Location = new Point(98, 198);
            button13.Name = "button13";
            button13.Size = new Size(275, 67);
            button13.TabIndex = 26;
            button13.Text = "Пауза";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button13);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button12);
            Controls.Add(label4);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(button10);
            Controls.Add(button11);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Label label3;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Label label4;
        private Button button12;
        private Label label5;
        private Label label6;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button button13;
    }
}
