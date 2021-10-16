using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            var guestsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var platesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var guests = new Queue<int>(guestsInput);
            var plates = new Stack<int>(platesInput);

            int wasted = 0;

            while (guests.Any() && plates.Any())
            {
                var currentGuest = guests.Dequeue();

                while (currentGuest > 0)
                {
                    currentGuest -= plates.Pop();

                    if (!plates.Any())
                    {
                        break;
                    }
                }

                wasted += Math.Abs(currentGuest);
            }

            if (plates.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ",plates)}");
            }
            else if (guests.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wasted}");
        }
    }
}
