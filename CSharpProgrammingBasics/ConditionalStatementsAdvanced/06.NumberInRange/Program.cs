using System;

namespace _06.NumberInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(number>=-100 && number !=0 && number <=100 ? "Yes":"No");
        }
    }
}
