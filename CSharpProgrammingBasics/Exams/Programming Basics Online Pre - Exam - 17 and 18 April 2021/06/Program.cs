using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTop = int.Parse(Console.ReadLine());
            int secondTop = int.Parse(Console.ReadLine());
            int thirdTop = int.Parse(Console.ReadLine());

            for (int i = 2; i <= firstTop; i++)
            {
                if (i%2!=0)
                {
                    continue;
                }
                for (int j = 2; j <= secondTop; j++)
                {
                    if (j==2||j==3||j==5||j==7)
                    {
                        for (int k = 2; k <= thirdTop; k++)
                        {
                            if (k%2!=0)
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
