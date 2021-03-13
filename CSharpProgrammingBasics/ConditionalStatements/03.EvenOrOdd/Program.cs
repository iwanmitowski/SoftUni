using System;

namespace _03.EvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string result = string.Empty;

            Console.WriteLine($"{(number % 2 == 0 ? "even" : "odd")}");
        }
    }
}
