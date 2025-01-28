using System;

class Program
{
    static void Main()
    {
        int a = 5;
        Console.WriteLine(a--);
        Console.WriteLine(a);
        Time time1 = new Time(14, 30);
        Time time2 = new Time(8, 45);

        Console.WriteLine("Time 1:");
        time1.DisplayTime();

        Console.WriteLine("Time 2:");
        time2.DisplayTime();

        // Вычитание минут с использованием статической функции
        Time resultStatic = Time.SubtractMinutesStatic(time1, 15);
        Console.WriteLine("Subtracting 15 minutes (Static):");
        resultStatic.DisplayTime();

        // Вычитание минут с использованием метода класса
        Time resultMethod = time2.SubtractMinutes(30);
        Console.WriteLine("Subtracting 30 minutes (Method):");
        resultMethod.DisplayTime();

        // Использование статической компоненты для подсчета объектов
        Console.WriteLine($"Object count: {Time.GetObjectCount()}");
    }
}
