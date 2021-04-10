using System;

namespace _01.UniquePINCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstDigitMax = int.Parse(Console.ReadLine());
            int secondDigitMax = int.Parse(Console.ReadLine());
            int thirdDigitMax = int.Parse(Console.ReadLine());

            for (int i = 2; i <= firstDigitMax; i++)
            {
                if (i % 2 != 0)
                {
                    continue;
                }
                for (int j = 2; j <= secondDigitMax; j++)
                {
                    if (j == 2 || j == 3 || j == 5 || j == 7)
                    {
                        for (int k = 2; k <= thirdDigitMax; k++)
                        {
                            if (k % 2 != 0)
                            {
                                continue;
                            }
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                    
                }
            }
        }
    }
}
