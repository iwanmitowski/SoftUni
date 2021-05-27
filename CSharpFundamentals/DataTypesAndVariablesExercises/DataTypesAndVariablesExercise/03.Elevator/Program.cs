using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            double people = double.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            people /= capacity;

            Console.WriteLine(Math.Ceiling(people));
        }
    }
}
