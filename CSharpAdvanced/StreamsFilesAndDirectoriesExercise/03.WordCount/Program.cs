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
            string path = Path.Combine("..", "..", "..", "text.txt");
            var lines = File.ReadAllLines(path);

            var text = new List<string>();

            foreach (var line in lines)
            {
                var currentWords = line.ToLower().Split(new string[] { " ", ",", ".", "!", "?", "-" }, StringSplitOptions.RemoveEmptyEntries);

                text.AddRange(currentWords);
            }

            var wordsCount = new Dictionary<string, int>();


            var words = new List<string>();
            var wordsPath = Path.Combine("..", "..", "..", "words.txt");
            words.AddRange(File.ReadAllLines(wordsPath));

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

            var sb = new StringBuilder();

            foreach ((string word, int count) in wordsCount.OrderByDescending(x => x.Value))
            {
                sb.AppendLine($"{word} - {count}");
            }

            string dest = Path.Combine("..", "..", "..", "Output.txt");
            File.WriteAllText(dest, sb.ToString().Trim());
        }
    }
}
