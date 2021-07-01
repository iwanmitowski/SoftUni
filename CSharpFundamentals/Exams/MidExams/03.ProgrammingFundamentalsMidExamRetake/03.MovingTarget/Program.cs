using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                int index = int.Parse(tokens[1]);
                int value = int.Parse(tokens[2]);

                if (index < 0 || index >= targets.Count)
                {
                    if (command == "Add")
                    {
                        Console.WriteLine("Invalid placement!");
                    }

                    input = Console.ReadLine();
                    continue;
                }

                if (command=="Shoot")
                {
                    targets[index] -= value;

                    if (targets[index]<=0)
                    {
                        targets.RemoveAt(index);
                    }
                }
                else if (command=="Add")
                {
                    targets.Insert(index, value);
                }
                else if (command=="Strike")
                {
                    if (index-value<0||index+value>=targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        targets.RemoveRange(index - value, value * 2+1);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|",targets));
        }
    }
}
