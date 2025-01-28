using Lab12;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab16
{
    public partial class Form1 : Form
    {
        private int collectionCount = 0;
        private ItemLinkedList<Vehicle> collection1;
        private ItemLinkedList<Vehicle> collection2;
        private List<ItemLinkedList<Vehicle>> collections;
        private Stopwatch stopwatch;
        private int selectedCollection;
        XmlSerializer xmlSerializer2;
        BinaryFormatter bf;
        public Form1()
        {
            stopwatch = new Stopwatch();
            xmlSerializer2 = new XmlSerializer(typeof(ItemLinkedList<Vehicle>));
            bf = new BinaryFormatter();
            collection1 = new ItemLinkedList<Vehicle>();
            collection2 = new ItemLinkedList<Vehicle>();
            for (int i = 0; i < 333; i++)
            {
                Car c = new Car(0, 0, "");
                c.RandomInit();
                collection2.Add(c);
                Train t = new Train(0, 0, "");
                t.RandomInit();
                collection2.Add(t);
                Express e = new Express(0, 0, "");
                e.RandomInit();
                collection2.Add(e);
            }
            collections = [collection1, collection2];
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int index = GetIndex();
            if (index > 0)
            {
                Form2 correctionForm = new Form2();
                if (correctionForm.ShowDialog() == DialogResult.OK)
                {
                    int year = correctionForm.Year;
                    int speed = correctionForm.Speed;
                    string addition = correctionForm.Addition;
                    collections[selectedCollection][index - 1].Speed = speed;
                    collections[selectedCollection][index - 1].Year = year;
                    if (collections[selectedCollection][index - 1] is Car car)
                    {
                        car.CarMake = addition;
                    }
                    if (collections[selectedCollection][index - 1] is Train train)
                    {
                        train.Company = addition;
                    }
                    if (collections[selectedCollection][index - 1] is Express express)
                    {
                        express.Route = addition;
                    }
                    MessageBox.Show("Элемент изменен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedCollection = 0;
            textBox2.Text = "1";
        }

        private int GetIndex()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (int.TryParse(textBox1.Text, out int index))
                {
                    if (index > 0 && index <= collections[selectedCollection].Count)
                    {
                        return index;
                    }
                    else
                    {
                        MessageBox.Show("Элемент не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Введите целое число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Поле пустое", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return -1;
        }

        private int GetInt(TextBox textbox)
        {
            if (!string.IsNullOrEmpty(textbox.Text))
            {
                if (int.TryParse(textbox.Text, out int value))
                {
                    if (value > 0)
                    {
                        return value;
                    }
                    else
                    {
                        MessageBox.Show("Введите значение больше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Введите целое число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Поле пустое", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return -1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (collections[selectedCollection].Count != 0)
            {
                for (int i = 0; i < collections[selectedCollection].Count; i++)
                {
                    listBox1.Items.Add((i + 1).ToString() + ". " + collections[selectedCollection][i].GetType() + ": " + collections[selectedCollection][i]);
                }
            }
            else
            {
                MessageBox.Show("Коллекция пуста", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem.ToString();
            Vehicle el = new Vehicle(0, 0);
            if (selected == "Машина")
            {
                el = new Car(0, 0, "");
            }
            if (selected == "Поезд")
            {
                el = new Train(0, 0, "");
            }
            if (selected == "Экспресс")
            {
                el = new Express(0, 0, "");
            }
            el.RandomInit();
            collections[selectedCollection].Add(el);
            MessageBox.Show("Элемент добавлен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedCollection = 1;
            textBox2.Text = "2";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = GetIndex();
            if (index > 0)
            {
                collections[selectedCollection].Remove(collections[selectedCollection][index - 1]);
                MessageBox.Show("Элемент удалён", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int index = GetIndex();
            if (index > 0)
            {
                listBox1.Items.Add((index).ToString() + ". " + collections[selectedCollection][index - 1].GetType() + ": " + collections[selectedCollection][index - 1]);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (collections[selectedCollection].Count > 0)
            {
                collections[selectedCollection].SortBySpeed();
                MessageBox.Show("Коллекция отсортирована", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Коллекция пустая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int speed = GetInt(textBox3);
            if (speed > 0)
            {
                int year = GetInt(textBox4);
                if (year > 0)
                {
                    if (collections[selectedCollection].Count > 0)
                    {
                        var listnew = new ItemLinkedList<Vehicle>();
                        listnew = collections[selectedCollection].FilterByField(vehicle => vehicle is Vehicle v && v.Speed > speed && v.Year > year);
                        for (int i = 0; i < listnew.Count; i++)
                        {
                            listBox1.Items.Add((i + 1).ToString() + ". " + listnew[i].GetType() + ": " + listnew[i]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Коллекция пустая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (collections[selectedCollection].Count > 0)
            {
                collections[selectedCollection].SortByYear();
                MessageBox.Show("Коллекция отсортирована", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Коллекция пустая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteXml()
        {
            stopwatch.Restart();
            using (FileStream fs = new FileStream("vehicles.xml", FileMode.Create))
            {
                xmlSerializer2.Serialize(fs, collections[selectedCollection]);
            }
            stopwatch.Stop();
            textBox5.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }
        private async Task WriteXmlAsync()
        {
            stopwatch.Restart();
            using (FileStream fs = new FileStream("vehiclesAsync.xml", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                await Task.Run(() => xmlSerializer2.Serialize(fs, collections[selectedCollection]));
            }
            stopwatch.Stop();
            textBox6.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }
        private async void button14_Click(object sender, EventArgs e)
        {
            if (collections[selectedCollection].Count > 0)
            {
                WriteXml();
                await WriteXmlAsync();
                MessageBox.Show("Файл записан", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Коллекция пустая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task WriteJsonAsync()
        {
            stopwatch.Restart();
            using (FileStream fs = new FileStream("vehiclesAsync.json", FileMode.Create, FileAccess.Write))
            {
                await JsonSerializer.SerializeAsync(fs, collections[selectedCollection]);
            }
            stopwatch.Stop();
            textBox6.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }

        private void WriteJson()
        {
            stopwatch.Restart();
            using (FileStream fs = new FileStream("vehicles.json", FileMode.Create))
            {
                JsonSerializer.Serialize(fs, collections[selectedCollection]);
            }
            stopwatch.Stop();
            textBox5.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            if (collections[selectedCollection].Count > 0)
            {
                WriteJson();
                await WriteJsonAsync();
                MessageBox.Show("Файл записан", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Коллекция пустая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteBin()
        {
            stopwatch.Restart();
            using (FileStream fs = new FileStream("vehicles.bin", FileMode.Create))
            {
                bf.Serialize(fs, collections[selectedCollection]);
            }
            stopwatch.Stop();
            textBox5.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }
        private async Task WriteBinAsync()
        {
            stopwatch.Restart();
            using (FileStream fs = new FileStream("vehiclesAsync.bin", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                await Task.Run(() => bf.Serialize(fs, collections[selectedCollection]));
            }
            stopwatch.Stop();
            textBox6.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }
        private async void button11_Click(object sender, EventArgs e)
        {
            if (collections[selectedCollection].Count > 0)
            {
                WriteBin();
                await WriteBinAsync();
                MessageBox.Show("Файл записан", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Коллекция пустая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task WriteTxtAsync()
        {
            stopwatch.Restart();
            using (StreamWriter sw = new StreamWriter("vehiclesAsync.txt"))
            {
                foreach (var vehicle in collections[selectedCollection])
                {
                    await sw.WriteLineAsync(vehicle.ToString());
                }
            }
            stopwatch.Stop();
            textBox6.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }
        private void WriteTxt()
        {
            stopwatch.Restart();
            using (StreamWriter sw = new StreamWriter("vehicles.txt"))
            {
                foreach (var vehicle in collections[selectedCollection])
                {
                    sw.WriteLine(vehicle.ToString());
                }
            }
            stopwatch.Stop();
            textBox5.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }
        private async void button13_Click(object sender, EventArgs e)
        {
            if (collections[selectedCollection].Count > 0)
            {
                await WriteTxtAsync();
                WriteTxt();
                MessageBox.Show("Файл записан", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Коллекция пустая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ReadFromXml(ListBox listBox, string path)
        {
            stopwatch.Restart();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                ItemLinkedList<Vehicle> listik = xmlSerializer2.Deserialize(fs) as ItemLinkedList<Vehicle>;
                if (listik != null)
                {
                    foreach (var item in listik)
                    {
                        listBox.Items.Add(item);
                    }
                }
            }
            stopwatch.Stop();
            textBox5.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }

        private async Task ReadFromXmlAsync(ListBox listBox, string path)
        {
            stopwatch.Restart();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var listik = await Task.Run(() => xmlSerializer2.Deserialize(fs) as ItemLinkedList<Vehicle>);
                if (listik != null)
                {
                    foreach (var item in listik)
                    {
                        listBox.Items.Add(item);
                    }
                }
            }
            stopwatch.Stop();
            textBox6.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }

        private async Task ReadFromJsonAsync(ListBox listbox, string path)
        {
            stopwatch.Restart();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                ItemLinkedList<Vehicle> listik = await JsonSerializer.DeserializeAsync<ItemLinkedList<Vehicle>>(fs);
                foreach (var item in listik)
                {
                    listbox.Items.Add(item.ToString());
                }
            }
            stopwatch.Stop();
            textBox6.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }

        private void ReadFromJson(ListBox listbox, string path)
        {
            stopwatch.Start();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                ItemLinkedList<Vehicle>? listik = JsonSerializer.Deserialize<ItemLinkedList<Vehicle>>(fs);
                foreach (var item in listik)
                {
                    listbox.Items.Add(item.ToString());
                }
            }
            stopwatch.Stop();
            textBox5.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }

        private void ReadFromBin(ListBox listbox, string path)
        {
            stopwatch.Restart();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                ItemLinkedList<Vehicle> listik = (ItemLinkedList<Vehicle>)bf.Deserialize(fs);
                if (listik != null)
                {
                    foreach (var item in listik)
                    {
                        listbox.Items.Add(item.ToString());
                    }
                }
            }
            stopwatch.Stop();
            textBox5.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }

        private async Task ReadFromBinAsync(ListBox listBox, string path)
        {
            stopwatch.Restart();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var listik = await Task.Run(() => (ItemLinkedList<Vehicle>)bf.Deserialize(fs));
                if (listik != null)
                {
                    foreach (var item in listik)
                    {
                        listBox.Items.Add(item.ToString());
                    }
                }
            }
            stopwatch.Stop();
            textBox6.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }

        private async Task ReadFromTxtAsync(ListBox listbox, string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    listbox.Items.Add(line.ToString());
                }
            }
            stopwatch.Stop();
            textBox6.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }

        private void ReadFromTxt(ListBox listbox, string path)
        {
            stopwatch.Restart();
            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    listbox.Items.Add(line.ToString());
                }
            }
            stopwatch.Stop();
            textBox5.Text = $"{stopwatch.ElapsedMilliseconds} мс";
        }
        private async void button15_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\Users\\Fox\\source\\repos\\LABS2\\Lab16\\Lab16\\bin\\Debug\\net8.0-windows";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string fileExtension = Path.GetExtension(filePath);

                switch (fileExtension.ToLower())
                {
                    case ".xml":
                        ReadFromXml(listBox1, filePath);
                        await ReadFromXmlAsync(listBox1, filePath);
                        break;
                    case ".json":
                        await ReadFromJsonAsync(listBox1, filePath);
                        ReadFromJson(listBox1, filePath);
                        break;
                    case ".bin":
                        ReadFromBin(listBox1, filePath);
                        await ReadFromBinAsync(listBox1, filePath);
                        break;
                    case ".txt":
                        stopwatch.Restart();
                        await ReadFromTxtAsync(listBox1, filePath);
                        ReadFromTxt(listBox1, filePath);
                        break;
                    default:
                        MessageBox.Show("Выбран неподдерживаемый формат файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
    }
}
