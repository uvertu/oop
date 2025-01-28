namespace Lab16
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
            button5 = new Button();
            button7 = new Button();
            button6 = new Button();
            button4 = new Button();
            button8 = new Button();
            button9 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            listBox1 = new ListBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            button10 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button12 = new Button();
            button14 = new Button();
            label7 = new Label();
            label8 = new Label();
            button11 = new Button();
            button13 = new Button();
            button15 = new Button();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(138, 49);
            button1.TabIndex = 0;
            button1.Text = "Коллекция 1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(156, 12);
            button2.Name = "button2";
            button2.Size = new Size(138, 49);
            button2.TabIndex = 1;
            button2.Text = "Коллекция 2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 10F);
            button3.Location = new Point(12, 78);
            button3.Name = "button3";
            button3.Size = new Size(100, 49);
            button3.TabIndex = 2;
            button3.Text = "Просмотр";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 10F);
            button5.Location = new Point(118, 78);
            button5.Name = "button5";
            button5.Size = new Size(93, 49);
            button5.TabIndex = 4;
            button5.Text = "Удаление";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 10F);
            button7.Location = new Point(557, 78);
            button7.Name = "button7";
            button7.Size = new Size(114, 49);
            button7.TabIndex = 6;
            button7.Text = "Фильтрация";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 10F);
            button6.Location = new Point(482, 78);
            button6.Name = "button6";
            button6.Size = new Size(69, 49);
            button6.TabIndex = 8;
            button6.Text = "Поиск";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 10F);
            button4.Location = new Point(361, 78);
            button4.Name = "button4";
            button4.Size = new Size(115, 49);
            button4.TabIndex = 9;
            button4.Text = "Добавление";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 10F);
            button8.Location = new Point(217, 78);
            button8.Name = "button8";
            button8.Size = new Size(138, 49);
            button8.TabIndex = 10;
            button8.Text = "Корректировка";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 10F);
            button9.Location = new Point(677, 58);
            button9.Name = "button9";
            button9.Size = new Size(114, 69);
            button9.TabIndex = 11;
            button9.Text = "По году";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Машина", "Экспресс", "Поезд" });
            comboBox1.Location = new Point(249, 141);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 12;
            comboBox1.SelectedIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 141);
            label1.Name = "label1";
            label1.Size = new Size(231, 28);
            label1.TabIndex = 13;
            label1.Text = "Выберите тип элемента:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(13, 323);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(884, 164);
            listBox1.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 181);
            label2.Name = "label2";
            label2.Size = new Size(231, 28);
            label2.TabIndex = 16;
            label2.Text = "Введите ключ элемента:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(249, 185);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 27);
            textBox1.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(312, 26);
            label3.Name = "label3";
            label3.Size = new Size(256, 35);
            label3.TabIndex = 18;
            label3.Text = "Выбрана коллекция: ";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 15F);
            textBox2.Location = new Point(557, 23);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(46, 41);
            textBox2.TabIndex = 19;
            textBox2.Text = "1";
            // 
            // button10
            // 
            button10.Font = new Font("Segoe UI", 10F);
            button10.Location = new Point(797, 58);
            button10.Name = "button10";
            button10.Size = new Size(100, 69);
            button10.TabIndex = 20;
            button10.Text = "По скорости";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(715, 12);
            label4.Name = "label4";
            label4.Size = new Size(158, 35);
            label4.TabIndex = 21;
            label4.Text = "Сортировка:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(406, 141);
            label5.Name = "label5";
            label5.Size = new Size(356, 28);
            label5.TabIndex = 22;
            label5.Text = "Элементы, скорость которых больше:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(406, 181);
            label6.Name = "label6";
            label6.Size = new Size(308, 28);
            label6.TabIndex = 23;
            label6.Text = " и год выпуска которых больше:";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 12F);
            textBox3.Location = new Point(759, 138);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(138, 34);
            textBox3.TabIndex = 24;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 12F);
            textBox4.Location = new Point(715, 181);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(182, 34);
            textBox4.TabIndex = 25;
            // 
            // button12
            // 
            button12.Font = new Font("Segoe UI", 10F);
            button12.Location = new Point(12, 270);
            button12.Name = "button12";
            button12.Size = new Size(138, 34);
            button12.TabIndex = 27;
            button12.Text = "Запись в JSON";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button14
            // 
            button14.Font = new Font("Segoe UI", 10F);
            button14.Location = new Point(12, 221);
            button14.Name = "button14";
            button14.Size = new Size(138, 34);
            button14.TabIndex = 29;
            button14.Text = "Запись в XML";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(445, 232);
            label7.Name = "label7";
            label7.Size = new Size(335, 23);
            label7.TabIndex = 31;
            label7.Text = "Затраченное время (синхронный метод):";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(445, 270);
            label8.Name = "label8";
            label8.Size = new Size(344, 23);
            label8.TabIndex = 32;
            label8.Text = "Затраченное время (асинхронный метод):";
            // 
            // button11
            // 
            button11.Font = new Font("Segoe UI", 10F);
            button11.Location = new Point(156, 221);
            button11.Name = "button11";
            button11.Size = new Size(138, 34);
            button11.TabIndex = 33;
            button11.Text = "Запись в BIN";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button13
            // 
            button13.Font = new Font("Segoe UI", 10F);
            button13.Location = new Point(156, 270);
            button13.Name = "button13";
            button13.Size = new Size(138, 34);
            button13.TabIndex = 34;
            button13.Text = "Запись в TXT";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button15
            // 
            button15.Font = new Font("Segoe UI", 10F);
            button15.Location = new Point(300, 221);
            button15.Name = "button15";
            button15.Size = new Size(139, 83);
            button15.TabIndex = 35;
            button15.Text = "Чтение из файла:";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 10F);
            textBox5.Location = new Point(786, 229);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(111, 30);
            textBox5.TabIndex = 36;
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Segoe UI", 10F);
            textBox6.Location = new Point(786, 270);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(111, 30);
            textBox6.TabIndex = 37;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 498);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(button15);
            Controls.Add(button13);
            Controls.Add(button11);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button14);
            Controls.Add(button12);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button10);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button4);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(button5);
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
        private Button button5;
        private Button button7;
        private Button button6;
        private Button button4;
        private Button button8;
        private Button button9;
        private ComboBox comboBox1;
        private Label label1;
        private ListBox listBox1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Button button10;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button12;
        private Button button14;
        private Label label7;
        private Label label8;
        private Button button11;
        private Button button13;
        private Button button15;
        private TextBox textBox5;
        private TextBox textBox6;
    }
}
