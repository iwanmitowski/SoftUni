using System;

namespace _06.VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int sum = 0;

            foreach (var c in word)
            {
                switch (c)
                {
                    case'a':
                        sum += 1;
                        break;
                    case 'e':
                        sum += 2;
                        break;
                    case 'i':
                        sum += 3;
                        break;
                    case 'o':
                        sum += 4;
                        break;
                    case 'u':
                        sum += 5;
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
