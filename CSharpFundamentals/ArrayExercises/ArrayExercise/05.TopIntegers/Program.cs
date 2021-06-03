using System;
using System.Linq;

namespace _05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr.Skip(i+1).Where(x => x >= arr[i]).Count() == 0)
                {
                    Console.Write(arr[i] + " ");
                }
            }

        }
    }
}
