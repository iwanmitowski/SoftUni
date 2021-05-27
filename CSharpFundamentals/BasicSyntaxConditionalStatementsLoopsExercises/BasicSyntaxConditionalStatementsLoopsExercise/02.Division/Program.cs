using System;

namespace _02.Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int dividor = 0;

            if (num % 10 == 0)
            {
                dividor = 10;
            }
            else if (num % 7 == 0)
            {
                dividor = 7;
            }
            else if (num % 6 == 0)
            {
                dividor = 6;
            }
            else if (num % 3 == 0)
            {
                dividor = 3;
            }
            else if (num % 2 == 0)
            {
                dividor = 2;
            }
            else
            {
                Console.WriteLine("Not divisible");
                Environment.Exit(0);
            }

            Console.WriteLine($"The number is divisible by {dividor}");
        }
    }
}
