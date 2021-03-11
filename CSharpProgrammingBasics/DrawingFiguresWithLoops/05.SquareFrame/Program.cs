using System;

namespace _05.SquareFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string corner = "+";
            string horizontalBorder = "-";
            string verticalBorder = "|";

            DrawTopBot(corner, horizontalBorder, n);
            for (int i = 0; i < n-2; i++)
            {
                DrawMiddlePart(verticalBorder, horizontalBorder, n);
                Console.WriteLine();
            }
            DrawTopBot(corner, horizontalBorder, n);

        }

        static void DrawTopBot(string corner, string horizontalBorder, int n)
        {
            Console.Write(corner);
            Console.Write(" ");
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(horizontalBorder);
                Console.Write(" ");

            }
            Console.Write(corner);
            Console.WriteLine();

        }

        static void DrawMiddlePart(string verticalBorder, string horizontalBorder, int n)
        {
            Console.Write(verticalBorder);
            Console.Write(" ");
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(horizontalBorder);
                Console.Write(" ");

            }
            Console.Write(verticalBorder);

        }

    }
}
