using System;

namespace _06.ReversedChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[3];

            for (int i = 0; i < 3; i++)
            {
                arr[i] = Console.ReadLine();
            }

            Array.Reverse(arr);

            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
