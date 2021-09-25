using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathOne = Path.Combine("..", "..", "..", "FileOne.txt");
            using var fileOne = new StreamReader(pathOne);
            string pathTwo = Path.Combine("..", "..", "..", "FileTwo.txt");
            using var fileTwo = new StreamReader(pathTwo);

            var fileOneWords = new List<string>();
            var fileTwoWords = new List<string>();

            while (!fileOne.EndOfStream)
            {
                fileOneWords.Add(fileOne.ReadLine());
            }
            while (!fileTwo.EndOfStream)
            {
                fileTwoWords.Add(fileTwo.ReadLine());
            }

            string dest = Path.Combine("..", "..", "..", "Output.txt");
            using var sw = new StreamWriter(dest);

            for (int i = 0; i < fileOneWords.Count; i++)
            {
                sw.WriteLine(fileOneWords[i]);
                sw.WriteLine(fileTwoWords[i]);
            }
        }
    }
}
