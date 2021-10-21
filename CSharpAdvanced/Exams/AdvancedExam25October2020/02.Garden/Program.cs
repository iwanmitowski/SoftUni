using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _02.Garden
{
    class Program
    {
        static int rows;
        static int cols;
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            rows = dimensions[0];
            cols = dimensions[1];

            var field = new int[rows, cols];

            var flowerPositions = new Queue<int>();

            string input = Console.ReadLine();


            while (input != "Bloom Bloom Plow")
            {
                int[] seedPositions = input.Split().Select(int.Parse).ToArray();

                if (!AreValidCoordinates(seedPositions[0], seedPositions[1]))
                {
                    Console.WriteLine("Invalid coordinates.");
                    input = Console.ReadLine();
                    continue;
                }

                flowerPositions.Enqueue(seedPositions[0]);
                flowerPositions.Enqueue(seedPositions[1]);

                input = Console.ReadLine();
            }

            while (flowerPositions.Any())
            {
                int currentRow = flowerPositions.Dequeue();
                int currentCol = flowerPositions.Dequeue();

                for (int i = 0; i < cols; i++)
                {
                    field[currentRow, i]++;
                }

                for (int i = 0; i < rows; i++)
                {
                    if (i == currentRow)
                    {
                        continue;
                    }

                    field[i, currentCol]++;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{field[i, j]} ");
                }
                Console.WriteLine();
            }

        }

        private static bool AreValidCoordinates(int row, int col)
        {
            return row >= 0 && row < rows &&
                   col >= 0 && col < cols;
        }
    }
}
