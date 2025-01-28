using Lab9._3;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Создание коллекции с конструктором без параметров:");
        TimeCollection collection1 = new TimeCollection();
        collection1.DisplayTimes();

        Console.WriteLine("\nCreating TimeCollection with random values constructor:");
        TimeCollection collection2 = new TimeCollection(5);
        collection2.DisplayTimes();

        Console.WriteLine("\nCreating TimeCollection with user input constructor:");
        Console.Write("Enter the size of the collection: ");
        int size = int.Parse(Console.ReadLine());
        TimeArray[] userTimes = new TimeArray[size];
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Enter time {i + 1} (hh:mm): ");
            string[] input = Console.ReadLine().Split(':');
            userTimes[i] = new TimeArray(int.Parse(input[0]), int.Parse(input[1]));
        }
        TimeCollection collection3 = new TimeCollection(userTimes);
        collection3.DisplayTimes();

        Console.WriteLine("\nAccessing elements using indexer:");
        for (int i = 0; i < collection3.Count; i++)
        {
            Console.WriteLine($"Element {i + 1}: {collection3[i]}");
        }

        Console.WriteLine("\nFinding minimum time:");
        TimeArray minTime = FindMinTime(collection3);
        Console.WriteLine($"Minimum time: {minTime}");
    }

    static TimeArray FindMinTime(TimeCollection collection)
    {
        TimeArray minTime = collection[0];

        for (int i = 1; i < collection.Count; i++)
        {
            if (collection[i].Hours < minTime.Hours || (collection[i].Hours == minTime.Hours && collection[i].Minutes < minTime.Minutes))
            {
                minTime = collection[i];
            }
        }

        return minTime;
    }
}
