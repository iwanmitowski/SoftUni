using System;

namespace _06.EasterCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int breads = int.Parse(Console.ReadLine());

            int maxPoints = 0;
            string chefName = string.Empty;

            for (int i = 0; i < breads; i++)
            {
                string chef = Console.ReadLine();

                int currentPoints = 0;

                string input = Console.ReadLine();

                while (input != "Stop")
                {
                    currentPoints+= int.Parse(input);

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{chef} has {currentPoints} points.");
                
                if (currentPoints>maxPoints)
                {
                    Console.WriteLine($"{chef} is the new number 1!");
                    chefName = chef;
                    maxPoints = currentPoints;
                }
            }

            Console.WriteLine($"{chefName} won competition with {maxPoints} points!");
        }
    }
}
