using System;
using System.Linq;
using System.Text;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder().Append(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] tokens = input.Split(":|:");

                string command = tokens[0];

                switch (command)
                {
                    case "InsertSpace":
                        sb.Insert(int.Parse(tokens[1]), ' ');
                        break;
                    case "Reverse":
                        string substring = tokens[1];
                        if (sb.ToString().Contains(substring))
                        {
                            int startIndex = sb.ToString().IndexOf(substring);
                            sb.Remove(startIndex, substring.Length);
                            sb.Append(string.Join("", substring.Reverse()));

                        }
                        else
                        {
                            Console.WriteLine("error");
                            input = Console.ReadLine();
                            continue;
                        }

                        break;
                    case "ChangeAll":
                        string oldSubstring = tokens[1];
                        string replacement = tokens[2];
                        while (sb.ToString().Contains(oldSubstring))
                        {
                            sb.Replace(oldSubstring, replacement);
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine(sb.ToString().Trim());
                input = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {sb.ToString()}");
        }
    }
}
