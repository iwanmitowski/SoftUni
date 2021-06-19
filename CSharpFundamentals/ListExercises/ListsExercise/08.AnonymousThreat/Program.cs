using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string[] arguments = input.Split();

                string command = arguments[0];

                int startIndex = int.Parse(arguments[1]);
                int endIndex = int.Parse(arguments[2]);

                if (startIndex < 0)
                {
                    startIndex = 0;
                }
                else if (startIndex >= words.Count)
                {
                    startIndex = words.Count - 2;
                }

                switch (command)
                {
                    case "merge":

                        if (endIndex >= words.Count)
                        {
                            endIndex = words.Count - 1;
                        }
                        else if (endIndex < 0)
                        {
                            endIndex = 2;
                        }

                        StringBuilder sb = new StringBuilder();

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sb.Append(words[i]);
                        }

                        words.Insert(endIndex + 1, sb.ToString());
                        words.RemoveRange(startIndex, endIndex - startIndex + 1);
                        break;

                    case "divide":
                        int index = startIndex;

                        int partition = endIndex;


                        string currentWord = words[index];
                        int parts = currentWord.Length / partition;

                        words.RemoveAt(index);

                        List<string> result = new List<string>();

                        for (int i = 0; i < partition-1; i++)
                        {
                            string currentWordPart = currentWord.Substring(parts * i, parts);
                            result.Add(currentWordPart);
                        }

                        string lastPart = currentWord.Substring(parts * (partition - 1));
                        result.Add(lastPart);

                        words.InsertRange(index, result);

                        break;
                }

                input = Console.ReadLine();
            }
 
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
