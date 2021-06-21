using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal savings = decimal.Parse(Console.ReadLine());

            List<int> drumSetsQualities = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> drumSets = drumSetsQualities.ToList();

            string input = Console.ReadLine();

            while (input != "Hit it again, Gabsy!")
            {
                int hit = int.Parse(input);

                for (int i = 0; i < drumSets.Count; i++)
                {
                    drumSets[i] -= hit;

                    if (drumSets[i] <= 0 && savings >= drumSetsQualities[i]*3)
                    {
                        drumSets[i] = drumSetsQualities[i];
                        savings -= drumSetsQualities[i]*3;
                    }

                    if (drumSets[i]<=0)
                    {
                        drumSets.RemoveAt(i);
                        drumSetsQualities.RemoveAt(i);
                        i--;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",drumSets));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
