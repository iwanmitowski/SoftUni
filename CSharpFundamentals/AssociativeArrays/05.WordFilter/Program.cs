using System;
using System.Linq;

namespace _05.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                   .Split()
                   .Where(x => x.Length % 2 == 0)
                   .ToList()
                   .ForEach(
                       x => Console.WriteLine(x));
        }
    }
}
