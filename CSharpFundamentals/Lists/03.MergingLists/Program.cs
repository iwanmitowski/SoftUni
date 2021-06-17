using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    public delegate void MyDelegate(IEnumerable<int> collection);
    class Program
    {
        static void Main(string[] args)
        {
            List<string> first = Console.ReadLine().Split().ToList();
            List<string> second = Console.ReadLine().Split().ToList();

            int minCount = Math.Min(first.Count, second.Count);

            List<string> result = new List<string>();

            for (int i = 0; i < minCount; i++)
            {
                result.Add(first.First());
                result.Add(second.First());
                first.RemoveAt(0);
                second.RemoveAt(0);
            }

            if (first.Count == 0)
            {
                result.AddRange(second);
            }
            else if (second.Count == 0)
            {
                result.AddRange(first);
            }

            Console.WriteLine(string.Join(" ",result));

        }
    }
}
