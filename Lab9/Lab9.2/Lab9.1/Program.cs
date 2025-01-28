using Lab9;
using System;

class Program
{
    static int GetValidInput(string prompt, int maxValue)
    {
        int userInput;

        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out userInput) && userInput >= 0 && userInput <= maxValue)
            {
                break;
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        } while (true);

        return userInput;
    }

    static public Time CreateObject()
    {
        // Ввод часов с проверкой
        int inputHours = GetValidInput("Введите количество часов: ", int.MaxValue);

        // Ввод минут с проверкой
        int inputMinutes = GetValidInput("Введите количество минут: ", 59);

        // Создание объекта Time
        Time currentTime = new Time(inputHours, inputMinutes);
        return currentTime;
    }

    static Time MenuFirst(Time currentTime)
    {
        int choice;
        do
        {
            choice = GetValidInput("1.Вычесть минуты\n2.Продолжить\n", 2);
            switch (choice)
            {
                case 1:
                    int inMinutes = currentTime.Hours * 60 + currentTime.Minutes;
                    //Console.WriteLine(inMinutes);

                    // Вычитание минут с использованием статической функции
                    int subtractMinutes = GetValidInput("Введите количество минут для вычитания:  ", inMinutes);
                    Time resultStatic = Time.SubtractMinutesStatic(currentTime, subtractMinutes);
                    Console.WriteLine("Результат (статическая функция):");
                    resultStatic.DisplayTime();

                    // Вычитание минут с использованием метода класса
                    currentTime = currentTime.SubtractMinutes(subtractMinutes);
                    Console.WriteLine("Результат (метод):");
                    currentTime.DisplayTime();

                    // Вывод количества созданных объектов
                    Console.WriteLine("Количество созданных объектов: " + Time.GetObjectCount());
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("Некорректный ввод.");
                    break;
            }
        } while (choice != 2);
        Console.WriteLine();
        return currentTime;
    }

    static Time MenuSecond(Time currentTime)
    {
        int choice;
        do
        {
            choice = GetValidInput("1.Обнулить время \n2.Уменьшить время на 1 минуту \n3.Продолжить\n", 3);
            switch (choice)
            {
                case 1:
                    currentTime = -currentTime;
                    currentTime.DisplayTime();
                    break;
                case 2:
                    currentTime = --currentTime;
                    currentTime.DisplayTime();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Некорректный ввод.");
                    break;
            }
        } while (choice != 3);
        Console.WriteLine();
        return currentTime;
    }

    static void MenuThird(Time currentTime)
    {
        int choice;
        do
        {
            choice = GetValidInput("1.Сравнить время \n2.Продолжить\n", 2);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Создание второго объекта");
                    Time secondTime = CreateObject();

                    if (currentTime == secondTime)
                        Console.WriteLine("Значения первого и второго времени равны (оператор ==)");
                    else
                        Console.WriteLine("Значения первого и второго времени не равны (оператор ==)");

                    if (currentTime != secondTime)
                        Console.WriteLine("Значения первого и второго времени не равны (оператор !=)");
                    else
                        Console.WriteLine("Значения первого и второго времени равны (оператор !=)");
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("Некорректный ввод.");
                    break;
            }
        } while (choice != 2);
        Console.WriteLine();
    }

    static TimeArray MenuFourth()
    {
        TimeArray timeArray = null;
        int choice;
        int size;
        do
        {
            Console.WriteLine("Заполнение массива: ");
            choice = GetValidInput("1.Массив без параметров \n2.Конструктор с параметрами (случайные элементы) \n3.Конструктор с параметрами (ручной ввод) \n4.Вывести количество созданных объектов \n5.Выход\n", 5);
            switch (choice)
            {
                case 1:
                    timeArray = new TimeArray(); // конструктор без параметров
                    Console.WriteLine();
                    MenuFifth(timeArray, 3);
                    break;
                case 2:
                    size = GetValidInput("Введите размер массива: ", int.MaxValue);
                    timeArray = new TimeArray(size);
                    Console.WriteLine();
                    MenuFifth(timeArray, size);
                    break;
                case 3:
                    size = GetValidInput("Введите размер массива: ", int.MaxValue);
                    timeArray = new TimeArray(size, false);
                    Console.WriteLine();
                    MenuFifth(timeArray, size);
                    break;
                case 4:
                    Console.WriteLine("Количество созданных объектов: " + TimeArray.GetObjectCount());
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Некорректный ввод.");
                    break;
            }
        } while (choice != 5);
        return timeArray;
    }

    static void MenuFifth(TimeArray timeArray, int size)
    {
        int choice;
        do
        {
            choice = GetValidInput("1.Вывести массив \n2.Вывести минимальное значение из массива \n3.Продолжить\n", 3);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Элементы массива:");
                    if (size == 0)
                    {
                        Console.WriteLine("Массив пустой.");
                        break;
                    }
                    else
                    {
                        timeArray.DisplayArray();
                        break;
                    }
                case 2:
                    Console.WriteLine("Элементы массива:");
                    DisplayMinTime(timeArray, size);
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Некорректный ввод");
                    break;
            }
        } while (choice != 3);
        Console.WriteLine();
    }

    public static void DisplayMinTime(TimeArray timeArray, int size)
    {
        // Используем индексатор для получения элемента по индексу 0

        if (size == 0)
        {
            Console.WriteLine("Массив пустой");
        }
        else
        {
            int minTime = timeArray[0].Hours * 60 + timeArray[0].Minutes;
            int index = 0;
            for (int i = 1; i < size; i++)
            {
                int minTimeCurrent = timeArray[i].Hours * 60 + timeArray[i].Minutes;
                if (minTimeCurrent < minTime)
                {
                    minTime = minTimeCurrent;
                    index = i;
                }
            }

            // Выводим минимальное время
            Console.WriteLine("Минимальное время в массиве:");
            timeArray[index].DisplayTime();
        }
    }

    static void PartFirstTwo()
    {
        Time currentTime = CreateObject();

        // Вывод информации о времени
        Console.WriteLine("Введенное время:");
        currentTime.DisplayTime();

        currentTime = MenuFirst(currentTime);
        currentTime.DisplayTime();

        currentTime = MenuSecond(currentTime);

        // Операции приведения типа
        int hoursOnly = currentTime;
        currentTime.DisplayTime();
        Console.WriteLine("Приведение к типу int (количество часов - int значение): " + hoursOnly);
        bool isNonZero = (bool)currentTime;
        if (isNonZero)
            Console.WriteLine("Часы и минуты не равны 0");
        else
            Console.WriteLine("Часы и минуты равны 0");
        Console.WriteLine();

        currentTime.DisplayTime();

        MenuThird(currentTime);

        MenuFourth();
    }

    static void Main()
    {
        PartFirstTwo();
    }
}