using System;

namespace _05.CharacterSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            foreach (var c in word)
            {
                Console.WriteLine(c);
            }
        }
    }
}
