using System;

namespace _02.LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char skip = char.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = start; i <= end; i++)
            {
                if (i == skip)
                {
                    continue;
                }
                for (int j = start; j <= end; j++)
                {
                    if (j == skip)
                    {
                        continue;
                    }
                    for (int k = start; k <= end; k++)
                    {
                        if (k==skip)
                        {
                            continue;
                        }
                        counter++;
                        Console.Write($"{(char)i}{(char)j}{(char)k} ");
                    }
                }
            }
            Console.Write(counter);
        }
    }
}
