using System;

namespace _05.Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actor = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double points = double.Parse(Console.ReadLine());

                double score = (name.Length * points)/2;
                academyPoints += score;
                if (academyPoints>=1250.5)
                {
                    Console.WriteLine($"Congratulations, {actor} got a nominee for leading role with {academyPoints:f1}!");
                    Environment.Exit(0);
                }

            }

            Console.WriteLine($"Sorry, {actor} you need {1250.5-academyPoints:f1} more!");

        }
    }
}
