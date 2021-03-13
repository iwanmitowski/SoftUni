using System;

namespace _01.PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int V = int.Parse(Console.ReadLine());
            int P1 = int.Parse(Console.ReadLine());
            int P2 = int.Parse(Console.ReadLine());
            decimal H = decimal.Parse(Console.ReadLine());

            decimal p1Liters = P1 * H;
            decimal p2Liters = P2 * H;

            decimal totalLiters = p1Liters + p2Liters;

            decimal poolFullness = totalLiters / V * 100;
            decimal p1Percents = p1Liters / totalLiters * 100;
            decimal p2Percents = p2Liters / totalLiters * 100;

            if (totalLiters <= V)
            {
                Console.WriteLine($"The pool is {poolFullness:f2}% full. Pipe 1: {p1Percents:f2}%. Pipe 2: {p2Percents:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {H} hours the pool overflows with {totalLiters-V:f2} liters.");
            }

        }
    }
}
