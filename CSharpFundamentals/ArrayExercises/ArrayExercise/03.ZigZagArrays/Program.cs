using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] left = new int[n];
            int[] right = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] current = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i%2==0)
                {
                    left[i] = current[0];
                    right[i] = current[1];
                }
                else
                {
                    left[i] = current[1];
                    right[i] = current[0];
                }
            }

            Console.WriteLine(string.Join(" ",left));
            Console.WriteLine(string.Join(" ",right));
        }
    }
}
