using System;

namespace _04.BitDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int binary = int.Parse(Console.ReadLine());
            int toDestroy = int.Parse(Console.ReadLine());
            int mask = ~(1<<toDestroy);
            int newNumber = binary & mask;

            Console.WriteLine(newNumber);
        }
    }
}
