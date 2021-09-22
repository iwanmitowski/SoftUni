using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            
            int removed = 0;

            while (true)
            {
                int maxAttackedKnights = FindAttackedKnights(matrix);

                if (maxAttackedKnights == 0)
                {
                    break;
                }

                int attackerRow = -1;
                int attackerCol = -1;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    bool isFound = false;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 'K')
                        {
                            int current = CheckCurrentAttackedKnights(matrix, i, j);

                            if (current == maxAttackedKnights)
                            {
                                attackerRow = i;
                                attackerCol = j;
                                isFound = true;
                                break;
                            }
                        }
                    }

                    if (isFound)
                    {
                        break;
                    }
                }

                if (attackerRow != -1)
                {
                    matrix[attackerRow, attackerCol] = '0';
                    removed++;
                }
            }

            Console.WriteLine(removed);
        }

        private static int FindAttackedKnights(char[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int current = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'K')
                    {
                        current = CheckCurrentAttackedKnights(matrix, i, j);
                        if (current > count)
                        {
                            count = current;
                        }
                    }
                }
            }

            return count;
        }

        private static int CheckCurrentAttackedKnights(char[,] matrix, int i, int j)
        {
            int count = 0;

            if (i - 2 >= 0 && j - 1 >= 0)
            {
                if (matrix[i - 2, j - 1] == 'K')
                    count++;
            }
            if (i - 2 >= 0 && j + 1 < matrix.GetLength(0))
            {
                if (matrix[i - 2, j + 1] == 'K')
                    count++;
            }
            if (i - 1 >= 0 && j - 2 >= 0)
            {
                if (matrix[i - 1, j - 2] == 'K')
                    count++;
            }
            if (i - 1 >= 0 && j + 2 < matrix.GetLength(0))
            {
                if (matrix[i - 1, j + 2] == 'K')
                    count++;
            }
            if (i + 1 < matrix.GetLength(0) && j + 2 < matrix.GetLength(0))
            {
                if (matrix[i + 1, j + 2] == 'K')
                    count++;
            }
            if (i + 1 < matrix.GetLength(0) && j - 2 >= 0)
            {
                if (matrix[i + 1, j - 2] == 'K')
                    count++;
            }
            if (i + 2 < matrix.GetLength(0) && j - 1 >= 0)
            {
                if (matrix[i + 2, j - 1] == 'K')
                    count++;
            }
            if (i + 2 < matrix.GetLength(0) && j + 1 < matrix.GetLength(0))
            {
                if (matrix[i + 2, j + 1] == 'K')
                    count++;
            }

            return count;
        }
    }
}
