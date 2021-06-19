using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> second = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (first.Count>0 && second.Count>0)
            {
                int firstPlayerCard = first[0];
                int secondPlayerCard = second[0];

                if (firstPlayerCard>secondPlayerCard)
                {
                    first.Add(firstPlayerCard);
                    first.Add(secondPlayerCard);
                }
                else if(firstPlayerCard < secondPlayerCard)
                {
                    second.Add(secondPlayerCard);
                    second.Add(firstPlayerCard);
                }

                first.RemoveAt(0);
                second.RemoveAt(0);
            }

            if (first.Any())
            {
                Console.WriteLine($"First player wins! Sum: {first.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {second.Sum()}");
            }
        }
    }
}
