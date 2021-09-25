using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathWords = Path.Combine("..", "..", "..", "words.txt");
            using var wordsReader = new StreamReader(pathWords);

            var words = new List<string>();
            words.AddRange(wordsReader.ReadLine().Split());

            string pathText = Path.Combine("..", "..", "..", "text.txt");
            using var textReader = new StreamReader(pathText);

            var text = new List<string>();

            while (!textReader.EndOfStream)
            {
                var wordsInput = textReader.ReadLine().ToLower().Split(new string[] {" ",",",".","!","?","-" },StringSplitOptions.RemoveEmptyEntries);
                text.AddRange(wordsInput);
            }

            var wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                wordsCount.Add(word, 0);
            }

            foreach (var word in text)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
            }

            string dest = Path.Combine("..", "..", "..", "Output.txt");
            using var textWriter = new StreamWriter(dest);

            foreach ((string word, int count) in wordsCount.OrderByDescending(x=>x.Value))
            {
                textWriter.WriteLine($"{word} - {count}");
            }
        }
    }
}
