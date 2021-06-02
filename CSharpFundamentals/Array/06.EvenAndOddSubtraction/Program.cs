using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int even = 0;
            int odd = 0;
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var num in arr)
            {
                if (num%2==0)
                {
                    even += num;
                }
                else
                {
                    odd += num;
                }
            }

            Console.WriteLine(even-odd);
        }
    }
}
