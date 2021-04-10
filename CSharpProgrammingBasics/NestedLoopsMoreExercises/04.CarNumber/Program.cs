using System;

namespace _04.CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    for (int l = start; l <= end; l++)
                    {
                        if ((j + l) % 2 != 0)
                        {
                            continue;
                        }
                        for (int m = start; m <= end; m++)
                        {
                            if (i % 2 == 0)
                            {

                                if (m % 2 != 1 || i < m)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                
                                if (m % 2 != 0 || i < m)
                                {
                                    continue;
                                }
                            }
                            Console.Write($"{i}{j}{l}{m} ");
                        }
                    }
                }
            }
        }
    }
}
