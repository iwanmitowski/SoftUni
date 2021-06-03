using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.LIS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] sequences = new int[numbers.Length];
            int[] previous = new int[numbers.Length];

            int bestSequence = -1;
            int bestIndex = -1;

            for (int current = 0; current < numbers.Length; current++)
            {
                int currentSequence = 1;
                int prevIndex = -1;
                int currentNumber = numbers[current];

                for (int solIndex = 0; solIndex < current; solIndex++)
                {
                    int prevNumber = numbers[solIndex];
                    int prevSolution = sequences[solIndex];

                    if (currentNumber>prevNumber && currentSequence<=prevSolution)
                    {
                        currentSequence = prevSolution + 1;
                        prevIndex = solIndex;
                    }
                }

                sequences[current] = currentSequence;
                previous[current] = prevIndex;

                if (currentSequence>bestSequence)
                {
                    bestSequence = currentSequence;
                    bestIndex = current;
                }
            }

            List<int> result = new List<int>();

            while (bestIndex!=-1)
            {
                int currentNumber = numbers[bestIndex];
                bestIndex = previous[bestIndex];
                result.Add(currentNumber);
            }

            result.Reverse();

            Console.WriteLine(string.Join(" ",result));

        }
    }
}
