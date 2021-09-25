using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = @"..\..\..\TestFolder";
            var files = Directory.GetFiles(directory);
            double length = 0;

            foreach (var file in files)
            {
                length += new FileInfo(file).Length;
            }

            length = length / 1024 / 1024;

            Console.WriteLine(length);
        }
    }
}
