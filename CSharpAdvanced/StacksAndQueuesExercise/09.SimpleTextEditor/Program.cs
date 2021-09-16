using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder bobTheBuilder = new StringBuilder();

            Stack<string> textHistory = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                if (command == "1")
                {
                    textHistory.Push(bobTheBuilder.ToString());

                    bobTheBuilder.Append(input[1]);
                }
                else if (command == "2")
                {
                    textHistory.Push(bobTheBuilder.ToString());

                    int count = int.Parse(input[1]);

                    string currentText = bobTheBuilder.ToString();
                    int length = bobTheBuilder.Length - count > 0 ? bobTheBuilder.Length - count : 0;

                    bobTheBuilder.Clear().Append(currentText.Substring(0, length));
                }
                else if (command == "3" && bobTheBuilder.Length > 0)
                {

                    int index = int.Parse(input[1]) - 1;

                    Console.WriteLine(bobTheBuilder[index]);
                }
                else
                {
                    if (textHistory.Any())
                    {
                        bobTheBuilder.Clear().Append(textHistory.Pop());
                    }
                }

            }
        }
    }
}
