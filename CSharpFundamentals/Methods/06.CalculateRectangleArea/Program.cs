using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = int.Parse(Console.ReadLine());
            double b = int.Parse(Console.ReadLine());

            double result = CalcArea(a, b);

            Console.WriteLine(result);

        }

        private static double CalcArea(double a, double b)
        {
            return a * b;
        }
    }
}
