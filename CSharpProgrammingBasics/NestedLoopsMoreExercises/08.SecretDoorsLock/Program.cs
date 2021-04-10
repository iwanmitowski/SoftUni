using System;

namespace _08.SecretDoorsLock
{
    class Program
    {
        static void Main(string[] args)
        {
            int hundredsMax = int.Parse(Console.ReadLine());
            int dozenMax = int.Parse(Console.ReadLine());
            int numberMax = int.Parse(Console.ReadLine());

            for (int i = 2; i <= hundredsMax; i++)
            {
                if (i%2!=0)
                {
                    continue;
                }

                for (int j = 2; j <= dozenMax; j++)
                {
                    if (j==2||j==3||j==5||j==7)
                    {
                        for (int k = 2; k <= numberMax; k++)
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
