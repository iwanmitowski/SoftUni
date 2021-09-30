using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameSize = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, bool> filter = name => name.Length <= nameSize;

            names
                .Where(filter)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
