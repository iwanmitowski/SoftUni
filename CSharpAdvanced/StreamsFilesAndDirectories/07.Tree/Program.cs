using System;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace _07.Tree
{
    class Program
    {
        static int padding = 4;
        static int counter = 1;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var directory = @"D:\";

            GetAllFileNames(directory);
        }

        private static void GetAllFileNames(string directory)
        {
            var files = Directory.GetFiles(directory);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{'├'}{new string('─', counter * padding)}{'┐'}{Path.GetDirectoryName(directory)}");
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < files.Length; i++)
            {
                if (i==files.Length-1)
                {
                    Console.WriteLine($"{new string(' ', counter * padding + 1)}{'└'}{new string('─', counter * padding) + Path.GetFileName(files[i])}");
                }
                else
                {
                    Console.WriteLine($"{new string(' ', counter * padding + 1)}{'├'}{new string('─', counter * padding) + Path.GetFileName(files[i])}");
                }

            }

            foreach (var subDirectory in Directory.GetDirectories(directory))
            {
                counter++;
                GetAllFileNames(subDirectory);
                counter--;
            }
        }
    }
}
