using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sum = 0;

            while (numbers.Any())
            {
                int index = int.Parse(Console.ReadLine());
                int currentElement = 0;

                if (index < 0)
                {
                    currentElement = numbers.First();
                    numbers.RemoveAt(0);
                    numbers.Insert(0, numbers.Last());
                }
                else if (index >= numbers.Count)
                {
                    currentElement = numbers.Last();
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Add(numbers.First());
                }
                else
                {
                    currentElement = numbers[index];
                    numbers.RemoveAt(index);
                }

                numbers = numbers.Select(x => (x <= currentElement ? x += currentElement : x -= currentElement)).ToList();

                sum += currentElement;
            }

            Console.WriteLine(sum);
        }
    }
}
