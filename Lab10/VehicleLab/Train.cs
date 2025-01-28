using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Train : Vehicle, IInit
{
    protected int numberOfCars;

    public int NumberOfCars
    {
        get
        {
            return numberOfCars;
        }
        set
        {
            if (value >= 1)
                numberOfCars = value;
            else
                numberOfCars = 1;
        }
    }

    public Train(int speed, int year, int numberOfCars) : base(speed, year)
    {
        this.numberOfCars = numberOfCars;
    }

    public override void Show()
    {
        Console.WriteLine("Поезд");
        base.Show();
        Console.WriteLine($"Количество вагонов: {numberOfCars}");
    }

    public override void Init()
    {
        base.Init();
        NumberOfCars = GetValidInput("Введите количество вагонов: ", int.MaxValue);
    }

    public override void RandomInit()
    {
        base.RandomInit();

        Random random = new Random();
        NumberOfCars = random.Next(1, 50);
    }

    public override bool Equals(object obj)
    {
        if (!base.Equals(obj)) return false;

        Train other = (Train)obj;
        return NumberOfCars == other.NumberOfCars;
    }

    public static Train[] SearchTrainsByNumberOfCars(Vehicle[] vehicles)
    {
        int param = GetValidInput("Введите количество вагонов: ", int.MaxValue);
        List<Train> foundTrains = new List<Train>();


        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] is Train train && train.NumberOfCars > param)
            {
                foundTrains.Add(train);
            }
        }

        if (foundTrains.Count > 0)
        {
            Console.WriteLine("Поезда, с количеством вагонов больше указанного:");
            foreach (var train in foundTrains)
            {
                train.Show();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Поездов с количеством вагонов больше указанного не найдено");
        }
        return foundTrains.ToArray();
    }
}
