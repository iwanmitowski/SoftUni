using System;

namespace _10.LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char c = char.Parse(Console.ReadLine());

            string result = char.IsUpper(c) ? "upper-case" : "lower-case";

            Console.WriteLine(result);
        }
    }
}
