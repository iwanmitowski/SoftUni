using System;
using System.Linq;

namespace _02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            int sum = Console.ReadLine().Where(x => x > start && x < end).ToArray().Select(x => (int)x).Sum();

            Console.WriteLine(sum);
        }
    }
}
