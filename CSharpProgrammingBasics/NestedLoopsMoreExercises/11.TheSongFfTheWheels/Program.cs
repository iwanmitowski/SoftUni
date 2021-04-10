using System;

namespace _11.TheSongFfTheWheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());

            string password = string.Empty;
            int counter = 1;

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {

                        for (int d = 1; d <= 9; d++)
                        {
                            string pass = $"{a}{b}{c}{d} ";

                            if (a<b&&c>d&&(a * b) + (c * d) == m)
                            {
                                Console.Write($"{pass}");

                                if (counter == 4)
                                {
                                    password = pass;
                                }
                                counter++;

                            }

                        }

                    }

                }
            }
            Console.WriteLine();

            Console.WriteLine(password == string.Empty ? "No!" : $"Password: {password}");
        }
    }
}
