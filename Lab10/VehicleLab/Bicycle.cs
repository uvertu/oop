using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bicycle : IInit, ICloneable
{
    private int numberOfWheels;
    private Company company;

    public Company Company
    {
        get
        {
            return company;
        }
        set
        {
            company = value;
        }
    }
    public int NumberOfWheels
    {
        get
        {
            return numberOfWheels;
        }
        set
        {
            if ((value < 4) && (value > 1))
                numberOfWheels = value;
            else
                numberOfWheels = 2;
        }
    }

    public Bicycle(int numberOfWheels, Company company)
    {
        this.numberOfWheels = numberOfWheels;
        this.company = company;
    }

    public void Init()
    {
        NumberOfWheels = Vehicle.GetValidInput("Введите количество колес велосипеда: ", int.MaxValue);
    }

    public void RandomInit()
    {
        NumberOfWheels = new Random().Next(2, 4);
    }

    public void Show()
    {
        Console.WriteLine($"Велосипед\nКоличество колёс {NumberOfWheels}, Компания {company.Name}");
    }

    public object Clone()
    {
        return new Bicycle(this.NumberOfWheels, new Company(this.Company.Name));
    }

    public object ShallowCopy()
    {
        return (Bicycle)this.MemberwiseClone();
    }
}
