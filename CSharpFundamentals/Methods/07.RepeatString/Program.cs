using System;
using System.Text;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string result = Concat(word, count);

            Console.WriteLine(result);
        }

        private static string Concat(string word, int count)
        {
            StringBuilder sb = new StringBuilder();

            return sb.Insert(0, word, count).ToString();
        }
    }
}
