using System;
using System.Linq;

namespace _01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];

            for (int i = 0; i < 3; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, numbers.OrderByDescending(x=>x)));
        }
    }
}
