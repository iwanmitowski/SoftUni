using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Authentication;
using System.Threading;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input.Split();

                string command = tokens[0];

                if (command == "exchange")
                {
                    int index = int.Parse(tokens[1]);

                    if (index < 0 || index >= array.Length)
                    {
                        Console.WriteLine("Invalid index");
                        input = Console.ReadLine();
                        continue;
                    }

                    array = Exchange(index, array);
                }
                else if (command == "max" || command == "min")
                {
                    string type = tokens[1];

                    int index = command == "max" ? Max(type, array) : Min(type, array);

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }
                else if (command == "first" || command == "last")
                {
                    int count = int.Parse(tokens[1]);

                    if (count < 0 || count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                        input = Console.ReadLine();
                        continue;
                    }

                    string type = tokens[2];

                    int[] collection = command == "first" ? FirstCount(type, array, count):LastCount(type, array, count);

                    if (!collection.Select(x => x % 2 == 0).Any() || !collection.Select(x => x % 2 == 1).Any())
                    {
                        Console.WriteLine("[]");
                    }
                    else
                    {
                        Console.WriteLine($"[{string.Join(", ", collection)}]");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        private static int[] LastCount(string type, int[] array, int count)
        {
            int[] helper = new int[count];
            int filled = 0;

            if (type == "even")
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == 0)
                    {
                        helper[filled] = array[i];
                        filled++;
                    }

                    if (filled == count)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == 1)
                    {
                        helper[filled] = array[i];
                        filled++;
                    }

                    if (filled == count)
                    {
                        break;
                    }
                }
            }

            if (filled < count)
            {
                helper = helper.Where(x => x != 0).ToArray();
            }

            Array.Reverse(helper);
            return helper;
        }

        private static int[] FirstCount(string type, int[] array, int count)
        {
            int[] helper = new int[count];
            int filled = 0;

            if (type == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                    {
                        helper[filled] = array[i];
                        filled++;
                    }

                    if (filled == count)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 1)
                    {
                        helper[filled] = array[i];
                        filled++;
                    }

                    if (filled == count)
                    {
                        break;
                    }
                }
            }

            if (filled < count)
            {
                helper = helper.Where(x => x != 0).ToArray();
            }

            return helper;
        }

        private static int Min(string type, int[] array)
        {
            int minNum = int.MaxValue;
            int index = -1;

            if (type == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] <= minNum)
                    {
                        minNum = array[i];
                        index = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 1 && array[i] <= minNum)
                    {
                        minNum = array[i];
                        index = i;
                    }
                }
            }

            return index;
        }

        private static int Max(string type, int[] array)
        {
            int maxNum = int.MinValue;
            int index = -1;

            if (type == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] >= maxNum)
                    {
                        maxNum = array[i];
                        index = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 1 && array[i] >= maxNum)
                    {
                        maxNum = array[i];
                        index = i;
                    }
                }
            }

            return index;
        }

        private static int[] Exchange(int index, int[] array)
        {
            int[] first = array.Skip(index + 1).Take(array.Length - index).ToArray();
            int[] last = array.Take(index + 1).ToArray();
            int[] combined = first.Concat(last).ToArray();

            return combined;
        }
    }
}
