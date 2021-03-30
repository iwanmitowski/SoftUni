using System;

namespace _10.ClockPt2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int k = 0; k <= 23; k++)
            {
                for (int i = 0; i < 60; i++)
                {
                    for (int j = 0; j < 60; j++)
                    {
                        Console.WriteLine($"{k} : {i} : {j}");
                    }
                }

            }
        }
    }
}
