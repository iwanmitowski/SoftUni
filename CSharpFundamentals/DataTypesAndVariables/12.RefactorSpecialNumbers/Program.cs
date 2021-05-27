using System;

namespace _12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int kolkko = int.Parse(Console.ReadLine());
            bool toe = false;

            for (int ch = 1; ch <= kolkko; ch++)
            {
                int obshto = 0;
                int takova = ch;

                while (takova > 0)
                {
                    obshto += takova % 10;
                    takova  /= 10;
                }

                toe = (obshto == 5) || (obshto == 7) || (obshto == 11);
                Console.WriteLine($"{ch} -> {toe}");
            }

        }
    }
}
