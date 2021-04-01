using System;

namespace _09.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int widthFreeSpace = int.Parse(Console.ReadLine());
            int lengthFreeSpace = int.Parse(Console.ReadLine());
            int heightFreeSpace = int.Parse(Console.ReadLine());

            int totalSpace = widthFreeSpace * lengthFreeSpace * heightFreeSpace;

            int currentBoxesSpace = 0;

            string input = Console.ReadLine();
           
            while (input != "Done")
            {
                int boxes = int.Parse(input);

                currentBoxesSpace += boxes;

                if (currentBoxesSpace>totalSpace)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (totalSpace<=currentBoxesSpace)
            {
                Console.WriteLine($"No more free space! You need {currentBoxesSpace-totalSpace} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{totalSpace-currentBoxesSpace} Cubic meters left.");
            }
        }
    }
}
