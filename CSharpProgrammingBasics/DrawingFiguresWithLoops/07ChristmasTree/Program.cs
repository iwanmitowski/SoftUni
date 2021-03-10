using System;

namespace _07ChristmasTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string sky = " ";
            string star = "*";
            string log = " | ";

            
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j < n-i; j++)
                {
                    Console.Write(sky);
                }

                for (int k = 0; k < i; k++)
                {
                    Console.Write(star);
                }

                Console.Write(log);

                for (int k = 0; k < i; k++)
                {
                    Console.Write(star);
                }

                for (int j = 0; j < n - i; j++)
                {
                    Console.Write(sky);
                }
                Console.WriteLine();
            }
        }

    }
}
