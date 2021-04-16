using System;

namespace _05.EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggs = int.Parse(Console.ReadLine());

            int redEggs = 0;
            int orangeEggs = 0;
            int blueEggs = 0;
            int greenEggs = 0;

            int maxEggs = 0;
            string maxColor = string.Empty;

            for (int i = 0; i < eggs; i++)
            {
                string color = Console.ReadLine();

                switch (color)
                {
                    case "red":
                        redEggs++;
                        if (redEggs > maxEggs)
                        {
                            maxEggs = redEggs;
                            maxColor = color;
                        }
                        break;
                    case "orange":
                        orangeEggs++;
                        if (orangeEggs > maxEggs)
                        {
                            maxEggs = orangeEggs;
                            maxColor = color;
                        }
                        break;
                    case "blue":
                        blueEggs++;
                        if (blueEggs > maxEggs)
                        {
                            maxEggs = blueEggs;
                            maxColor = color;
                        }
                        break;
                    case "green":
                        greenEggs++;
                        if (greenEggs > maxEggs)
                        {
                            maxEggs = greenEggs;
                            maxColor = color;
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Red eggs: {redEggs}");
            Console.WriteLine($"Orange eggs: {orangeEggs}");
            Console.WriteLine($"Blue eggs: {blueEggs}");
            Console.WriteLine($"Green eggs: {greenEggs}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {maxColor}");
        }
    }
}
