using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] field = new int[fieldSize];

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var index in indexes)
            {
                if (index < 0 || index >= fieldSize)
                {
                    continue;
                }

                field[index] = 1;
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                
                int currentPosition =int.Parse(tokens[0]);

                if (currentPosition < 0 || currentPosition >= fieldSize || field[currentPosition] == 0)
                {
                    command = Console.ReadLine();
                    continue;
                }

                string direction = tokens[1];
                int jump = int.Parse(tokens[2]);
                field[currentPosition] = 0;

                if (direction == "right")
                {
                    while (currentPosition + jump >= 0 && currentPosition + jump < fieldSize)
                    {
                        if (field[currentPosition + jump] == 0)
                        {
                            field[currentPosition + jump] = 1;
                            break;
                        }

                        currentPosition += jump;
                    }
                }
                else
                {
                    while (currentPosition - jump >= 0 && currentPosition - jump < fieldSize)
                    {
                        if (field[currentPosition - jump] == 0)
                        {
                            field[currentPosition - jump] = 1;
                            break;
                        }

                        currentPosition -= jump;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
