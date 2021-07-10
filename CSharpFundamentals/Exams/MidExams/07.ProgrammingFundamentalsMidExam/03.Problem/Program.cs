using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _03.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chat = new List<string>();

            string input = Console.ReadLine();

            while (input!="end")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                string message = tokens[1];

                switch (command)
                {
                    case "Chat":
                        chat.Add(message);
                    break;
                    case "Delete":
                        if (chat.Contains(message))
                        {
                            chat.Remove(message);
                        }
                        break;
                    case "Edit":
                        if (chat.Contains(message))
                        {
                            int index = chat.IndexOf(message);
                            chat[index] = tokens[2];
                        }
                        break;
                    case "Pin":
                        if (chat.Contains(message))
                        {
                            int index = chat.IndexOf(message);
                            chat.RemoveAt(index);
                            chat.Add(message);
                        }
                        break;
                    case "Spam":
                        chat.AddRange(tokens.Skip(1));
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, chat));
        }
    }
}
