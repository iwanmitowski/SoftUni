using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("..", "..", "..", "Input.txt");
            using var sr = new StreamReader(path);

            int counter = 0;

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                if (counter % 2 == 1)
                {
                    Console.WriteLine(line);
                }

                counter++;
            }


        }
    }
}
