using System;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> filter = x => x % 2 == 0;

            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numbers = Enumerable.Range(range[0], range[1] - range[0] + 1);

            string input = Console.ReadLine();

            if (input == "odd")
            {
                filter = x => x % 2 != 0;
            }

            Console.WriteLine(string.Join(" ", numbers.Where(filter)));
        }
    }
}
