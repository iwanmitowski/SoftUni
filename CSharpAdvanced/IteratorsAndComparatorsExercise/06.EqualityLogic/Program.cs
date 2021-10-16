using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace _06.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashSet = new HashSet<Person>();
            var sortedSet = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                var person = new Person(tokens[0], int.Parse(tokens[1]));

                hashSet.Add(person);
                sortedSet.Add(person);
            }

            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);
        }
    }
}
