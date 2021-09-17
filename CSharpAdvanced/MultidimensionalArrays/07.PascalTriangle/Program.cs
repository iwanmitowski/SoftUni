using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            long[][] triangle = new long[size][];

            for (int i = 0; i < size; i++)
            {
                triangle[i] = new long[i + 1];
                triangle[i][0] = 1;
                triangle[i][i] = 1;
            }

            if (size > 2)
            {
                for (int i = 2; i < size; i++)
                {
                    for (int j = 1; j < triangle[i].Length - 1; j++)
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(string.Join(" ", triangle[i]));
            }
        }
    }
}
