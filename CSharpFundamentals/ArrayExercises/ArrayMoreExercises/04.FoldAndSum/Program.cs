using System;
using System.Linq;

namespace _04.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] starting = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int k = starting.Length / 4;

            int[] firstRow = new int[k*2];
            int[] secondRow = new int[k*2];
            Array.Copy(starting,k,secondRow,0,k*2);

            for (int i = 0; i < k; i++)
            {
                firstRow[i] = starting[k-1-i];
                firstRow[k+i] = starting[starting.Length-1-i];
            }

            for (int i = 0; i < k*2; i++)
            {
                secondRow[i] += firstRow[i];
            }

            Console.WriteLine(string.Join(" ",secondRow));
        }
    }
}
