using System;

namespace _10.InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(number >= 100 &&number <=200|| number == 0 ?  string.Empty : "invalid");

        }
    }
}
