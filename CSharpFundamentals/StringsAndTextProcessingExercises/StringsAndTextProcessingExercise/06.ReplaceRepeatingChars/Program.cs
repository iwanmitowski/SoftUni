using System;
using System.Linq;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letters = Console.ReadLine().ToArray();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < letters.Length-1; i++)
            {
                if (letters[i] == letters[i+1])
                {
                    continue;
                }

                sb.Append(letters[i]);
            }
            sb.Append(letters[letters.Length - 1]);
            Console.WriteLine(sb.ToString());
        }
    }
}
