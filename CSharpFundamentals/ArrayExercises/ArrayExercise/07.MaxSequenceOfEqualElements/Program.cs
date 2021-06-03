using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int index = -1;
            int count = 1;
            int maxCount = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i-1]!=arr[i])
                {
                    count = 1;
                }
                else
                {
                    count++;
                }

                if (count>maxCount)
                {
                    index = i;
                    maxCount = count;
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(arr[index]+" ");
            }
        }
    }
}
