using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int diagonalSum = 0;

            for (int i = 0; i < size; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                diagonalSum += numbers[i];
            }

            //Filling the matrix then:

            //for (int i = 0; i < size; i++)
            //{
            //    diagonalSum += matrix[i, i];
            //}

            Console.WriteLine(diagonalSum);
        }
    }
}
