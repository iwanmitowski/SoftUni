using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int spice = int.Parse(Console.ReadLine());

            int currentSpice = 0;

            int days = 0;

            while (spice>=100)
            {
                currentSpice += spice;

                if (currentSpice>=26)
                {
                    currentSpice -= 26;
                }

                spice -= 10;
                days++;
            }

            if (currentSpice >= 26)
            {
                currentSpice -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(currentSpice);


        }
    }
}
