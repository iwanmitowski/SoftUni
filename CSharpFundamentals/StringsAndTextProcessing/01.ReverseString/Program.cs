using System;
using System.Linq;

namespace _01.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input!="end")
            {
                Console.WriteLine($"{input} = {string.Join("",input.Reverse())}");

                input = Console.ReadLine();
            }
        }
    }
}
