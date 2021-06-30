using System;
using System.Linq;

namespace _02.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int queue = int.Parse(Console.ReadLine());

            int[] wagon = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < wagon.Length; i++)
            {
                if (wagon[i] != 4)
                {
                    int freeSpace = 4 - wagon[i];

                    if (freeSpace > queue)
                    {
                        freeSpace = queue;
                    }

                    wagon[i] += freeSpace;
                    queue -= freeSpace;

                }
            }

            if (wagon.Sum() < wagon.Length * 4 && queue==0)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else if (wagon.Sum() == wagon.Length * 4 && queue>0)
            {
                Console.WriteLine($"There isn't enough space! {queue} people in a queue!");

            }

            Console.WriteLine(string.Join(" ", wagon));
        }
    }
}
