using Lab9;
using System;

public class Program
{
    public static int GetValidInput(string prompt, int maxValue)
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
        Time currentTime = new Time(0, 0);

        currentTime.Hours = GetValidInput("Введите количество часов: ", int.MaxValue);

        currentTime.Minutes = GetValidInput("Введите количество минут: ", int.MaxValue);
        return currentTime;
    }

    public static Time MenuFirst(Time currentTime)
    {
        int choice;
        do
        {
            choice = GetValidInput("1.Вычесть минуты\n2.Продолжить\n", 2);
            switch (choice)
            {
                case 1:
                    int inMinutes = currentTime.Hours * 60 + currentTime.Minutes;

                    int subtractMinutes = GetValidInput("Введите количество минут для вычитания:  ", inMinutes);

                    Time resultStatic = Time.SubtractMinutesStatic(currentTime, subtractMinutes);
                    Console.WriteLine("Результат (статическая функция):");
                    resultStatic.DisplayTime();

                    currentTime.SubtractMinutes(subtractMinutes);
                    Console.WriteLine("Результат (метод):");
                    currentTime.DisplayTime();

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

    public static Time MenuSecond(Time currentTime)
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

    public static bool MenuThird(Time currentTime)
    {
        bool flag = false;
        int choice;
        do
        {
            choice = GetValidInput("1.Сравнить время \n2.Продолжить\n", 2);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Создание второго объекта");
                    Time secondTime = CreateObject();
                    secondTime.DisplayTime();

                    if (currentTime == secondTime)
                    {
                        Console.WriteLine("Значения первого и второго времени равны (оператор ==)");
                        flag = true;
                    }
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
        return flag;
    }

    public static TimeArray MenuFourth()
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
                    timeArray = new TimeArray(); 
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
                    timeArray = new TimeArray(size, true);
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

    public static bool MenuFifth(TimeArray timeArray, int size)
    {
        bool flag = false;
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
                        Console.WriteLine("Массив пустой");
                        break;
                    }
                    else
                    {
                        timeArray.DisplayArray();
                        flag = true;
                        break;
                    }
                case 2:
                    if (size == 0)
                    {
                        Console.WriteLine("Массив пустой");
                        flag = false;
                        break;
                    }
                    else
                    {
                        Time minTime = MinTime(timeArray, size);
                        Console.WriteLine("Минимальное время в массиве:");
                        minTime.DisplayTime();
                        flag = true;
                        break;
                    }
                case 3:
                    break;
                default:
                    Console.WriteLine("Некорректный ввод");
                    break;
            }
        } while (choice != 3);
        Console.WriteLine();
        return flag;
    }

    public static Time MinTime(TimeArray timeArray, int size)
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

        return timeArray[index];
    }

    public static bool IsEqual(Time currentTime)
    {
        bool isNonZero = (bool)currentTime;
        if (isNonZero)
            Console.WriteLine("Часы и минуты не равны 0");
        else
            Console.WriteLine("Часы и минуты равны 0");
        return isNonZero;
    }

    public static int GetHours(Time currentTime)
    {
        int hoursOnly = currentTime;
        return hoursOnly;
    }
    public static void PartFirstTwo()
    {
        Time currentTime = CreateObject();

        Console.WriteLine("Введенное время:");
        currentTime.DisplayTime();

        currentTime = MenuFirst(currentTime);
        currentTime.DisplayTime();

        currentTime = MenuSecond(currentTime);

        int hoursOnly = GetHours(currentTime);
        currentTime.DisplayTime();

        Console.WriteLine("Приведение к типу int (количество часов - int значение): " + hoursOnly);

        bool isNonZero = IsEqual(currentTime);
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