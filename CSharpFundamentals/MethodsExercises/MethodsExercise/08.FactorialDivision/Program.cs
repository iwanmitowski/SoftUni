using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            long n1Fact = Fact(int.Parse(Console.ReadLine()));
            long n2Fact = Fact(int.Parse(Console.ReadLine()));

            double result = n1Fact * 1.00 / n2Fact;

            Console.WriteLine($"{result:f2}");
        }

        private static long Fact(int num)
        {
            long fact = 1;
            for (int i = 2; i <= num; i++)
            {
                fact *= i;
            }

            return fact;
        }
    }
}
