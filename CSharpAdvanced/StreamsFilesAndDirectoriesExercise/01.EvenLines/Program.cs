using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("..", "..", "..", "text.txt");
            var sr = new StreamReader(path);

            var words = new List<string>();

            int counter = 0;

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine()
                    .Replace("-", "@")
                    .Replace(",", "@")
                    .Replace(".", "@")
                    .Replace("!", "@")
                    .Replace("?", "@")
                    .Split(" ")
                    .Reverse();

                if (counter % 2 == 0)
                {
                    words.AddRange(line);
                }

                counter++;
            }

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
