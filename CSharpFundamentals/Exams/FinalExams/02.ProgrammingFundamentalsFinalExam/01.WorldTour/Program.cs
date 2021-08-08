using System;
using System.Text;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder().AppendLine(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] tokens = input.Split(":");

                string command = tokens[0];

                switch (command)
                {
                    case "Add Stop":
                        int index = int.Parse(tokens[1]);
                        if (index > 0 && index <= sb.Length)
                        {
                            sb.Insert(index, tokens[2]);
                        }
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);
                        if (startIndex > 0 && startIndex <= sb.Length && endIndex > 0 && endIndex <= sb.Length)
                        {
                            sb.Remove(startIndex, endIndex - startIndex+1);
                        }
                        break;
                    case "Switch":
                        while (sb.ToString().Contains(tokens[1]))
                        {
                            sb.Replace(tokens[1], tokens[2]);
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine(sb.ToString().Trim());
                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {sb.ToString()}");
        }
    }
}
