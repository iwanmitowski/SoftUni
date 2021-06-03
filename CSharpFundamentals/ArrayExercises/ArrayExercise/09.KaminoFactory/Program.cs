using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int bestSampleIndex = -1;

            int bestStartingIndex = int.MaxValue;
            int bestSequenceSum = -1;
            int bestSequenceCount = -1;

            int[] finalDna = new int[length];

            int sampleCounter = 0;

            while (input != "Clone them!")
            {
                sampleCounter++;
                int[] dna = input
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int startingIndex = -1;
                int currentSum = dna.Sum();
                int currentSequence = 1;
                int currentMaxSequence = 1;

                int currentBestStartingIndex = -1;

                for (int i = 1; i < dna.Length; i++)
                {
                    if (dna[i - 1] != dna[i])
                    {
                        currentSequence = 1;
                        startingIndex = i;
                    }
                    else
                    {
                        if (dna[i] == 1)
                        {
                            currentSequence++;

                        }
                    }

                    if (currentSequence > currentMaxSequence)
                    {
                        currentMaxSequence = currentSequence;
                        currentBestStartingIndex = startingIndex;
                    }
                }

                if (currentMaxSequence >= bestSequenceCount)
                {
                    if (bestStartingIndex > currentBestStartingIndex)
                    {
                        bestSequenceCount = currentMaxSequence;
                        bestStartingIndex = currentBestStartingIndex;
                        bestSequenceSum = currentSum;
                        bestSampleIndex = sampleCounter;
                        finalDna = dna;
                    }
                    else if (bestStartingIndex == currentBestStartingIndex &&
                             currentSum > bestSequenceSum)
                    {
                        bestSequenceCount = currentMaxSequence;
                        bestStartingIndex = currentBestStartingIndex;
                        bestSequenceSum = currentSum;
                        bestSampleIndex = sampleCounter;
                        finalDna = dna;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSampleIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(" ", finalDna));
        }
    }
}
