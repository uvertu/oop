using System.Diagnostics;

public class TestCollections
{
    // Коллекция_1< TValue >
    public LinkedList<Vehicle> collection1 = new LinkedList<Vehicle>();

    // Коллекция_1<string>
    public LinkedList<string> collection2 = new LinkedList<string>();

    // Коллекция_2<TKey, TValue>
    public SortedDictionary<Vehicle, Train> collection3 = new SortedDictionary<Vehicle, Train>();

    // Коллекция_2<string, TValue>
    public SortedDictionary<string, Vehicle> collection4 = new SortedDictionary<string, Vehicle>();

    public void GenerateCollections()
    {
        int counter = 1000;
        Random random = new Random();

        for (int i = 0; i < counter; i++)
        {
            // Создаем объект Train с случайными параметрами
            var train = new Train(0, 0, 0);
            train.RandomInit();

            // Добавляем объект в коллекцию1
            collection1.AddLast(train.BaseVehicle);

            // Добавляем строковое представление объекта в коллекцию2
            collection2.AddLast(train.ToString());
        }
    }


    public void AddToCollection1(Vehicle vehicle)
    {
        collection1.AddLast(vehicle);
    }

    // Метод для удаления элемента из коллекции_1
    public bool RemoveFromCollection1(Vehicle vehicle)
    {
        return collection1.Remove(vehicle);
    }

    // Метод для добавления элемента в коллекцию_2
    public void AddToCollection2(string key, Vehicle vehicle)
    {
        collection4.Add(key, vehicle);
    }

    // Метод для удаления элемента из коллекции_2
    public bool RemoveFromCollection2(string key)
    {
        return collection4.Remove(key);
    }
}
