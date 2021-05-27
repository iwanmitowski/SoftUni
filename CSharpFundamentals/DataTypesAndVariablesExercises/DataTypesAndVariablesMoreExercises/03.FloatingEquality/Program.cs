using System;

namespace _03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal a = decimal.Parse(Console.ReadLine()); 
            decimal b = decimal.Parse(Console.ReadLine());
            decimal eps = 0.000001m;
            bool result = Math.Abs(a - b) < eps;

            Console.WriteLine(result);
        }
    }
}
