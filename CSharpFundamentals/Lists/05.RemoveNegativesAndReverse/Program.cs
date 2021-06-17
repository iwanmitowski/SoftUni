using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).Where(x => x >= 0).ToList();

            numbers.Reverse();

            string result = numbers.Count == 0 ? "empty" : string.Join(" ", numbers);

            Console.WriteLine(result);
        }
    }
}
