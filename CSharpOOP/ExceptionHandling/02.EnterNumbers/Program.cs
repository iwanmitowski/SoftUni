using System;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    int number = ReadNumber(start, end);

                }
                catch (ArgumentNullException)
                {
                    i--;
                }
                catch (FormatException)
                {
                    i--;
                }
                catch (ArgumentOutOfRangeException)
                {
                    i--;
                }
            }
        }

        private static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            ValidateNumber(input, start, end);

            return int.Parse(input);
        }

        private static void ValidateNumber(string input, int start, int end)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException();
            }

            int number;

            if (!int.TryParse(input, out number))
            {
                throw new FormatException();
            }

            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
