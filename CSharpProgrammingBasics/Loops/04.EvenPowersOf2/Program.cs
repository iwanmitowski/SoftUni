using System;

namespace _04.EvenPowersOf2
{
    class Program
    {
        static void Main(string[] args)
        {
            int pow = int.Parse(Console.ReadLine());

            for (int i = 0; i <= pow; i+=2)
            {
                Console.WriteLine(Math.Pow(2,i));
            }
        }
    }
}
