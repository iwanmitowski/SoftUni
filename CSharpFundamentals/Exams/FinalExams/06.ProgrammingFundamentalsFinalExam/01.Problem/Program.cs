using System;
using System.Linq;
using System.Text;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder().Append(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Registration")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                string temp = string.Empty;

                switch (command)
                {
                    case "Letters":
                        if (tokens[1] == "Lower")
                        {
                            temp = sb.ToString().ToLower();
                            sb.Clear();
                            sb.Append(temp);
                        }
                        else
                        {
                            temp = sb.ToString().ToUpper();
                            sb.Clear();
                            sb.Append(temp);
                        }
                        break;

                    case "Reverse":
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);

                        if (startIndex >= 0 && startIndex < sb.Length &&
                            endIndex >= 0 && endIndex < sb.Length
                            )
                        {
                            var reversed = sb.ToString().Substring(startIndex, endIndex - startIndex + 1).Reverse();

                            Console.WriteLine(string.Join("",reversed));
                        }
                        break;
                    case "Substring":
                        string substring = tokens[1];
                        string name = sb.ToString();

                        if (name.Contains(substring))
                        {
                            startIndex = name.IndexOf(substring);
                            sb.Remove(startIndex, substring.Length);
                        }
                        else
                        {
                            Console.WriteLine($"The username {sb.ToString().Trim()} doesn't contain {substring}.");

                            input = Console.ReadLine();
                            continue;
                        }

                        break;
                    case "Replace":
                        char c = char.Parse(tokens[1]);
                        sb.Replace(c, '-');
                        break;

                    default:
                        c = char.Parse(tokens[1]);
                        if (sb.ToString().Contains(c))
                        {
                            Console.WriteLine("Valid username.");
                        }
                        else
                        {
                            Console.WriteLine($"{c} must be contained in your username.");
                        }
                        break;
                }
                if (command=="Reverse" || command=="IsValid")
                {
                    input = Console.ReadLine();
                    continue;
                }

                Console.WriteLine(sb.ToString().Trim());
                input = Console.ReadLine();
            }
        }
    }
}
