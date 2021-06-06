using System;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (word!="END")
            {

                Console.WriteLine(IsItPalindrome(word));

                word = Console.ReadLine();
            }
        }

        private static string IsItPalindrome(string word)
        {
            bool isPalindrome = true;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i]!=word[word.Length-1-i])
                {
                    isPalindrome = false;
                }
            }

            return isPalindrome.ToString().ToLower();
        }
    }
}
