using System;
using System.Text;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder bobTheBuilder = new StringBuilder();

            string[] words = Console.ReadLine().Split();

            foreach (var word in words)
            {
                int count = word.Length;

                for (int i = 0; i < count; i++)
                {
                    bobTheBuilder.Append(word);
                }
            }

            Console.WriteLine(bobTheBuilder.ToString());
        }
    }
}
