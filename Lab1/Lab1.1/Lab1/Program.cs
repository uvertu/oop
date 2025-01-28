using System;
namespace App
{
    class Programm
    {
        private static int GetIntValid(string x)
        {
            int nInt;
            do
            {
                Console.WriteLine("Введите значение " + x);
                string nTemp = Console.ReadLine();
                if (int.TryParse(nTemp, out int n))
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
        private static double GetDouleValid(string x)
        {
            double xDouble;
            do
            {
                Console.WriteLine("Введите значение " + x);
                string nTemp = Console.ReadLine();
                if (double.TryParse(nTemp, out double n))
                {
                    xDouble = n;
                    if (xDouble!= 0 && xDouble != 1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Значение " + x + " не может быть равным 0 или 1");
                    }
                }
                else
                {
                    Console.WriteLine("Значение " + x + " должно быть целым числом");
                }
            } while (true);
            return xDouble;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("ЗАДАНИЕ 1");
                int nInt = GetIntValid("n");
                int mInt =  GetIntValid("m");
                double xDouble = GetDouleValid("x"); 

                int multiplication = ++nInt * ++mInt;
                Console.WriteLine("1. ++n*++m = " + multiplication);
                Console.WriteLine("n = " + nInt + "\nm = " + mInt);
                bool conditionFirst = mInt++ < nInt;
                if (conditionFirst)
                {
                    Console.WriteLine("2. m++<n Условие выполняется");
                }
                else
                {
                    Console.WriteLine("2. m++<n Условие не выполняется");
                }
                Console.WriteLine("n = " + nInt + "\nm = " + mInt);
                bool conditionSecond = nInt++ > mInt;
                if (conditionSecond)
                {
                    Console.WriteLine("3. n++>m Условие выполняется");
                }
                else
                {
                    Console.WriteLine("3. n++>m Условие не выполняется");
                }
                Console.WriteLine("n = " + nInt + "\nm = " + mInt);
                double equation = xDouble + (1 / (Math.Pow(xDouble, 3) - xDouble)) - 2;
                Console.WriteLine("4. Значение выражения x + (1/(x^3-x))-2 = " + equation + "\n");
            }

        }
    }
}