using System;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var numbers = Enumerable.Range(1, n);

            int[] dividors = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, bool> isDivisible = num =>
            {
                foreach (var dividor in dividors)
                {
                    if (num % dividor != 0)
                    {
                        return false;
                    }
                }

                return true;
            };

            Console.WriteLine(string.Join(" ", numbers.Where(isDivisible)));
        }
    }
}
