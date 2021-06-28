using System;

namespace _06.TriBitSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            int binary = int.Parse(Console.ReadLine());
            int shift = int.Parse(Console.ReadLine());
            int mask = 7 << shift;
            Console.WriteLine(binary ^ mask);
        }
    }
}
