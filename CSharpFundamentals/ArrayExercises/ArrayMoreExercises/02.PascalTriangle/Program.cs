using System;

namespace _02.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] previous = new long[] { 1, 1 };
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(previous[0]);

            for (int i = 1; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", previous));
                long[] current = new long[previous.Length + 1];

                current[0] = 1;
                current[current.Length - 1] = 1;

                for (int j = 1; j < current.Length - 1; j++)
                {
                    current[j] = previous[j] + previous[j - 1];
                }
                
                previous = current;
            }

        }
    }
}
