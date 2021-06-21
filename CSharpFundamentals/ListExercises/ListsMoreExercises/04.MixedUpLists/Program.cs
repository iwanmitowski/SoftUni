using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> second = Console.ReadLine().Split().Select(int.Parse).ToList();

            int secondToLast;
            int last;

            if (first.Count > second.Count)
            {
                secondToLast = first[first.Count - 2];
                last = first[first.Count - 1];
            }
            else
            {
                secondToLast = second[0];
                last = second[1];
            }

            first.AddRange(second);
            first.Remove(secondToLast);
            first.Remove(last);
            first = first.Where(x => x > Math.Min(secondToLast, last) && x < Math.Max(secondToLast, last)).ToList();
            first.Sort();

            Console.WriteLine(string.Join(" ", first));
        }
    }
}
