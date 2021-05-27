using System;

namespace _07.ConcatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string fName = Console.ReadLine();
            string lName = Console.ReadLine();
            string middle = Console.ReadLine();

            Console.WriteLine($"{fName}{middle}{lName}");

        }
    }
}
