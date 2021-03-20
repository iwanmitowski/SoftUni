using System;

namespace _13.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int nights = int.Parse(Console.ReadLine()) - 1;
            string roomType = Console.ReadLine();
            string grade = Console.ReadLine();

            int roomForOne = 18;
            int apartment = 25;
            int president = 35;

            decimal totalSum = 0;

            switch (roomType)
            {
                case "room for one person":
                    totalSum = nights * roomForOne;
                    break;
                case "apartment":
                    totalSum = nights * apartment;
                    if (nights<10)
                    {
                        totalSum *= 0.7M;
                    }
                    else if (nights>=10&&nights<=15)
                    {
                        totalSum *= 0.65M;
                    }
                    else if (nights>15)
                    {
                        totalSum *= 0.5M;
                    }
                    break;
                case "president apartment":
                    totalSum = nights * president;
                    if (nights < 10)
                    {
                        totalSum *= 0.9M;
                    }
                    else if (nights >= 10 && nights <= 15)
                    {
                        totalSum *= 0.85M;
                    }
                    else if (nights > 15)
                    {
                        totalSum *= 0.8M;
                    }
                    break;
                default:
                    break;
            }

            if (grade=="positive")
            {
                totalSum += totalSum * 0.25M;
            }
            else
            {
                totalSum -= totalSum * 0.1M;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
