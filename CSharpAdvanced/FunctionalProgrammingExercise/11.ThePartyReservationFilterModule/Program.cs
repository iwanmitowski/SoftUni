using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _11.ThePartyReservationFilterModule
{
    class Function
    {
        public Function(string name, Func<string, bool> function)
        {
            Name = name;
            Func = function;
        }

        public string Name { get; set; }

        public Func<string,bool> Func { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();
            var filters = new HashSet<Function>();

            while (input != "Print")
            {
                string[] tokens = input.Split(";");
                string command = tokens[0];
                string condition = tokens[1];
                string value = tokens[2];

                string name = condition + value;

                if (command=="Add filter")
                {
                    switch (condition)
                    {
                        case "Starts with":
                            filters.Add(new Function(name, x => !x.StartsWith(value)));
                            break;
                        case "Ends with":
                            filters.Add(new Function(name, x => !x.EndsWith(value)));
                            break;
                        case "Length":
                            filters.Add(new Function(name, x => x.Length != int.Parse(value)));
                            break;
                        case "Contains":
                            filters.Add(new Function(name, x => !x.Contains(value)));
                            break;
                    }
                }
                else
                {
                    var funcToRemove = filters.FirstOrDefault(x => x.Name == name);
                    filters.Remove(funcToRemove);
                }

                input = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                names = names.Where(filter.Func).ToList();
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
