using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Lab4
{
    public class Program
    {
        public static int GetIntValid()
        {
            int variableInt;
            do
            {
                string variableTemp = Console.ReadLine();
                if (int.TryParse(variableTemp, out int variable))
                {
                    variableInt = variable;
                    return variableInt;
                }
                else
                {
                    Console.Write("Значение должно быть целым числом\nВведите корректное значение: ");
                }
            } while (true);
        }
        public static int NotZero()
        {
            int variable = GetIntValid();
            if (variable > 0)
            {
                return variable;
            }
            else
            {
                Console.WriteLine("Значение должно быть больше нуля\nВведите корректное значение: ");
                return NotZero();
            }
        }
        public static double GetDoubleValid()
        {
            double variableInt;
            do
            {
                string variableTemp = Console.ReadLine();
                if (double.TryParse(variableTemp, out double variable))
                {
                    variableInt = variable;
                    return variableInt;
                }
                else
                {
                    Console.Write("Значение должно быть вещественным числом\nВведите корректное значение: ");
                }
            } while (true);
        }
        public static string IsEmpty()
        {
            do
            {
                string sentence = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(sentence))
                {
                    Console.WriteLine("Строка не может быть пустой или состоять только из пробелов.\nВведите корректное значение: ");
                }
                else
                {
                    return sentence;
                }
            } while (true);
        }
        public static string InputString()
        {
            Console.WriteLine("Введите строку: ");
            string sentence = IsEmpty();
            return sentence;
        }
        public static string[] SplitString(string sentence)
        {
            char[] separators = { ' ', ',', '.', '!', '?', '-', ':', ';' };
            string[] words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
        public static string [] ReverseWords(string[] words)
        {
            string[] newWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                int number = i + 1;
                if (number % 2 == 0)
                {
                    char[] charArray = words[i].ToCharArray();
                    Array.Reverse(charArray);
                    newWords[i] = new string(charArray);
                }
                else
                {
                    newWords[i] = words[i];
                }
            }
            return newWords;
        }
        public static string ReplaceString(string sentence, string[] words, string[] reversedWords)
        {
            for (int i = 0; i < words.Length; i++)
            {
                sentence = sentence.Replace(words[i], reversedWords[i]);
            }
            return sentence;
        }
        public static void PrintSentence(char[] words)
        {
            foreach (char a in words)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
        }
        //public static void PrintSentence(string[] words)
        //{
        //    foreach (string a in words)
        //    {
        //        Console.Write(a + " ");
        //    }
        //    Console.WriteLine();
        //}
        public static string RandomOrManuallyString()
        {
            int choice;
            string sentence;
            do
            {
                Console.WriteLine("Каким образом вводится строка? \n1.Вручную \n2.Из готовых");
                choice = GetIntValid();
                switch (choice)
                {
                    case 1:
                        sentence = InputString();
                        return sentence;
                    case 2:
                        sentence = PreparedStrings();
                        Console.WriteLine(sentence);
                        return sentence;
                    default:
                        Console.WriteLine("Некорректный выбор");
                        break;
                }
            } while ((choice != 1) && (choice != 2));
            return null;
        }
        public static string PreparedStrings()
        {
            string[] arrayString = {"С кем поведешься, от того и наберешься.",
                                                "Старый друг, лучше новых двух.",
                                                "Любишь кататься — люби и саночки возить.",
                                                "Не тот хорош, кто лицом пригож, а тот хорош, кто на дело гож."};

            Random random = new Random();
            int randomIndex = random.Next(arrayString.Length);
            string sentence = arrayString[randomIndex];
            return sentence;
        }
        public static void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("1.Работа с двумерным массивом \n2.Работа со строкой \n3.Выход");
                choice = GetIntValid();
                switch (choice)
                {
                    case 1:
                        double[,] array = ArraySize();
                        array = RandomOrManually(array);
                        PrintArray(array);
                        RemoveCycle(array);
                        break;
                    case 2:
                        string sentence = RandomOrManuallyString();
                        string[] words = SplitString(sentence);
                        string[] reversedWords = ReverseWords(words);
                        string reversedSentence = ReplaceString(sentence, words, reversedWords);
                        Console.WriteLine("Строка с перевёрнутыми чётными словами:\n" + reversedSentence);
                        Exit();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор");
                        break;

                }
            } while (choice != 3);
        }

        public static void Exit()
        {
            Console.WriteLine("Нажмите Q чтобы выйти");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Q)
                {
                    Console.Clear();
                    break;
                }
            }
        }
        public static double[,] ArraySize()
        {
            Console.Write("Введите количество строк массива: ");
            int strings = NotZero();
            Console.Write("Введите количество столбцов массива: ");
            int columns = NotZero();
            double[,] array = new double[strings, columns];
            return array;
        }
        public static double[,] RandomOrManually(double[,] array)
        {
            int choice;
            do
            {
                Console.WriteLine("Каким образом заполнять массив? \n1.Случайными числами \n2.Вручную");
                choice = GetIntValid();
                switch (choice)
                {
                    case 1:
                        array = FillArrayRandom(array);
                        return array;
                    case 2:
                        array = FillArray(array);
                        return array;
                    default:
                        Console.WriteLine("Некорректный выбор");
                        break;
                }
            } while ((choice != 1) && (choice != 2));
            return null;
        }
        public static double [,] FillArray(double[,] array)
        {
            int strings = array.GetLength(0);
            int columns = array.GetLength(1);
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("Введите " + (j+1) + " элемент " + (i+1) + " строки: ");
                    double value = GetDoubleValid();
                    array[i, j] = value;
                }
            }
            return array;
        }
        public static double[,] FillArrayRandom(double[,] array)
        {
            Random rnd = new Random();
            int strings = array.GetLength(0);  
            int columns = array.GetLength(1);
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    double value = rnd.Next(-5,5);
                    array[i, j] = value; 
                }
            }
            return array;
        }
        public static void PrintArray(double[,] array)
        {
            int strings = array.GetLength(0);
            int columns = array.GetLength(1);
            Console.WriteLine("Получившийся массив: ");
            if (array.Length > 0)
            {
                for (int i = 0; i < strings; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write(array[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Пустой массив");
            }
        }
        public static double [,] DeleteString(double[,] array)
        {
            int strings = array.GetLength(0);
            int columns = array.GetLength(1);
            bool hasZero = false;
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (array[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (hasZero)
                {
                    double[,] newArray = new double[strings - 1, columns];
                    for (int g = 0; g < i; g++)
                    {
                        for (int x = 0; x < columns; x++)
                        {
                            newArray[g, x] = array[g, x];
                        }
                    }
                    for (int k = i; k < strings - 1; k++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            newArray[k, j] = array[k + 1, j];
                        }
                    }
                    return newArray;
                }
            }
            return array;
        }
        public static void RemoveCycle(double[,] array)
        {
            int choice;
            do
            {
                Console.WriteLine("1.Удалить первую строку, содержащую 0 \n2.Выйти");
                choice = GetIntValid();
                switch (choice)
                {
                    case 1:
                        double [,] newArray = DeleteString(array);
                        if (newArray.Length == array.Length)
                        {
                            Console.WriteLine("В массиве нет строки, содержащей 0");
                            PrintArray(newArray);
                        }
                        else
                        {
                            PrintArray(newArray);
                            array = newArray;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор");
                        break;
                }
            } while (choice != 2);
        }
        public static void Main()
        {
            Menu();
        }
    }
}