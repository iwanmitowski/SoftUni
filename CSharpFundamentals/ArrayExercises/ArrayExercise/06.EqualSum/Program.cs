using System;
using System.Linq;

namespace _06.EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool isFound = false;
            int index = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                int left = arr.Take(i).Sum();
                int right = arr.Skip(i+1).Sum();

                if (left==right)
                {
                    isFound = true;
                    index = i;
                    break;
                }
            }

            if (isFound)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
