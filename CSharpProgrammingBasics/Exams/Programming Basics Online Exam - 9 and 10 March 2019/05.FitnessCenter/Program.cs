using System;

namespace _05.FitnessCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            int visitors = int.Parse(Console.ReadLine());

            double workout = 0;
            double protein = 0;

            int back = 0;
            int chest = 0;
            int legs = 0;
            int abs = 0;
            int proteinShake = 0;
            int proteinBar = 0;

            for (int i = 0; i < visitors; i++)
            {
                string activity = Console.ReadLine();

                if (activity == "Protein bar" || activity == "Protein shake")
                {
                    protein++;
                    switch (activity)
                    {
                        case "Protein bar":
                            proteinBar++;
                            break;
                        default:
                            proteinShake++;
                            break;
                    }
                }
                else
                {
                    workout++;

                    switch (activity)
                    {
                        case "Back":
                            back++;
                            break;
                        case "Chest":
                            chest++;
                            break;
                        case "Legs":
                            legs++;
                            break;
                        case "Abs":
                            abs++;
                            break;
                    }
                }
            }

            Console.WriteLine($"{back} - back");
            Console.WriteLine($"{chest} - chest");
            Console.WriteLine($"{legs} - legs");
            Console.WriteLine($"{abs} - abs");
            Console.WriteLine($"{proteinShake} - protein shake");
            Console.WriteLine($"{proteinBar} - protein bar");
            Console.WriteLine($"{(workout/visitors)*100:f2}% - work out");
            Console.WriteLine($"{(protein/visitors)*100:f2}% - protein");
        }
    }
}
