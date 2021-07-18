using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input.Split(" : ");

                string course = tokens[0];
                string name = tokens[1];

                if (!dictionary.ContainsKey(course))
                {
                    dictionary.Add(course, new List<string>());
                }

                dictionary[course].Add(name);

                input = Console.ReadLine();
            }

            foreach ((string course, List<string> students) in dictionary.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{course}: {dictionary[course].Count}");
                foreach (var student in students.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {student}");
                }

            }
        }
    }
}
