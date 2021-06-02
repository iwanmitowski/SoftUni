using System;
using System.ComponentModel;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (arr.Length!=1)
            {
                int[] helper = new int[arr.Length - 1];

                for (int i = 1; i < arr.Length; i++)
                {
                    helper[i-1] = arr[i - 1] + arr[i];
                }

                arr = helper;
            }

            Console.WriteLine(arr[0]);
        }
    }
}
