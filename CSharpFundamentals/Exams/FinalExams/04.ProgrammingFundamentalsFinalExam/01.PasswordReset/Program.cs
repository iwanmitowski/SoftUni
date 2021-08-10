using System;
using System.Linq;
using System.Text;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder().Append(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] tokens = input.Split();

                string command = tokens[0];

                switch (command)
                {
                    case "TakeOdd":

                        var temp = string.Concat(sb.ToString().Where((c, i) => i % 2 == 1));
                        sb.Clear();
                        sb.Append(temp);
                        break;

                    case "Cut":
                        int index = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);

                        sb.Remove(index,length);
                        break;

                    case "Substitute":
                        string substring = tokens[1];
                        string substitute = tokens[2];
                        if (!sb.ToString().Contains(substring))
                        {
                            Console.WriteLine("Nothing to replace!");
                            input = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            sb.Replace(substring, substitute);
                        }
                        break;

                    default:
                        break;
                }

                Console.WriteLine(sb.ToString().Trim());
                input = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {sb.ToString()}");
        }
    }
}
