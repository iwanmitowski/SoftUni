using System;

namespace _04.Number100200
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(n < 100 ? "Less than 100" : n >= 100 && n <= 200 ? "Between 100 and 200" : "Greater than 200");
        }
    }
}
