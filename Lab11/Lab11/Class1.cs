using System;

public class TestCollectionsDemo
{
    public static void Main(string[] args)
    {
        // Создаем экземпляр класса TestCollections
        TestCollections testCollections = new TestCollections();

        // Генерируем коллекции
        testCollections.GenerateCollections();

        // Выводим содержимое коллекции_1
        Console.WriteLine("Коллекция 1 (TValue):");
        foreach (var elem in testCollections.collection1)
        {
            elem.Show();
        }

        Console.WriteLine("Коллекция 2 (string):");
        foreach (var elem in testCollections.collection2)
        {
            Console.WriteLine(elem);
        }
    }
}
