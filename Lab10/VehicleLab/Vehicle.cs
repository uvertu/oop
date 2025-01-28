using System;

public interface IInit
{
    void Init();
    void RandomInit();
    void Show();
}
public class SpeedComparer : IComparer<Vehicle>
{
    public int Compare(Vehicle v1, Vehicle v2)
    {
        return v1.Speed - v2.Speed;
    }
    public static Vehicle FindVehicleBySpeed(Vehicle[] vehicles, int targetSpeed)
    {
        foreach (var vehicle in vehicles)
        {
            if (vehicle.Speed == targetSpeed)
            {
                return vehicle;
            }
        }

        return null; 
    }
}

public class Vehicle : IInit, IComparable<Vehicle>
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
    protected int speed;
    protected int year;

    public int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            if (value >= 1)
                speed = value;
            else
                speed = 1;
        }
    }

    public int Year
    {
        get
        {
            return year;
        }
        set
        {
            if((value >= 1) && (value <= 2023)) 
                year = value;
            else
                year = 1;
        }
    }

    public Vehicle(int speed, int year)
    {
        this.speed = speed;
        this.year = year;
    }

    public Vehicle BaseVehicle
    {
        get
        {
            return new Vehicle(speed, year); 
        }
    }

    public virtual void Show()
    {
        Console.WriteLine($"Скорость: {speed} км/ч, Год выпуска: {year}");
    }

    public virtual void Init()
    {
        Speed = GetValidInput("Введите скорость: ", int.MaxValue);
        Year = GetValidInput("Введите год выпуска: ", 2023);
    }

    public virtual void RandomInit()
    {
        Random random = new Random();
        Speed = random.Next(1, 200);
        Year = random.Next(2000, 2023);
    }

    public virtual bool Equals(object obj)
    {
        Vehicle other = (Vehicle)obj;
        return Speed == other.Speed && Year == other.Year;
    }
    public int CompareTo(Vehicle other)
    {
        int result = this.Year.CompareTo(other.Year);
        return result;
    }
    public override string ToString()
    {
        return $"Скорость: {Speed} км/ч, Год выпуска: {Year}";
    }
}

