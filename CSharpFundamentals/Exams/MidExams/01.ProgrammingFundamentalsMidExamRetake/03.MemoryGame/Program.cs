using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();
            int turns = 0;

            while (input != "end" && elements.Any())
            {
                turns++;
                int[] numbers = input.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).OrderBy(x => x).ToArray();
                int firstIndex = numbers[0];
                int secondIndex = numbers[1];

                if (firstIndex == secondIndex || numbers.Any(x => x < 0 || x >= elements.Count))
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    elements.Insert(elements.Count / 2, $"-{turns}a");
                    elements.Insert(elements.Count / 2, $"-{turns}a");
                }
                else if (elements[firstIndex] == elements[secondIndex])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[firstIndex]}!");
                    elements.RemoveAt(secondIndex);
                    elements.RemoveAt(firstIndex);
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                input = Console.ReadLine();
            }

            if (elements.Any())
            {
                Console.WriteLine($"Sorry you lose :(");
                Console.WriteLine(string.Join(" ",elements));
            }
            else
            {
                Console.WriteLine($"You have won in {turns} turns!");
            }
        }
    }
}
