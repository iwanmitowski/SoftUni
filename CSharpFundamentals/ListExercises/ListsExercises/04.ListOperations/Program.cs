using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int firstArg = int.Parse(tokens[1]);
                        numbers.Add(firstArg);
                        break;

                    case "Insert":
                        firstArg = int.Parse(tokens[1]);
                        int secondArg = int.Parse(tokens[2]);

                        if (ValidateIndex(secondArg, numbers.Count))
                        {
                            Console.WriteLine("Invalid index");
                            command = Console.ReadLine();
                            continue;
                        }

                        numbers.Insert(secondArg, firstArg);
                        break;

                    case "Remove":
                        firstArg = int.Parse(tokens[1]);

                        if (ValidateIndex(firstArg, numbers.Count))
                        {
                            Console.WriteLine("Invalid index");
                            command = Console.ReadLine();
                            continue;
                        }

                        numbers.RemoveAt(firstArg);
                        break;

                    case "Shift":
                        string position = tokens[1];
                        firstArg = int.Parse(tokens[2]);
                        int number = 0;
                        switch (position)
                        {
                            case "left":
                                for (int i = 0; i < firstArg; i++)
                                {
                                    number = numbers.First();
                                    numbers.Add(number);
                                    numbers.RemoveAt(0);
                                }
                                break;
                            case "right":
                                for (int i = 0; i < firstArg; i++)
                                {
                                    number = numbers.Last();
                                    numbers.Insert(0,number);
                                    numbers.RemoveAt(numbers.Count-1);
                                }
                                break;
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",numbers));
        }

        private static bool ValidateIndex(int index, int count)
        {
            return index < 0 || index >= count;
        }
    }
}
