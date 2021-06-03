using System;

namespace _01.EncryptSortPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] sumArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                int sum = 0;

                foreach (var letter in word)
                {
                    if (IsVowel(letter.ToString()))
                    {
                        sum += (int) letter * word.Length;
                    }
                    else
                    {
                        sum += (int) letter / word.Length;
                    }
                }

                sumArray[i] = sum;
            }

            Array.Sort(sumArray);

            Console.WriteLine(string.Join(Environment.NewLine,sumArray));
        }

        private static bool IsVowel(string letter)
        {
            switch (letter.ToLower())
            {
                case"a":
                case"e":
                case"i":
                case"u":
                case"o":
                    return true;
            }

            return false;
        }
    }
}
