using System;

namespace _11.MultiplicationTable2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            if (n > 10)
            {
                Console.WriteLine($"{n} X {multiplier} = {n * multiplier}");
            }
            else
            {
                for (int i = multiplier; i <= 10; i++)
                {
                    Console.WriteLine($"{n} X {i} = {n * i}");
                }
            }
        }
    }
}
