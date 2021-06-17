using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command!="end")
            {
                string[] tokens = command.Split();
                int firstArg = int.Parse(tokens[1]);

                switch (tokens[0])
                {
                    case "Add":
                        numbers.Add(firstArg);
                        break;
                    case "Remove":
                        numbers.Remove(firstArg);
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(firstArg);
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(tokens[2]), firstArg);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
