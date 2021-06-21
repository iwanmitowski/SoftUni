using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> trace = Console.ReadLine().Split().Select(int.Parse).ToList();

            double sumFirst = 0;
            double sumSecond = 0;

            for (int i = 0; i < trace.Count / 2; i++)
            {
                if (trace[i] == 0)
                {
                    sumFirst *= 0.8;
                }
                else
                {
                    sumFirst += trace[i];
                }

                if (trace[trace.Count - 1 - i] == 0)
                {
                    sumSecond *= 0.8;
                }
                else
                {
                    sumSecond += trace[trace.Count - 1 - i];
                }
            }

            Console.WriteLine($"The winner is {(sumFirst < sumSecond ? "left" : "right")} with total time: {(sumFirst < sumSecond ? sumFirst : sumSecond)}");
        }
    }
}
