using System;

namespace _04.SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                sum += (int)char.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
