using System;

namespace App
{
    class Program
    {
        static double CalculateSE(double x)
        {
            double se = 0;
            double currentElement = 1;
            double number = 0;
            while (0.0001 <= Math.Abs(currentElement))
            {
                se += currentElement;
                currentElement *= (-1) * (Math.Pow(x, 2)) / ((Math.Pow(number, 2)) * 4 + 6 * number + 2);
                number += 1;
            }

            return se;
        }
        static double CalculateSN(double x, int n)
        {
            double sn = 0;
            double currentElement = 1;

            for (int i = 0; i <= n; i++)
            {
                sn += currentElement;
                currentElement *= (-1) * (Math.Pow(x, 2)) / ((Math.Pow(i, 2)) * 4 + 6 * i + 2);
            }

            return sn;
        }
        static void Main(string[] args)
        {
            double A = 0.1;
            double B = 1;
            double k = (B - A) / 10;
            int n = 10;

            for (double x = A; x <= B; x += k)
            {
                x = Math.Round(x, 2);
                double se = CalculateSE(x);
                double y = Math.Cos(x);
                double sn = CalculateSN(x, n);

                Console.WriteLine("X = " + x.ToString("0.00") + " Y = " + y.ToString("0.0000") + " SN = " + sn.ToString("0.0000") + " SE = " + se.ToString("0.0000"));
            }
        }
    }
}
