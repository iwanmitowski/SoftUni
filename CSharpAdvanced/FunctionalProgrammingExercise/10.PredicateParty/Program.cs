using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                var tokens = input.Split();

                string command = tokens[0];
                string condition = tokens[1];

                //BAD PRATCTICE!!!
                //dynamic value = condition == "Length" ? int.Parse(tokens[2]) : tokens[2];


                Predicate<string> nameFilter = null;

                if (condition == "StartsWith")
                {
                    nameFilter = name => name.StartsWith(tokens[2]);
                }
                else if (condition == "EndsWith")
                {
                    nameFilter = name => name.EndsWith(tokens[2]);
                }
                else if (condition == "Length")
                {
                    nameFilter = name => name.Length == int.Parse(tokens[2]);
                }

                switch (command)
                {
                    case "Double":

                        //CONVERTING FUNC TO PREDICATE !!! Works in both directions!
                        string name = guests.FirstOrDefault(new Func<string, bool>(nameFilter));
                        int count = guests.Count();

                        for (int i = 1; i <= count; i++)
                        {
                            if (guests[i-1] == name)
                            {
                                guests.Insert(i-1, name);
                            }
                        }

                        break;
                    case "Remove":
                        guests.RemoveAll(nameFilter);
                        break;
                }

                input = Console.ReadLine();
            }

            if (guests.Any())
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
