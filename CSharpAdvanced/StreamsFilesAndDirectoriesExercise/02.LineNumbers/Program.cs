using System;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("..", "..", "..", "text.txt");
            var lines = File.ReadAllLines(path);

            string dest = Path.Combine("..", "..", "..", "output.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                var length = lines[i].Count(x => char.IsLetter(x));
                var punctioation = lines[i].Count(x => char.IsPunctuation(x));
                lines[i] = $"Line {i + 1}: {lines[i]} ({length})({punctioation})";
            }

            File.WriteAllLines(dest, lines);

        }
    }
}
