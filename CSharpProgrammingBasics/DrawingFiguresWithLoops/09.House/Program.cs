using System;
using System.Text;
using System.Linq;

namespace _09.House
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            DrawRoof(n);

            for (int i = 0; i < n - (n + 1) / 2; i++)
            {
                DrawBody(n);
                Console.WriteLine();

            }
        }

        static void DrawRoof(int n)
        {
            string sky = "-";
            string roof = "*";

            int stars;
            if (n % 2 == 0)
            {
                stars = 2;
            }
            else
            {
                stars = 1;
            }

            for (int i = 0; i < (n + 1) / 2; i++)
            {
                for (int j = 0; j < (n - stars) / 2; j++)
                {
                    Console.Write(sky);
                }
                for (int k = 0; k < stars; k++)
                {
                    Console.Write(roof);
                    if (k==n-1)
                    {
                        break;
                    }
                }
                for (int j = 0; j < (n - stars) / 2; j++)
                {
                    Console.Write(sky);
                }
                stars += 2;
                Console.WriteLine();
            }
            
        }

        static void DrawBody(int n)
        {
            string wall = "|";
            string filling = "*";

            Console.Write(wall);
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(filling);
            }
            Console.Write(wall);

        }
    }
}
