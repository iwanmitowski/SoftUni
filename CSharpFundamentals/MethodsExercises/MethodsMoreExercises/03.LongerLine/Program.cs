using System;

namespace _03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
           double x1 = double.Parse(Console.ReadLine());
           double y1 = double.Parse(Console.ReadLine());
           double x2 = double.Parse(Console.ReadLine());
           double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double firstLineLength = CalculateLength(x1, y1, x2, y2);
            double secondLineLength = CalculateLength(x3, y3, x4, y4);

            if (firstLineLength>secondLineLength)
            {
                PrintLine(x1, y1, x2, y2);
            }
            else
            {
                PrintLine(x3, y3, x4, y4);
            }
        }

        private static double CalculateLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        static void PrintLine(double x1, double y1, double x2, double y2)
        {
            double first = Math.Abs(x1) + Math.Abs(y1);
            double secound = Math.Abs(x2) + Math.Abs(y2);

            if (first <= secound)
            {
                Console.Write($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.Write($"({x2}, {y2})({x1}, {y1})");
            }
        }
    }
}
