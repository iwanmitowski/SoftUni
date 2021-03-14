using System;

namespace _07.FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal magnolias = 3.25M;
            int zumbul = 4;
            decimal rose = 3.50M;
            int cactus = 8;

            int magnooliasCount = int.Parse(Console.ReadLine());
            int zumbulsCount = int.Parse(Console.ReadLine());
            int rosessCount = int.Parse(Console.ReadLine());
            int cactusesCount = int.Parse(Console.ReadLine());
            decimal giftPrice = decimal.Parse(Console.ReadLine());

            decimal totalSum = magnolias * magnooliasCount + zumbul * zumbulsCount + rose * rosessCount + cactus * cactusesCount;
            totalSum *= 0.95M;

            if (giftPrice<=totalSum)
            {
                Console.WriteLine($"She is left with {Math.Floor(totalSum-giftPrice)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(giftPrice- totalSum)} leva.");

            }
        }
    }
}
