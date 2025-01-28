using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Train : Vehicle, IInit
{
    protected string company;

    public string Company
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

    public Train() { }
    public Train(int speed, int year, string company) : base(speed, year)
    {
        this.company = company;
    }

    public override void Show()
    {
        Console.WriteLine("Поезд");
        base.Show();
        Console.WriteLine($"Компания: {company}");
    }

    public override void Init()
    {
        base.Init();
        Console.Write("Введите название компании: ");
        Company = Console.ReadLine();
    }

    public override void RandomInit()
    {
        base.RandomInit();
        string[] companies = { "РЖД", "БЧ", "ЛДЗ", "ЧФМ", "ЛГ" };
        Random random = new Random();
        Company = companies[random.Next(companies.Length)];
    }

    public override bool Equals(object obj)
    {
        if (!base.Equals(obj)) return false;

        Train other = (Train)obj;
        return Company == other.Company;
    }

    public override string ToString()
    {
        return $"Скорость: {Speed}, Год выпуска: {Year}, Компания: {Company}";
    }
}
