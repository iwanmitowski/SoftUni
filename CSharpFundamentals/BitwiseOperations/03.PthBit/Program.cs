using System;

namespace _03.PthBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int binary = int.Parse(Console.ReadLine());
            int shifting = int.Parse(Console.ReadLine());

            binary >>= shifting;

            Console.WriteLine(binary&1);
        }
    }
}
