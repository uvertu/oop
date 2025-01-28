using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

[Serializable]
public class Car : Vehicle, IInit
{
    protected string carMake;

    public string CarMake
    {
        get
        {
            return carMake;
        }
        set
        {
            carMake = value;
        }
    }

    public Car() { }

    public Car(int speed, int year, string carMake) : base(speed, year)
    {
        this.carMake = carMake;
    }

    public override void Show()
    {
        Console.WriteLine("Машина");
        base.Show();
        Console.WriteLine($"Марка машины: {carMake}");
    }

    public override void Init()
    {
        base.Init();
        Console.Write("Введите марку машины: ");
        CarMake = Console.ReadLine();
    }

    public override string ToString()
    {
        return $"Скорость: {Speed}, Год выпуска: {Year}, Марка машины: {carMake}";
    }

    public override void RandomInit()
    {
        base.RandomInit();
        string[] carMakes = { "Toyota", "Ford", "Honda", "Chevrolet", "BMW" };
        Random random = new Random();
        CarMake = carMakes[random.Next(carMakes.Length)];
    }

    public override bool Equals(object obj)
    {
        if (!base.Equals(obj)) return false;

        Car other = (Car)obj;
        return CarMake == other.CarMake;
    }

    public static Car[] SearchCarsByMake(Vehicle[] vehicles)
    {
        Console.Write("Введите марку машины: ");
        string mark = Console.ReadLine();
        List<Car> foundCars = new List<Car>();

        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] is Car car && car.CarMake == mark)
            {
                foundCars.Add(car);
            }
        }

        if (foundCars.Count > 0)
        {
            Console.WriteLine("Найденные машины с указанной маркой:");
            foreach (var car in foundCars)
            {
                car.Show();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Машины с указанной маркой не найдены");
        }

        return foundCars.ToArray();
    }
}
