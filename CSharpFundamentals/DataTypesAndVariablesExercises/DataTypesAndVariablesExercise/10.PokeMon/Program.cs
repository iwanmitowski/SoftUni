using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            decimal halfN = n * 0.5m;

            int targets = 0;

            while (n >= m)
            {
                n -= m;
                targets++;

                if (n * 1.0m == halfN)
                {
                    if (y > 0)
                    {
                        n /= y;
                    }
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(targets);
        }
    }
}
