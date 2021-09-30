using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> sirPrinter = x => Console.WriteLine("Sir "+ x);
            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(sirPrinter);
        }
    }
}
