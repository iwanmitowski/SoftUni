using System;
using System.Linq;

namespace _02.FootballResults
{
    class Program
    {
        static void Main(string[] args)
        {

            int w = 0;
            int l = 0;
            int d = 0;

            for (int i = 0; i < 3; i++)
            {
                int[] points = Console.ReadLine().Split(":").Select(x=>int.Parse(x.ToString())).ToArray();

                if (points[0]>points[1])
                {
                    w++;
                }
                else if (points[0]==points[1])
                {
                    d++;
                }
                else
                {
                    l++;
                }
            }
            Console.WriteLine($"Team won {w} games.");
            Console.WriteLine($"Team lost {l} games.");
            Console.WriteLine($"Drawn games: {d}");
          
        }
    }
}
