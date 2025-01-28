using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    public class CityCollection
    {
        private List<Stack<Express>> city;

        public List<Stack<Express>> City
        {
            get { return city; }
        }

        public CityCollection()
        {
            city = new List<Stack<Express>>();
        }

        public void AddTerminal()
        {
            city.Add(new Stack<Express>());
        }

        public void AddExpressToTermianl(int terminalIndex, Express express)
        {
            if (terminalIndex >= 0 && terminalIndex < city.Count)
            {
                city[terminalIndex].Push(express);
            }
            else
            {
                Console.WriteLine("Неверный индекс вокзала.");
            }
        }

        public void DisplayCityTrains()
        {
            Console.WriteLine("Город: Москва");
            for (int i = 0; i < city.Count; i++)
            {
                Console.WriteLine($"Вокзал {i + 1}:");
                Stack<Express> station = city[i];
                foreach (Express express in station)
                {
                    express.Show();
                    Console.WriteLine();
                }
            }
        }
    }
}
