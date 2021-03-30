using System;

namespace _08.EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            int previousPair = n1 + n2;

            int diff = 0;
            int value = 0;

            for (int i = 1; i < n; i++)
            {
                n1 = int.Parse(Console.ReadLine());
                n2 = int.Parse(Console.ReadLine());

                int currentPair = n1 + n2;

                if (n1 + n2 == previousPair)
                {
                    value = currentPair;
                }
                else
                {
                    int currentDiff = Math.Abs(currentPair - previousPair);
                    if (currentDiff > diff)
                    {
                        diff = currentDiff;
                    }

                }
                previousPair = currentPair;
            }
            value = previousPair;

            if (diff==0)
            {
                Console.WriteLine($"Yes, value={value}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={diff}");
            }
        }
    }
}
