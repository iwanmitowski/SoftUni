using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            Func<int, bool> notDivisible = x => x % n != 0;

            int[] notDivisibleNumbers = numbers.Where(notDivisible).ToArray();

            List<int> reversed = new List<int>(notDivisibleNumbers.Length);

            for (int i = notDivisibleNumbers.Length - 1; i >= 0; i--)
            {
                reversed.Add(notDivisibleNumbers[i]);
            }

            Console.WriteLine(string.Join(" ",reversed));
        }
    }
}
