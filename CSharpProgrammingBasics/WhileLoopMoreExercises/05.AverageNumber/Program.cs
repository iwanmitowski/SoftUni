using System;

namespace _04.AverageNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += int.Parse(Console.ReadLine());

            }

            Console.WriteLine($"{sum/n:f2}");
        }
    }
}
