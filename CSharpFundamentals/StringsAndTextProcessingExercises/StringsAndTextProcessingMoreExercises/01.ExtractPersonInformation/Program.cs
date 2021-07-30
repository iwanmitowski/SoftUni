using System;
using System.Linq;

namespace _01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                int nameIndex = text.IndexOf('@');
                int ageIndex = text.IndexOf('#');

                string name = string.Join("", text.Skip(nameIndex+1).TakeWhile(x => x != '|'));
                string age = string.Join("", text.Skip(ageIndex + 1).TakeWhile(x => x != '*'));
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
