using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];

            for (int i = 0; i < size; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                matrix[i] = new int[size];

                for (int j = 0; j < size; j++)
                {
                    matrix[i][j] = numbers[j];
                }
            }

            string input = Console.ReadLine();

            while (input!="END")
            {

                string[] tokens = input.Split();

                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row < 0 || row >= size ||
                    col < 0 || col >= size)
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine();
                    continue;
                }

                switch (command)
                {
                    case "Add":
                        matrix[row][col] += value;
                        break;
                    default:
                        matrix[row][col] -= value;
                        break;
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < size; i++)
            {
                var matr = matrix[i];
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
