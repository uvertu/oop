using Microsoft.VisualBasic;
using System;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App
{
    class Program
    {
        static int GetIntValid(string variableTemp = "")
        {
            int variableInt;
            do
            {
                if (string.IsNullOrEmpty(variableTemp))
                {
                    variableTemp = Console.ReadLine();
                }
                if (int.TryParse(variableTemp, out int variable))
                {
                    variableInt = variable;
                    return variableInt;
                }
                else
                {
                    Console.WriteLine("Недопустимое значение");
                    variableTemp = "";
                }
            } while (true);
        }
        static float GetFloatValid()
        {
            float variableFloat;
            do
            {
                string variableTemp = Console.ReadLine();
                if (float.TryParse(variableTemp, out float variable))
                {
                    variableFloat = variable;
                    return variableFloat;
                }
                else
                {
                    Console.WriteLine("Значение должно быть вещественным числом");
                }
            } while (true);
        }
        static int NotZero()
        {
            do
            {
                int length = GetIntValid();
                if (length > 0)
                {
                    return length;
                }
                else
                {
                    Console.WriteLine("Значение должно быть больше 0");
                }
            } while (true);
        } 
        static int[] RemoveElement(int[] array)
        {
            int counter = 0;
            List<int> list = new(array);
            foreach(int a in list)
            {
                if (a < 0)
                {
                    list.Remove(a);
                    counter += 1;
                    break;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("В массиве нет отрицательных элементов");
            }
            else
            {
                Console.WriteLine("Массив после удаления первого отрицательного элемента:");
            }
            array = list.ToArray();
            if (array.Length > 0)
            {

                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }
            }
            else
            {
                Console.Write("Пустой массив");
            }
            Console.WriteLine();
            return array;
        }
        static float[] RemoveElement(float[] array)
        {
            int counter = 0;
            List<float> list = new(array);
            foreach (float a in list)
            {
                if (a < 0)
                {
                    list.Remove(a);
                    counter += 1;
                    break;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("В массиве нет отрицательных элементов");
            }
            else
            {
                Console.WriteLine("Массив после удаления первого отрицательного элемента: ");
            }
            array = list.ToArray();
            if (array.Length > 0)
            {

                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }
            }
            else
            {
                Console.Write("Пустой массив");
            }
            Console.WriteLine();
            return array;
        }
        static void FillArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int number = i + 1;
                Console.Write("Введите " + number + " элемент: ");
                arr[i] = GetIntValid();
            }
            Console.WriteLine("Получившийся массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        static void FillArray(float[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int number = i + 1;
                Console.Write("Введите " + number + " элемент: ");
                arr[i] = GetFloatValid();
            }
            Console.WriteLine("Получившийся массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        static void FillArrayRandom(int[] arr, int index = 0)
        {
            Random rnd = new Random();
            if (index < arr.Length)
            {
                arr[index] = rnd.Next(-100,100);
                Console.Write(arr[index] + " ");
                FillArrayRandom(arr, index + 1);
            }
            else
            {
                Console.WriteLine();
            }
        }
        static void FillArrayRandom(float[] arr)
        {
            Random rnd = new Random();
            Console.WriteLine("Получившийся массив:");
            for (int i = 0; i < arr.Length; i++)
            {

                double mantissa = rnd.NextDouble();
                double exponent = rnd.Next(-100, 100);
                arr[i] = (float)(mantissa + exponent);
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        static void MultiArray(int[,] arr, int strings, int columns)
        {
            Random rnd = new Random();
            Console.WriteLine("Получившийся массив:");
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    arr[i, j] = rnd.Next(1, 10);
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();

            }
        }
        static void FillMultArray(int[,] arr, int strings, int columns)
        {
            int number = 0;
            for (int i = 1; i < strings; i++)
            {
                number = i + 1;
                Console.Write("Введите элементы " + number + " строки через пробел: ");
                string input = Console.ReadLine();
                string[] values = input.Split(' ');
                if (values.Length == columns)
                {
                    for (int j = 0; j < values.Length; j++)
                    {
                        if (int.TryParse(values[j], out int value))
                        {
                            arr[i, j] = value;
                        }
                        else
                        {
                            Console.WriteLine("Неправильный ввод");
                            i -= 1;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Неправильная длина строки (длина не равна длине первой строки)");
                    i--;
                    continue;
                }
            }
            Console.WriteLine("Получившийся массив:");
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int[,] AddColumn(int[,] arr, int strings, int columns)
        {
            columns += 1;
            int[,] newArr = new int[strings, columns];
            Random rnd = new Random();
            do
            {
                int newColumn = NotZero();
                if (newColumn <= columns)
                {
                    for (int i = 0; i < strings; i++)
                    {
                        for (int j = 0; j < newColumn - 1; j++)
                        {
                            newArr[i, j] = arr[i, j];
                        }
                        newArr[i, newColumn - 1] = rnd.Next(1, 10);
                    }

                    for (int i = 0; i < strings; i++)
                    {
                        for (int j = newColumn; j < columns; j++)
                        {

                            newArr[i, j] = arr[i, j - 1];
                        }
                    }
                    Console.WriteLine("Массив после добавления столбца " + newColumn + ":");
                    for (int i = 0; i < strings; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            Console.Write(newArr[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    return newArr;
                }
                else
                {
                    Console.WriteLine("Недопустимое значение");
                }
            } while (true);

        }
        static void FillJaggedArray(int[][] jagArr, int strings)
        {
            int number = 0;
            for (int i = 0; i < strings; i++)
            {
                number = i + 1;
                Console.Write("Введите элементы " + number + " строки через пробел: ");
                string input = Console.ReadLine();
                string[] values = input.Split(' ');
                jagArr[i] = new int[values.Length];
                for (int j = 0; j < values.Length; j++)
                {
                    int value = GetIntValid(values[j]);
                    jagArr[i][j] = value;
                }
            }
            Console.WriteLine("Получившийся массив: ");
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < jagArr[i].Length; j++)
                {
                    Console.Write(jagArr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void jaggedArray(int[][] jagArr, int strings)
        {
            Random rnd = new Random();
            for (int i = 0; i < strings; i++)
            {
                int number = i + 1;
                Console.Write("Введите длину строки " + number + ": ");
                int columns = NotZero();
                jagArr[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                {
                    jagArr[i][j] = rnd.Next(0, 10);
                }
            }
            Console.WriteLine("Получившийся массив: ");
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < jagArr[i].Length; j++)
                {
                    Console.Write(jagArr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int[][] removeShortest(int[][] jagArr, int strings)
        {
            int[][] newArray;
            int minimum = jagArr[0].Length;
            List<int> shortestStringsIndexes = new List<int>();
            for (int i = 0; i < strings; i++)
            {
                if (jagArr[i].Length < minimum)
                {
                    minimum = jagArr[i].Length;
                    shortestStringsIndexes.Clear();
                    shortestStringsIndexes.Add(i);
                }
                else if (jagArr[i].Length == minimum)
                {
                    shortestStringsIndexes.Add(i);
                }
            }

            if (shortestStringsIndexes.Count == 1)
            {
                int indexToRemove = shortestStringsIndexes[0];
                newArray = new int[strings - 1][];
                int k = 0;
                for (int i = 0; i < strings; i++)
                {
                    if (i != indexToRemove)
                    {
                        newArray[k] = new int[jagArr[i].Length];
                        for (int j = 0; j < jagArr[i].Length; j++)
                        {
                            newArray[k][j] = jagArr[i][j];
                        }
                        k++;
                    }
                }
                Console.WriteLine("Массив после удаления кратчайшей строки: ");
                if (newArray.Length > 0)
                {
                    for (int i = 0; i < k; i++)
                    {
                        for (int j = 0; j < newArray[i].Length; j++)
                        {
                            Console.Write(newArray[i][j] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Пустой массив");
                }
                return newArray;
            }
            else
            {
                bool flag = false;
                do
                {
                    Console.WriteLine("Есть несколько строк с кратчайшей длиной " + minimum + ".");
                    Console.WriteLine("Выберите какую из этих строк удалить:");
                    for (int i = 0; i < shortestStringsIndexes.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". Строка " + (shortestStringsIndexes[i] + 1));
                    }
                    int choice = NotZero();
                    if (choice > shortestStringsIndexes.Count)
                    {
                        Console.WriteLine("Неправильный выбор");
                    }
                    else
                    {
                        flag = true;
                        int indexToRemove = shortestStringsIndexes[choice - 1];
                        newArray = new int[strings - 1][];
                        int k = 0;
                        for (int i = 0; i < strings; i++)
                        {
                            if (i != indexToRemove)
                            {
                                newArray[k] = new int[jagArr[i].Length];
                                for (int j = 0; j < jagArr[i].Length; j++)
                                {
                                    newArray[k][j] = jagArr[i][j];
                                }
                                k++;
                            }
                        }
                        Console.WriteLine("Массив после удаления кратчайшей строки");
                        if (newArray.Length > 0)
                        {
                            for (int i = 0; i < k; i++)
                            {
                                for (int j = 0; j < newArray[i].Length; j++)
                                {
                                    Console.Write(newArray[i][j] + " ");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Пустой массив");
                        }
                        return newArray;
                    }
                } while (flag != true);
            }
            return null;
        }

        static void MenuInputFirst(int[] arr)
        {
            bool isCorrect = false;
            do
            {
                Console.WriteLine("Каким образом заполняется массив?");
                Console.WriteLine("1.Вручную");
                Console.WriteLine("2.Датчик случайных чисел");
                int choiceThird = GetIntValid();
                switch (choiceThird)
                {
                    case 1:
                        isCorrect = true;
                        FillArray(arr);
                        break;
                    case 2:
                        isCorrect = true;
                        Console.WriteLine("Получившийся массив");
                        FillArrayRandom(arr);
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор");
                        break;
                }
            } while (isCorrect != true);
        }
        static void MenuInputFirst(float[] arr)
        {
            bool isCorrect = false;
            do
            {
                Console.WriteLine("Каким образом заполняется массив?");
                Console.WriteLine("1.Вручную");
                Console.WriteLine("2.Датчик случайных чисел");
                int choiceThird = GetIntValid();
                switch (choiceThird)
                {
                    case 1:
                        isCorrect = true;
                        FillArray(arr);
                        break;
                    case 2:
                        isCorrect = true;
                        Console.WriteLine("Получившийся массив");
                        FillArrayRandom(arr);
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор");
                        break;
                }
            } while (isCorrect != true);
        }
        static void MenuInputSecond()
        {
            bool isCorrect = false;
            do
            {
                Console.WriteLine("Каким образом заполняется массив?");
                Console.WriteLine("1.Вручную");
                Console.WriteLine("2.Датчик случайных чисел");
                int choiceThird = GetIntValid();
                switch (choiceThird)
                {
                    case 1:
                        int counter = 0;
                        isCorrect = true;
                        Console.Write("Введите количество строк: ");
                        int strings = NotZero();
                        string[] values;
                        do
                        {
                            Console.Write("Введите элементы 1 строки через пробел: ");
                            string input = Console.ReadLine();
                            values = input.Split(' ');
                            for (int j = 0; j < values.Length; j++)
                            {
                                if (int.TryParse(values[j], out int value))
                                {
                                    counter++;
                                }
                                else
                                {
                                    Console.WriteLine("Неправильное значение");
                                    counter = 0;
                                    break;
                                }
                            }
                        } while (counter < values.Length);
                        int columns = values.Length;
                        int[,] secondArray = new int[strings, columns];
                        for (int j = 0; j < values.Length; j++)
                        {
                            int value = GetIntValid(values[j]);
                            secondArray[0, j] = value;
                        }
                        FillMultArray(secondArray, strings, columns);
                        MenuAddition(secondArray, strings, columns);
                        break;
                    case 2:
                        isCorrect = true;
                        Console.Write("Введите количество строк: ");
                        strings = NotZero();
                        Console.Write("Введите количество столбцов: ");
                        columns = NotZero();
                        secondArray = new int[strings, columns];
                        MultiArray(secondArray, strings, columns);
                        MenuAddition(secondArray, strings, columns);
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор");
                        break;
                }
            } while (isCorrect != true);
        }
        static void MenuAddition(int [,] secondArray, int strings, int columns)
        {
            bool flag = false;
            do
            {
                Console.WriteLine("1.Добавить столбец с заданным номером");
                Console.WriteLine("2.Выйти");
                string choicesecond = Console.ReadLine();
                if (choicesecond == "1")
                {
                    Console.WriteLine("Введите номер столбца");
                    secondArray = AddColumn(secondArray, strings, columns);
                    columns += 1;
                }
                else if (choicesecond == "2")
                {
                    flag = true;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Неправильный выбор");
                }
            } while (flag != true);
        }
        static void MenuInputThird()
        {
            bool isCorrect = false;
            do
            {
                Console.WriteLine("Каким образом заполняется массив?");
                Console.WriteLine("1.Вручную");
                Console.WriteLine("2.Датчик случайных чисел");
                int choiceThird = GetIntValid();
                switch (choiceThird)
                {
                    case 1:
                        isCorrect = true;
                        Console.Write("Введите количество строк: ");
                        int stepStrings = NotZero();
                        int[][] jaggArr = new int[stepStrings][];
                        FillJaggedArray(jaggArr, stepStrings);
                        MenuAdditionSecond(jaggArr, stepStrings);
                        break;
                    case 2:
                        isCorrect = true;
                        Console.Write("Введите количество строк: ");
                        stepStrings = NotZero();
                        jaggArr = new int[stepStrings][];
                        jaggedArray(jaggArr, stepStrings);
                        MenuAdditionSecond(jaggArr, stepStrings);
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор");
                        break;
                }
            } while (isCorrect != true);
        }
        static void MenuAdditionSecond(int[][] jaggArr, int stepStrings)
        {
            bool flag = false;
            do
            {
                Console.WriteLine("1.Удалить кратчайшую строку");
                Console.WriteLine("2.Выйти");
                string choicesecond = Console.ReadLine();
                if (choicesecond == "1")
                {
                    if (jaggArr.Length > 0)
                    {
                        jaggArr = removeShortest(jaggArr, stepStrings);
                        stepStrings -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Пустой массив");
                    }
                }
                else if (choicesecond == "2")
                {
                    flag = true;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Неправильный выбор");
                }
            } while (flag != true);
        }

        static void MenuInput()
        {
            Console.Write("Введите длину массива: ");
            int length = NotZero();
            bool flag2 = false;
            bool flag = false;
            do
            {
                Console.WriteLine("С какими числами работать?");
                Console.WriteLine("1.Целыми");
                Console.WriteLine("2.Вещественными");
                int choice = GetIntValid();
                switch (choice)
                {
                    case 1:
                        flag = true;
                        int[] intArr = new int[length];
                        MenuInputFirst(intArr);
                        do
                        {
                            Console.WriteLine("1.Удалить первый отрицательный элемент");
                            Console.WriteLine("2.Выйти");
                            string choicesecond = Console.ReadLine();
                            if (choicesecond == "1")
                            {
                                if (intArr.Length > 0)
                                {
                                    intArr = RemoveElement(intArr);
                                }
                                else
                                {
                                    Console.WriteLine("Пустой массив");
                                }
                            }
                            else if (choicesecond == "2")
                            {
                                flag2 = true;
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Неправильный выбор");
                            }
                        } while (flag2 != true);
                        break;
                    case 2:
                        flag = true;
                        float[] floatArr = new float[length];
                        MenuInputFirst(floatArr);
                        do
                        {
                            Console.WriteLine("1.Удалить первый отрицательный элемент");
                            Console.WriteLine("2.Выйти");
                            string choicesecond = Console.ReadLine();
                            if (choicesecond == "1")
                            {
                                floatArr = RemoveElement(floatArr);
                            }
                            else if (choicesecond == "2")
                            {
                                flag2 = true;
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Неправильный выбор");
                            }
                        } while (flag2 != true);
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор");
                        break;
                }
            } while (flag != true);
        }
        static void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1.Работа с одномерным массивом: ");
                Console.WriteLine("2.Работа с двумерным массивом: ");
                Console.WriteLine("3.Работа с рваным массивом: ");
                Console.WriteLine("4.Выход");
                choice = GetIntValid();
                switch (choice)
                {
                    case 1:
                        MenuInput();
                        break;
                    case 2:
                        MenuInputSecond();
                        break;
                    case 3:
                        MenuInputThird();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор");
                        break;
                }

            } while (choice != 4);
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}

