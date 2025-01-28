using System;
namespace App
{
    class Programm
    {
        private static double GetValid(string x)
        {
            double nInt;
            do
            {
                Console.WriteLine("Введите значение " + x);
                string nTemp = Console.ReadLine();
                if (double.TryParse(nTemp, out double n))
                {
                    nInt = n;
                    break;
                }
                else
                {
                    Console.WriteLine("Значение " + x + " должно быть целым числом");
                }
            } while (true);
            return nInt;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("ЗАДАНИЕ 2");
                double xCoordinate = GetValid("X1");
                double yCoordinate = GetValid("Y1");
                bool owned = xCoordinate >= -7 & xCoordinate <= 0 & yCoordinate <= 0 & yCoordinate >= -1;
                if (owned)
                {
                    Console.WriteLine("Точка принадлежит заштрихованной области\n");
                }
                else
                {
                    Console.WriteLine("Точка не принадлежит заштрихованной области\n");
                }
            }
        }
    }
}

