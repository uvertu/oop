using System;
using System.Reflection;

class Program
{
    static Vehicle CreateElem()
    {
        int choice = Vehicle.GetValidInput("1.Создать объект класса Car\n2.Создать объект класса Train\n" +
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
    static Vehicle[] CreateArray(int size)
    {
        Vehicle[] vehicles = new Vehicle[size];
        int choice;
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Создание {i + 1} элемента");
            vehicles[i] = CreateElem();
            vehicles[i].Init();
        }
        return vehicles;
    }
    static Vehicle[] CreateArrayRandom(int size)
    {
        Vehicle[] vehicles = new Vehicle[size];
        int choice;
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Создание {i + 1} элемента");
            vehicles[i] = CreateElem();
            vehicles[i].RandomInit();
        }
        return vehicles;
    }
    static void MenuFirst()
    {
        int arraySize = Vehicle.GetValidInput("Введите размер массива: ", int.MaxValue);
        Vehicle[] vehicles = [];

        int choice = Vehicle.GetValidInput("1.Заполить массив вручную\n2.Создать случайный массив\n", 2);
        switch (choice)
        {
            case 1:
                vehicles = CreateArray(arraySize);
                break;
            case 2:
                vehicles = CreateArrayRandom(arraySize);
                break;
        }
        MenuSecond(vehicles);
    }
    static void MenuSecond(Vehicle[] vehicles)
    {
        int choice;
        do
        {
            choice = Vehicle.GetValidInput("1.Вывести массив\n2.Запросы к массиву\n3.Сортировка по году выпуска (IComaparble)\n" +
                                           "4.Сортировка по скорости (ICompare)\n5.Поиск элемента с заданной скоростью\n" +
                                           "6.Продолжить\n", 7);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Элементы массива:");
                    for (int i = 0; i < vehicles.Length; i++)
                    {
                        Console.WriteLine($"Элемент {i + 1}:");
                        Console.WriteLine(vehicles[i].GetType());
                        vehicles[i].Show();
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    MenuThird(vehicles);
                    break;
                case 3:
                    Array.Sort(vehicles);
                    Console.WriteLine("Массив, отсортированный по году выпуска:");
                    for (int i = 0; i < vehicles.Length; i++)
                    {
                        Console.WriteLine($"Элемент {i + 1}:");
                        vehicles[i].Show();
                        Console.WriteLine();
                    }
                    break;
                case 4:
                    Array.Sort(vehicles, new SpeedComparer());
                    Console.WriteLine("Массив, отсортированный по скорости:");
                    for (int i = 0; i < vehicles.Length; i++)
                    {
                        Console.WriteLine($"Элемент {i + 1}:");
                        vehicles[i].Show();
                        Console.WriteLine();
                    }
                    break;
                case 5:
                    int targetSpeed = Vehicle.GetValidInput("Введите значение скорости: ", int.MaxValue);
                    Vehicle foundVehicle = SpeedComparer.FindVehicleBySpeed(vehicles, targetSpeed);
                    if (foundVehicle != null)
                    {
                        foundVehicle.Show();
                        Console.WriteLine("\nБинарный поиск:");
                        Array.Sort(vehicles, new SpeedComparer());
                        int index = Array.BinarySearch(vehicles, new Vehicle(targetSpeed, 0), new SpeedComparer());
                        vehicles[index].Show();
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"Элемент со скоростью {targetSpeed} не найден");
                    }
                    break;
                case 6:
                    ArrayIInit();
                    break;
            }
        } while (choice != 6);
    }
    static void Comparison()
    {
        Console.WriteLine("Первый элемент: ");
        Vehicle first = CreateElem();
        first.Init();
        Console.WriteLine("Второй элемент: ");
        Vehicle second = CreateElem();
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
    static void MenuThird(Vehicle[] vehicles)
    {
        int choice = Vehicle.GetValidInput("1.Вывести информацию о машинах указанной марки\n" +
                                   "2.Вывести информацию о поездах с количеством вагонов больше указанного\n" +
                                   "3.Вывести информацию только об экспрессах\n", 3);
        switch(choice)
        {
            case 1:
                Car.SearchCarsByMake(vehicles);
                break;
            case 2:
                Train.SearchTrainsByNumberOfCars(vehicles);
                break;
            case 3:
                Express.SearchExpresses(vehicles); 
                break;
        }
    }
    static void ArrayIInit()
    {

        IInit[] initArray = new IInit[4];

        initArray[0] = new Car(0, 0, "");
        initArray[1] = new Train(0, 0, 0);
        initArray[2] = new Express(0, 0, "");
        initArray[3] = new Bicycle(0, new Company("FORWARD"));
        initArray[0].RandomInit();
        initArray[1].RandomInit();
        initArray[2].RandomInit();
        initArray[3].Init();
        Console.WriteLine();
        foreach (var item in initArray)
        {
            item.Show();
            Console.WriteLine();
        }
        Console.WriteLine("\n-------------------------------");
        Cloning();
    }

    static void Cloning()
    {
        Bicycle originalBicycle = new Bicycle(2, new Company("FORWARD"));
        Bicycle copiedBicycle = originalBicycle;
        Bicycle clonedBicycle = (Bicycle)originalBicycle.Clone();
        Bicycle shallowCopiedBicycle = (Bicycle)originalBicycle.ShallowCopy();

        Console.WriteLine("Оригинал:");
        originalBicycle.Show();

        Console.WriteLine("\nКопия");
        copiedBicycle.Show();

        Console.WriteLine("\nКлон:");
        clonedBicycle.Show();

        Console.WriteLine("\nПоверхностная копия");
        shallowCopiedBicycle.Show();

        Console.WriteLine();

        originalBicycle.NumberOfWheels = 3;
        originalBicycle.Company.Name = "SCOTT";

        Console.WriteLine("Оригинал после изменений:");
        originalBicycle.Show();

        Console.WriteLine("\nКопия после изменения оригинала");
        copiedBicycle.Show();

        Console.WriteLine("\nКлон после изменения оригинала:");
        clonedBicycle.Show();

        Console.WriteLine("\nПоверхностная копия после изменения оригинала");
        shallowCopiedBicycle.Show();

        Console.WriteLine();
    }
    static void Main()
    {
        int choice;
/*        Vehicle c = new Express(1, 2, "BMW");
        c.Show();*/
        do
        {
            choice = Vehicle.GetValidInput("1.Создать массив\n2.Сравнить объекты\n3.Выйти\n", 3);
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
