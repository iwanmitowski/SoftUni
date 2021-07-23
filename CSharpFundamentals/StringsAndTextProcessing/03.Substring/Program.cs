using System;
using System.Text;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine().ToLower();

            string text = Console.ReadLine();
            
            while (text.Contains(wordToRemove))
            {
                text = text.Remove(text.IndexOf(wordToRemove), wordToRemove.Length);
            }

            Console.WriteLine(text);
        }
    }
}
