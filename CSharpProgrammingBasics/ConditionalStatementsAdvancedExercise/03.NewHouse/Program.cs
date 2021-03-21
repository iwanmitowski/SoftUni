using System;

namespace _03.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            int rose = 5;
            double dahlia = 3.8;
            double tulip = 2.8;
            int narcissus = 3;
            double gladiolus = 2.5;

            double finalSum = 0;

            switch (flowerType)
            {
                case "Roses":
                    finalSum = rose * flowerCount;
                    if (flowerCount > 80)
                    {
                        finalSum *= 0.9;
                    }
                    break;
                case "Dahlias":
                    finalSum = dahlia * flowerCount;
                    if (flowerCount > 90)
                    {
                        finalSum *= 0.85;
                    }
                    break;
                case "Tulips":
                    finalSum = tulip * flowerCount;
                    if (flowerCount > 80)
                    {
                        finalSum *= 0.85;
                    }
                    break;
                case "Narcissus":
                    finalSum = narcissus * flowerCount;
                    if (flowerCount < 120)
                    {
                        finalSum *= 1.15;
                    }
                    break;
                case "Gladiolus":
                    finalSum = gladiolus * flowerCount;
                    if (flowerCount < 80)
                    {
                        finalSum *= 1.2;

                    }
                    break;
                default:
                    break;
            }

            if (finalSum<=budget)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {budget-finalSum:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {finalSum-budget:f2} leva more.");
            }
        }
    }
}
