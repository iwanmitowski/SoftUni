using System;
using System.Linq;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            PrintTopNumbers(num);
        }

        private static void PrintTopNumbers(string num)
        {
            for (int i = 1; i <= int.Parse(num); i++)
            {
                if (SumOfDigitsK8(i) && AnyDigIsOdd(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool AnyDigIsOdd(int i)
        {
            return i.ToString()
                .ToCharArray()
                .Select(d=>int.Parse(d.ToString()))
                .Any(d => d % 2 == 1);
        }

        private static bool SumOfDigitsK8(int i)
        {
            int sum = i.ToString()
                .ToCharArray()
                .Select(d => int.Parse(d.ToString()))
                .Sum();

            return sum % 8 == 0;
        }
    }
}
