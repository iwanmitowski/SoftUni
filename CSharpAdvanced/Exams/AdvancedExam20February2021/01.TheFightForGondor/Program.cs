using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> orcs = null;

            bool areDestroyed = false;

            for (int i = 1; i <= waves; i++)
            {
                orcs = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (orcs.Any() && plates.Any())
                {
                    if (orcs.Peek() > plates.Peek())
                    {
                        orcs.Push(orcs.Pop() - plates.Dequeue());
                    }
                    else if (orcs.Peek() < plates.Peek())
                    {
                        int currentPlate = plates.Dequeue() - orcs.Pop();

                        var currentPlates = plates.ToList();

                        plates.Clear();
                        plates.Enqueue(currentPlate);

                        currentPlates.ForEach(x => plates.Enqueue(x));
                    }
                    else
                    {
                        orcs.Pop();
                        plates.Dequeue();
                    }
                }

                if (!plates.Any())
                {
                    areDestroyed = true;
                    break;
                }
            }

            if (areDestroyed)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
            }

            if (orcs.Any())
            {
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
