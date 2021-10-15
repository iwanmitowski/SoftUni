using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var people = new List<Person>();

            while (input != "END")
            {
                string[] tokens = input.Split();

                var person = new Person(tokens[0], int.Parse(tokens[1]), tokens[2]);
                people.Add(person);

                input = Console.ReadLine();
            }

            int matchesCount = 0;
            int n = int.Parse(Console.ReadLine()) - 1;

            if (n < people.Count)
            {
                Person filterPerson = people[n];

                matchesCount = people.Count(x => x.CompareTo(filterPerson) == 0);
            }

            int total = people.Count();

            Console.WriteLine(matchesCount > 1 ? $"{matchesCount} {total - matchesCount} {total}" : "No matches");
        }
    }
}
