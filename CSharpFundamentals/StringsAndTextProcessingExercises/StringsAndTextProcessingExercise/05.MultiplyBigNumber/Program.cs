using System;
using System.Linq;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = Console.ReadLine().Select(x => x - '0').ToArray();
            int n2 = char.Parse(Console.ReadLine()) - '0';

            if (n2==0)
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }

            int reminder = 0;
            bool isNegative = false;
            
            //working with negative numbers

            for (int i = n1.Length - 1; i >= 0; i--)
            {
                if (n1[i] < 0)
                {
                    isNegative = true;
                    break;
                }
                int mult = n1[i] * n2 + reminder;
                reminder = mult > 10 ? mult / 10 : 0;

                if (i != 0)
                {
                    n1[i] = mult % 10;
                }
                else
                {
                    n1[i] = mult;
                }

            }

            if (isNegative)
            {
                Console.Write('-');
            }

            Console.WriteLine(string.Join("", isNegative ? n1.Skip(1) : n1));
        }
    }
}
