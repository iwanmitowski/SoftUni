using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> digits = new List<int>();
            List<char> nonDigits = new List<char>();

            foreach (var c in input)
            {
                if (char.IsDigit(c))
                {
                    digits.Add(int.Parse(c.ToString()));
                }
                else
                {
                    nonDigits.Add(c);
                }
            }

            List<int> take = new List<int>();
            List<int> skip = new List<int>();

            for (int i = 0; i < digits.Count; i++)
            {
                if (i % 2 == 0)
                {
                    take.Add(digits[i]);
                }
                else
                {
                    skip.Add(digits[i]);
                }
            }

            int skipped = 0;
            for (int i = 0; i < skip.Count(); i++)
            {

                for (int j = skipped; j < skipped + take[i]; j++)
                {
                    if (j>=nonDigits.Count)
                    {
                        break;
                    }

                    Console.Write(nonDigits[j]);
                }

                skipped += take[i]+skip[i];
            }

        }
    }
}
