using System;

namespace _09.CharsToString
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

            Console.WriteLine(string.Join("", arr));
        }
    }
}
