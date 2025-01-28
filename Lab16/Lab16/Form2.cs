using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab16
{

    public partial class Form2 : Form
    {
        public int Speed { get; private set; }
        public int Year { get; private set; }
        public string Addition { get; private set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp1 = textBox1.Text;
            string temp2 = textBox2.Text;
            Addition = textBox3.Text;

            if (string.IsNullOrEmpty(temp1) || string.IsNullOrEmpty(temp2) || string.IsNullOrEmpty(Addition))
            {
                MessageBox.Show("Поле пустое", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (int.TryParse(temp1, out int speed) && int.TryParse(temp2, out int year))
                {
                    Speed = speed;
                    Year = year;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Некорректное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
