using System;

namespace _05.EasterBake
{
    class Program
    {
        static void Main(string[] args)
        {
            int breads = int.Parse(Console.ReadLine());

            double sugarPackage = 950;
            double flourPackage = 750;


            int maxSugar = 0;
            int maxFlour = 0;

            int totalSugar = 0;
            int totalFlour = 0;

            for (int i = 0; i < breads; i++)
            {
                int sugar = int.Parse(Console.ReadLine());
                int flour = int.Parse(Console.ReadLine());

                if (sugar>maxSugar)
                {
                    maxSugar = sugar;
                }
                if (flour>maxFlour)
                {
                    maxFlour = flour;
                }

                totalSugar += sugar;
                totalFlour += flour;

            }

            int sPackages = (int)Math.Ceiling(totalSugar / sugarPackage);
            int fPackages = (int)Math.Ceiling(totalFlour / flourPackage);

            Console.WriteLine($"Sugar: {sPackages}");
            Console.WriteLine($"Flour: {fPackages}");
            Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");
        }
    }
}
