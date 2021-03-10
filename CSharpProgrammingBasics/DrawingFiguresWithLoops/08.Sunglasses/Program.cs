using System;

namespace _08.Sunglasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string border = "*";

            DrawBotTopBorder(border, n);
            for (int i = 0; i < n - 2; i++)
            {
                DrawBody(n,i);
            }
            DrawBotTopBorder(border, n);


        }

        static void DrawBotTopBorder(string border, int n)
        {
            for (int i = 0; i < 2 * n; i++)
            {
                Console.Write(border);

            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");

            }

            for (int i = 0; i < 2 * n; i++)
            {
                Console.Write(border);

            }
            Console.WriteLine();
        }

        static void DrawBody(int n,int row)
        {
            string border = "*";
            string glass = "/";
            string middle = "|";

            Console.Write(border);

            for (int i = 0; i < 2 * n - 2; i++)
            {
                Console.Write(glass);
            }

            Console.Write(border);

            if (row==(n-1)/2-1)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(middle);

                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(" ");

                }
            }

            Console.Write(border);

            for (int i = 0; i < 2 * n - 2; i++)
            {
                Console.Write(glass);
            }

            Console.Write(border);

            Console.WriteLine();

        }


    }
}
