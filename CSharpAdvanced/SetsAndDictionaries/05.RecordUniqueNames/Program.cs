using System;
using System.Collections.Generic;

namespace _05.RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                names.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
