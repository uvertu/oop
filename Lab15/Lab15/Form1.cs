using System.Windows.Forms;

namespace Lab15
{
    public partial class Form1 : Form
    {
        Thread calculatorThread;
        Thread consoleThread;
        private static int currentCoefficient = 1;
        private static int currentPower = 0;
        private static double W = 1.0;
        private static double x = 1;
        private static AutoResetEvent calculatorEvent;
        private static AutoResetEvent consoleEvent;
        static private bool stopThread;
        static private bool paused;
        public Form1()
        {
            InitializeComponent();
            textBox2.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox3.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out x))
            {
                MessageBox.Show("Введите корректное значение.");
                return;
            }

            if (calculatorThread != null && calculatorThread.IsAlive || consoleThread != null && consoleThread.IsAlive)
            {
                MessageBox.Show("Сначала нажмите на 'Стоп'.");
                return;
            }

            textBox1.Enabled = false;


            stopThread = false;
            paused = false;

            textBox2.Text = "";
            currentCoefficient = 1;
            currentPower = 0;
            W = 1.0;

            button12.Enabled = true;
            button13.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;

            calculatorThread = new Thread(CalculatePowers);
            consoleThread = new Thread(PrintResults);

            consoleEvent = new AutoResetEvent(true);
            calculatorEvent = new AutoResetEvent(false);

            calculatorThread.Start();
            consoleThread.Start();

            textBox3.Text = calculatorThread.Priority.ToString();
            textBox4.Text = consoleThread.Priority.ToString();

        }

        private void CalculatePowers()
        {
            while (!stopThread)
            {
                if (!paused)
                {
                    textBox5.Text = calculatorThread.ThreadState.ToString();
                    calculatorEvent.WaitOne();
                    currentPower += 1;
                    W += currentCoefficient * Math.Pow(Math.Sin(x), currentPower);
                    currentCoefficient *= 2;
                    W -= currentCoefficient * Math.Pow(Math.Cos(x), currentPower);
                    currentCoefficient *= 2;
                    consoleEvent.Set();
                }
            }
        }
        private void PrintResults()
        {
            while (!stopThread)
            {
                if (!paused)
                {
                    textBox6.Text = consoleThread.ThreadState.ToString();
                    consoleEvent.WaitOne();
                    textBox2.Text = W.ToString();
                    Thread.Sleep(1000);
                    calculatorEvent.Set();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            stopThread = true;

            calculatorThread.Join();
            consoleThread.Join();

            textBox5.Text = calculatorThread.ThreadState.ToString();
            textBox6.Text = calculatorThread.ThreadState.ToString();

            button12.Enabled = false;
            button13.Enabled = false;

            textBox1.Enabled = true;
            button13.Text = "Пауза";

            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            paused = !paused;
            if (paused)
            {
                textBox5.Text = calculatorThread.ThreadState.ToString();
                textBox6.Text = calculatorThread.ThreadState.ToString();
                calculatorEvent.Reset();
                consoleEvent.Reset();
                button13.Text = "Возобновить";
            }
            else
            {
                consoleEvent.Set();
                button13.Text = "Пауза";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculatorThread.Priority = ThreadPriority.Lowest;
            textBox3.Text = calculatorThread.Priority.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calculatorThread.Priority = ThreadPriority.BelowNormal;
            textBox3.Text = calculatorThread.Priority.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            calculatorThread.Priority = ThreadPriority.Normal;
            textBox3.Text = calculatorThread.Priority.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calculatorThread.Priority = ThreadPriority.AboveNormal;
            textBox3.Text = calculatorThread.Priority.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            calculatorThread.Priority = ThreadPriority.Highest;
            textBox3.Text = calculatorThread.Priority.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            consoleThread.Priority = ThreadPriority.Lowest;
            textBox4.Text = consoleThread.Priority.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            consoleThread.Priority = ThreadPriority.BelowNormal;
            textBox4.Text = consoleThread.Priority.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            consoleThread.Priority = ThreadPriority.Normal;
            textBox4.Text = consoleThread.Priority.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            consoleThread.Priority = ThreadPriority.AboveNormal;
            textBox4.Text = consoleThread.Priority.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            consoleThread.Priority = ThreadPriority.Highest;
            textBox4.Text = consoleThread.Priority.ToString();
        }
    }
}