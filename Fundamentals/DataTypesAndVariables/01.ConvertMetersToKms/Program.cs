using System;

namespace _01.ConvertMetersToKms
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal toMeter = int.Parse(Console.ReadLine()) / 1000.0m;

            Console.WriteLine($"{toMeter:f2}");
        }
    }
}
