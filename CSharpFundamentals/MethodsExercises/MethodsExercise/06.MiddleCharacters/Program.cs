using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string result = FindMiddle(word);

            Console.WriteLine(result);
        }

        private static string FindMiddle(string word)
        {
            StringBuilder sb = new StringBuilder();

            if (word.Length%2==1)
            {
                sb.Append(word[word.Length/2]);
            }
            else
            {
                sb.Append(word[word.Length/2 - 1]);
                sb.Append(word[word.Length/2]);
            }

            return sb.ToString().Trim();
        }
    }
}
