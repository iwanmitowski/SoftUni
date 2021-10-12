using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine().Split();
            var firstTuple = new Tuple<string, string>($"{first[0]} {first[1]}", first[2]);
            Console.WriteLine(firstTuple);

            var second = Console.ReadLine().Split();
            var secondTuple = new Tuple<string, int>(second[0], int.Parse(second[1]));
            Console.WriteLine(secondTuple);

            var third = Console.ReadLine().Split();
            var thirdTuple = new Tuple<int, double>(int.Parse(third[0]), double.Parse(third[1]));
            Console.WriteLine(thirdTuple);

        }
    }
}
