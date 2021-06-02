using System;

namespace _04.ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();

            Array.Reverse(arr);

            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
