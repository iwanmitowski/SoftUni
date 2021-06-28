using System;

namespace _02.BitAtFirstPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int binary = int.Parse(Console.ReadLine());

            binary >>= 1;

            Console.WriteLine(binary&1);
        }
    }
}
