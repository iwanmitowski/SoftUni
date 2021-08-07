using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {

            StringBuilder word = new StringBuilder().Append(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Decode")
            {
                string[] tokens = input.Split("|");

                string command = tokens[0];

                switch (command)
                {
                    case "Move":
                        int numberOfLetters = int.Parse(tokens[1]);

                        for (int i = 0; i < numberOfLetters; i++)
                        {
                            word.Append(word[0]);
                            word.Remove(0,1);
                        }
                        break;

                    case "ChangeAll":
                        string substring = tokens[1];
                        string replacement = tokens[2];

                        while (word.ToString().Contains(substring))
                        {
                            word = word.Replace(substring, replacement);
                        }
                        break;

                    case "Insert":
                        int index = int.Parse(tokens[1]);
                        word.Insert(index, tokens[2]);
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {string.Join("", word)}");
        }
    }
}
