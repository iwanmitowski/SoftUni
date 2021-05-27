using System;
using System.Linq;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine().ToCharArray().Reverse();

            Console.WriteLine(string.Join("",word));
        }
    }
}
