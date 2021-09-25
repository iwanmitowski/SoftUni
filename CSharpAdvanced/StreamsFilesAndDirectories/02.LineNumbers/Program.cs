using System;
using System.IO;
using System.Text;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = Path.Combine("..", "..", "..", "Input.txt");
            using var sr = new StreamReader(path);
            
            int counter = 1;

            string dest = Path.Combine("..", "..", "..", "Output.txt");
            using var sw = new StreamWriter(dest);

            while (!sr.EndOfStream)
            {
                var line = $"{counter++}. {sr.ReadLine()}";

                sw.WriteLine(line);
            }
        }
    }
}
