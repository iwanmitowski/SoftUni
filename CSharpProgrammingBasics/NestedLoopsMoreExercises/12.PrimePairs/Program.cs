using System;

namespace _12.PrimePairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPair = int.Parse(Console.ReadLine());
            int secondPair = int.Parse(Console.ReadLine());
            int firstPairEnd = firstPair + int.Parse(Console.ReadLine());
            int secondPairEnd = secondPair + int.Parse(Console.ReadLine());

            for (int i = firstPair; i <= firstPairEnd; i++)
            {
                for (int j = secondPair; j <= secondPairEnd; j++)
                {
                    if (PrimeChecker(i) && PrimeChecker(j))
                    {
                        Console.WriteLine($"{i}{j}");
                    }

                }
            }
        }

        private static bool PrimeChecker(int num)
        {
            int counter = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    counter++;
                    if (counter > 2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
