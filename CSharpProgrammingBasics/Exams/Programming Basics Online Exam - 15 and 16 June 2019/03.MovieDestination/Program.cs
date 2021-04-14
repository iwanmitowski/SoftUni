using System;

namespace _03.MovieDestination
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            decimal totalSum = 0;

            switch (destination)
            {
                case "Dubai":
                    totalSum = season == "Winter" ? 45000 : 40000;
                    break;
                case "Sofia":
                    totalSum = season == "Winter" ? 17000 : 12500;
                    break;
                case "London":
                    totalSum = season == "Winter" ? 24000 : 20250;
                    break;
            }
            totalSum *= days;

            if (destination=="Dubai")
            {
                totalSum *= 0.7m;
            }
            else if (destination=="Sofia")
            {
                totalSum *= 1.25m;
            }

            if (budget>=totalSum)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {budget-totalSum:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {totalSum-budget:f2} leva more!");
            }
        }
    }
}
