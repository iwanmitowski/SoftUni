using System;

namespace _04.SumОfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    counter++;

                    if (i+j==magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicNumber})");
                        
                        Environment.Exit(0);
                    }
                }

            }

            Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
        }
    }
}
