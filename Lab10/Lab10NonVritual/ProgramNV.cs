using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

class ProgramNV
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
    static Vehicle createElem()
    {
        int choice = GetValidInput("1.Создать объект класса Car\n2.Создать объект класса Train\n" +
                       "3.Создать объект класса Express\n", 3);
        Vehicle elem = null;
        switch (choice)
        {
            case 1:
                elem = new Car(0, 0, "");
                break;
            case 2:
                elem = new Train(0, 0, 0);
                break;
            case 3:
                elem = new Express(0, 0, "");
                break;
        }
        return elem;
    }
    static Vehicle[] createArray(int size)
    {
        Vehicle[] vehicles = new Vehicle[size];
        int choice;
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Создание {i + 1} элемента");
            vehicles[i] = createElem();
            vehicles[i].Init();
        }
        return vehicles;
    }
    static Vehicle[] createArrayRandom(int size)
    {
        Vehicle[] vehicles = new Vehicle[size];
        int choice;
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Создание {i + 1} элемента");
            vehicles[i] = createElem();
            vehicles[i].RandomInit();
        }
        return vehicles;
    }
    static void MenuFirst()
    {
        int arraySize = GetValidInput("Введите размер массива: ", int.MaxValue);
        Vehicle[] vehicles = [];

        int choice = GetValidInput("1.Заполить массив вручную\n2.Создать случайный массив\n", 2);
        switch (choice)
        {
            case 1:
                vehicles = createArray(arraySize);
                break;
            case 2:
                vehicles = createArrayRandom(arraySize);
                break;
        }
        MenuSecond(vehicles);
    }
    static void MenuSecond(Vehicle[] vehicles)
    {
        int choice = GetValidInput("1.Вывести массив\n2.Продолжить\n", 2);
        switch (choice)
        {
            case 1:
                Console.WriteLine("Элементы массива:");
                for (int i = 0; i < vehicles.Length; i++)
                {
                    Console.WriteLine($"Элемент {i + 1}:");
                    vehicles[i].Show();
                    Console.WriteLine();
                }
                break;
            case 2:
                break;
        }
    }
    static void Comparison()
    {
        Console.WriteLine("Первый элемент: ");
        Vehicle first = createElem();
        first.Init();
        Console.WriteLine("Второй элемент: ");
        Vehicle second = createElem();
        second.Init();
        if (first.Equals(second))
        {
            Console.WriteLine("Элемент 1 равен элементу 2.");
        }
        else
        {
            Console.WriteLine("Элемент 1 не равен элементу 2.");
        }
    }



    static void Main()
    {
        int choice;
        do
        {
            choice = GetValidInput("1.Создать массив\n2.Сравнить объекты\n3.Выйти\n", 3);
            switch (choice)
            {
                case 1:
                    MenuFirst();
                    break;
                case 2:
                    Comparison();
                    break;
                case 3:
                    break;
            }
        } while (choice != 3);


    }
}
