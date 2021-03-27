using System;

namespace _05.DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            int n = int.Parse(Console.ReadLine());

            for (int j = 0; j < n; j++)
            {
                int i = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    p1++;
                }
                if (i % 3 == 0)
                {
                    p2++;
                }
                if (i % 4 == 0)
                {
                    p3++;
                }

            }

            p1 = (p1 / n) * 100;
            p2 = (p2 / n) * 100;
            p3 = (p3 / n) * 100;


            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");

        }
    }
}
