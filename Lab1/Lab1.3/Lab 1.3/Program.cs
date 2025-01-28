using System;
namespace App
{
    class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 3");
            float aFloat = 1000F;
            float bFloat = 0.0001F;
            double aDouble = 1000D;
            double bDouble = 0.0001D;
            float firstParenthesisFloat = (float)(Math.Pow(aFloat - bFloat, 2));
            float secondParenthesisFloat = (float)(Math.Pow(aFloat, 2) - (2 * aFloat * bFloat));
            float numeratorFloat = firstParenthesisFloat - secondParenthesisFloat;
            float denominatorFloat = (float)(Math.Pow(bFloat, 2));
            double firstParenthesisDouble = Math.Pow(aDouble - bDouble, 2);
            double secondParenthesisDouble = Math.Pow(aDouble, 2) - (2 * aDouble * bDouble);
            double numeratorDouble = firstParenthesisDouble - secondParenthesisDouble;
            double denominatorDouble = Math.Pow(bDouble, 2);
            Console.WriteLine("Результат FLOAT: " + numeratorFloat / denominatorFloat);
            Console.WriteLine("Результат DOUBLE: " + numeratorDouble / denominatorDouble);
        }
    }
}
