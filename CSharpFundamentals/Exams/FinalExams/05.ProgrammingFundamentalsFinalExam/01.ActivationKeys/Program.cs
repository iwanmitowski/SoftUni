using System;
using System.Text;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder().Append(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Generate")
            {
                string[] tokens = input.Split(">>>");

                string command = tokens[0];

                switch (command)
                {
                    case "Contains":
                        string substring = tokens[1];
                        if (sb.ToString().Contains(substring))
                        {
                            Console.WriteLine($"{sb.ToString().Trim()} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string criteria = tokens[1];
                        int start = int.Parse(tokens[2]);
                        int end = int.Parse(tokens[3]);
                        if (criteria == "Upper")
                        {
                            for (int i = start; i < end; i++)
                            {
                                sb[i] = char.ToUpper(sb[i]);
                            }

                        }
                        else
                        {
                            for (int i = start; i < end; i++)
                            {
                                sb[i] = char.ToLower(sb[i]);
                            }
                        }
                        Console.WriteLine(sb.ToString().Trim());
                        break;
                    default:
                        start = int.Parse(tokens[1]);
                        end = int.Parse(tokens[2]);
                        sb.Remove(start, end - start);
                        Console.WriteLine(sb.ToString().Trim());
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {sb.ToString()}");
        }
    }
}
