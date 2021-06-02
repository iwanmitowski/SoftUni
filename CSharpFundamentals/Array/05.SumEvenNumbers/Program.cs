using System;
using System.Linq;

namespace _05.SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .Sum();

            Console.WriteLine(sum);
        }
    }
}
