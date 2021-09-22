using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows,cols];

            string word = Console.ReadLine();

            int letterCounter = 0;

            for (int i = 0; i < rows; i++)
            {
                if (i%2==0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = word[letterCounter++];

                        if (letterCounter == word.Length)
                        {
                            letterCounter = 0;
                        }
                    }
                }
                else
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        matrix[i, j] = word[letterCounter++];

                        if (letterCounter == word.Length)
                        {
                            letterCounter = 0;
                        }
                    }
                }
                
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
