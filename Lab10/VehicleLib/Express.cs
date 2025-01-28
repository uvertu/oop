using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Express : Vehicle, IInit
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

    public Express() { }
    public Express(int speed, int year, string route) : base(speed, year)
    {
        this.route = route;
    }

    public override void Show()
    {
        Console.WriteLine("Экспресс");
        base.Show();
        Console.WriteLine($"Маршрут: {route}");
    }

    public override void Init()
    {
        base.Init();
        Console.Write("Введите маршрут (Пункт А - Пункт Б): ");
        Route = Console.ReadLine();
    }

    public override void RandomInit()
    {
        base.RandomInit();

        string[] routes = { "ЛОНДОН  - БЕРЛИН", "ЛОНДОН  - ВЕНЕЦИЯ", "ЛОНДОН - ТАУЭРСКИЕ ВОРОТА" };
        Random random = new Random();
        Route = routes[random.Next(routes.Length)];
    }

    public override bool Equals(object obj)
    {
        if (!base.Equals(obj)) return false;

        Express other = (Express)obj;
        return Route == other.Route;
    }
    public override string ToString()
    {
        return $"Скорость: {Speed}, Год выпуска: {Year}, Маршрут: {Route}";
    }

    public static Express[] SearchExpresses(Vehicle[] vehicles)
    {
        List<Express> foundExpresses = new List<Express>();

        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] is Express express)
            {
                foundExpresses.Add(express);
            }
        }

        if (foundExpresses.Count > 0)
        {
            Console.WriteLine("Найденные экспрессы:");
            foreach (var express in foundExpresses)
            {
                express.Show();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Экспрессы не найдены");
        }
        return foundExpresses.ToArray();
    }
}
