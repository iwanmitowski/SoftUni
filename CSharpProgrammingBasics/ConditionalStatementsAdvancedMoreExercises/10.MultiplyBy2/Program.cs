using System;

namespace _10.MultiplyBy2
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = decimal.Parse(Console.ReadLine());

            while (number>=0)
            {
                Console.WriteLine($"Result: {number*2:f2}");

                number = decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine("Negative number!");
        }
    }
}
