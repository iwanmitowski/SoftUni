using System;

namespace _06.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                bool isSpecial = true;

                foreach (var dig in i.ToString())
                {
                    int currentDigit = int.Parse(dig.ToString());
                    
                    if (currentDigit == 0 || n % currentDigit != 0)
                    {
                        isSpecial = false;
                        break;
                    }
                }

                if (isSpecial)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
