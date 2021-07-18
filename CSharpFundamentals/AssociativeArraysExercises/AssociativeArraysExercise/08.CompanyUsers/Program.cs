using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(" -> ");

                string company = tokens[0];
                string user = tokens[1];

                if (!dictionary.ContainsKey(company))
                {
                    dictionary.Add(company, new List<string>() { user });
                }
                else if (!dictionary[company].Contains(user))
                {
                    dictionary[company].Add(user);
                }
                

                input = Console.ReadLine();
            }

            foreach ((string company, List<string> users) in dictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine(company);
                foreach (var student in users)
                {
                    Console.WriteLine($"-- {student}");
                }

            }
        }
    }
}
