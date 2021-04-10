using System;

namespace _01.NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 1;
            bool isBigger = false;

            for (int i = 1; i <=n; i++)
            {
                for (int j = 1; j <=i; j++)
                {
                    Console.Write($"{counter} ");
                    counter++;

                    if (counter>n)
                    {
                        isBigger = true;
                        break;
                    }
                }

                if (isBigger)
                {
                    break;
                }
                Console.WriteLine();
            }

        }
    }
}
