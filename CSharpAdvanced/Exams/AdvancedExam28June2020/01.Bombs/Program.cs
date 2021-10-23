using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var bombRecepies = new Dictionary<int, string>();

            bombRecepies[40] = "Datura Bombs";
            bombRecepies[60] = "Cherry Bombs";
            bombRecepies[120] = "Smoke Decoy Bombs";

            var bombCount = new SortedDictionary<string, int>();

            bombCount["Datura Bombs"] = 0;
            bombCount["Cherry Bombs"] = 0;
            bombCount["Smoke Decoy Bombs"] = 0;

            Queue<int> bombEffect = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            while (bombEffect.Any() && bombCasing.Any())
            {
                int currentSum = bombEffect.Peek() + bombCasing.Peek();

                if (bombRecepies.ContainsKey(currentSum))
                {
                    bombCount[bombRecepies[currentSum]]++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else
                {
                    bombCasing.Push(bombCasing.Pop() - 5);
                }

                if (bombCount.Values.All(x => x >= 3))
                {
                    break;
                }
            }

            if (bombCount.Values.All(x => x >= 3))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffect)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach ((string bomb, int count) in bombCount)
            {
                Console.WriteLine($"{bomb}: {count}");
            }
        }
    }
}
