using System;

public class Vehicle
{
    // Поля
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
            speed = value;
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
            year = value;
        }
    }

    public Vehicle(int speed, int year)
    {
        this.speed = speed;
        this.year = year;
    }

    public void Show()
    {
        Console.WriteLine($"Скорость: {speed} км/ч, Год выпуска: {year}");
    }

    public void Init()
    {
        Console.Write("Введите скорость: ");
        speed = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите год выпуска: ");
        year = Convert.ToInt32(Console.ReadLine());
    }

    public void RandomInit()
    {
        Random random = new Random();
        speed = random.Next(1, 200);
        year = random.Next(1900, 2023);
    }

    public bool Equals(object obj)
    {
        Vehicle other = (Vehicle)obj;
        return speed == other.speed && year == other.year;
    }
}

public class Car : Vehicle
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

    public Car(int speed, int year, string carMake) : base(speed, year)
    {
        this.carMake = carMake;
    }

    public void Show()
    {
        base.Show();
        Console.WriteLine($"Скорость: {Speed} км/ч, Год выпуска: {Year}, Марка машины: {carMake}");
    }

    public void Init()
    {
        base.Init();
        Console.Write("Введите марку машины: ");
        carMake = Console.ReadLine();
    }

    public void RandomInit()
    {
        base.RandomInit();
        string[] carMakes = { "Toyota", "Ford", "Honda", "Chevrolet", "BMW" };
        Random random = new Random();
        carMake = carMakes[random.Next(carMakes.Length)];
    }

    public bool Equals(object obj)
    {
        if (!(obj is Car)) return false;

        Car other = (Car)obj;
        return base.Equals(obj) && carMake == other.carMake;
    }
}

public class Train : Vehicle
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
            numberOfCars = value;
        }
    }

    public Train(int speed, int year, int numberOfCars) : base(speed, year)
    {
        this.numberOfCars = numberOfCars;
    }

    public void Show()
    {
        Console.WriteLine($"Скорость: {Speed} км/ч, Год выпуска: {Year}, Количество вагонов: {numberOfCars}");
    }

    public void Init()
    {
        base.Init();
        Console.Write("Введите количество вагонов: ");
        numberOfCars = Convert.ToInt32(Console.ReadLine());
    }

    public void RandomInit()
    {
        base.RandomInit();

        Random random = new Random();
        numberOfCars = random.Next(1, 20);
    }

    public bool Equals(object obj)
    {
        if (!(obj is Train)) return false;

        Train other = (Train)obj;
        return base.Equals(obj) && numberOfCars == other.numberOfCars;
    }
}

public class Express : Vehicle
{
    protected string route;

    public string Route
    {
        get
        {
            return route;
        }
        set
        {
            route = value;
        }
    }

    public Express(int speed, int year, string route) : base(speed, year)
    {
        this.route = route;
    }

    public void Show()
    {
        Console.WriteLine($"Скорость: {Speed} км/ч, Год выпуска: {Year}, Маршрут: {route}");
    }

    public void Init()
    {
        base.Init();
        Console.Write("Введите маршрут (Пункт А - Пункт Б): ");
        route = Console.ReadLine();
    }

    public void RandomInit()
    {
        base.RandomInit();

        string[] routes = { "ЛОНДОН  - БЕРЛИН", "ЛОНДОН  - ВЕНЕЦИЯ", "ЛОНДОН - ТАУЭРСКИЕ ВОРОТА" };
        Random random = new Random();
        route = routes[random.Next(routes.Length)];
    }

    public bool Equals(object obj)
    {
        if (!(obj is Express)) return false;

        Express other = (Express)obj;
        return base.Equals(obj) && route == other.route;
    }
}
