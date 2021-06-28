using System;
using System.Linq;

namespace _05.OddTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                result ^= numbers[i];
            }

            Console.WriteLine(result);
        }
    }
}
