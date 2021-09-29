using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList()
                .ForEach(x =>
                {
                    list.Add(x);
                });

            Console.WriteLine(string.Join(", ",list));
        }
    }
}
