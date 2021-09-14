using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split();

            var queue = new Queue<string>(people);

            int step = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int i = 1; i < step; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                string kid = queue.Dequeue();

                Console.WriteLine($"Removed {kid}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
