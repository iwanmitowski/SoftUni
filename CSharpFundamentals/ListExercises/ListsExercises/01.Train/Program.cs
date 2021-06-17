using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine().Split().Select(int.Parse).ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command!="end")
            {
                if (command.Contains("Add"))
                {
                    string[] tokens = command.Split();

                    train.Add(int.Parse(tokens[1]));
                }
                else
                {
                    int currentPassangers = int.Parse(command);

                    for (int i = 0; i < train.Count; i++)
                    {
                        if (train[i]+ currentPassangers<=maxCapacity)
                        {
                            train[i] += currentPassangers;
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }


            Console.WriteLine(string.Join(" ",train));

        }
    }
}
