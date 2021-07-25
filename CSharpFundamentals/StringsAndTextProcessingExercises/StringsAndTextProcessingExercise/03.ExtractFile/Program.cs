using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine().Split(new string[] { "\\", "." }, StringSplitOptions.RemoveEmptyEntries);
            string fileName = path[path.Length - 2];
            string fileExtension = path[path.Length - 1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");

        }
    }
}
