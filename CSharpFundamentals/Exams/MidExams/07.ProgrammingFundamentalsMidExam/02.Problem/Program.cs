using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "Finish")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                int value = int.Parse(tokens[1]);

                switch (command)
                {

                    case "Add":
                        numbers.Add(value);
                        break;
                    case "Remove":
                        numbers.Remove(value);
                        break;
                    case "Replace":
                        int index = numbers.IndexOf(value);
                        numbers[index] = int.Parse(tokens[2]);
                        break;
                    case "Collapse":
                        numbers = numbers.Where(x => x >= value).ToList();
                        break;
                    default:
                        break;
                }


                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
