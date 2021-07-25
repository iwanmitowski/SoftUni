using System;
using System.Linq;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letters = Console.ReadLine().ToCharArray();

            letters = letters.Select(l => (char)(l + 3)).ToArray();

            Console.WriteLine(string.Join("",letters));
        }
    }
}
