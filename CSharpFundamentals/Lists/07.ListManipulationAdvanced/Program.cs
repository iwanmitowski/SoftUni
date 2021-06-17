using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            bool isChanged = false;

            while (command != "end")
            {
                string[] tokens = command.Split();

                int firstArg = 0;

                if (tokens[0] != "Filter" &&
                    tokens[0] != "PrintEven" &&
                    tokens[0] != "PrintOdd" &&
                    tokens[0] != "GetSum"
                    )
                {
                    firstArg = int.Parse(tokens[1]);
                }


                switch (tokens[0])
                {
                    case "Add":
                        numbers.Add(firstArg);
                        isChanged = true;
                        break;
                    case "Remove":
                        numbers.Remove(firstArg);
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(firstArg);
                        isChanged = true;
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(tokens[2]), firstArg);
                        isChanged = true;
                        break;
                    case "Contains":
                        Console.WriteLine(numbers.Contains(firstArg) ? "Yes" : "No such number");
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 != 0)));
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":
                        string condition = tokens[1];
                        firstArg = int.Parse(tokens[2]);
                        string result = Filter(numbers, condition, firstArg);
                        Console.WriteLine(result);
                        break;
                }

                command = Console.ReadLine();
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static string Filter(List<int> numbers, string condition, int firstArg)
        {
            switch (condition)
            {
                case "<":
                    return string.Join(" ", numbers.Where(x => x < firstArg));
                case ">":
                    return string.Join(" ", numbers.Where(x => x > firstArg));
                case "<=":
                    return string.Join(" ", numbers.Where(x => x <= firstArg));
            }

            return string.Join(" ", numbers.Where(x => x >= firstArg));
        }
    }
}
