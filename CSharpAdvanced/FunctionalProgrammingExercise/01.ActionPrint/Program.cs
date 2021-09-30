using System;
using System.Linq;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = x => Console.WriteLine(x);
            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(printer); 
        }
    }
}
