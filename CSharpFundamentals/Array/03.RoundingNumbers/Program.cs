using System;
using System.Linq;

namespace _03.RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{Convert.ToDecimal(num)} => {Convert.ToDecimal(Math.Round(num,MidpointRounding.AwayFromZero))}");
            }
        }
    }
}
