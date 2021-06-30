using System;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input.Split();

                if (tokens[0] == "decrease")
                {
                    numbers = numbers.Select(x => x - 1).ToArray();
                }
                else
                {
                    int first = int.Parse(tokens[1]);
                    int second = int.Parse(tokens[2]);
                    switch (tokens[0])
                    {
                        case "swap":
                            numbers[first] += numbers[second];
                            numbers[second] = numbers[first] - numbers[second];
                            numbers[first] -= numbers[second];
                            break;
                        case "multiply":
                            numbers[first] *= numbers[second];
                            break;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
