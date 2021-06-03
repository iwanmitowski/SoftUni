using System;
using System.Linq;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();

            foreach (var word in arr2)
            {
                if (arr1.Contains(word))
                {
                    Console.Write(word+" ");
                }
            }
        }
    }
}
