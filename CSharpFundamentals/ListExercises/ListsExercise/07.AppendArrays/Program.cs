using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstSplit = string.Join(" ",Console.ReadLine().Split("|").Reverse().ToList());

            Console.WriteLine(string.Join(" ",firstSplit.Split(" ",StringSplitOptions.RemoveEmptyEntries)));
        }
    }
}
