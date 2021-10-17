using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            var recepies = new Dictionary<int, string>();

            recepies[150] = "Dipping sauce";
            recepies[250] = "Green salad";
            recepies[300] = "Chocolate cake";
            recepies[400] = "Lobster";

            var cooked = new Dictionary<string, int>();
            cooked["Dipping sauce"] = 0;
            cooked["Green salad"] = 0;
            cooked["Chocolate cake"] = 0;
            cooked["Lobster"] = 0;

            var ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var freshness = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            while (ingredients.Any() && freshness.Any())
            {
                var currentIngredient = ingredients.Dequeue();

                if (currentIngredient == 0)
                {
                    continue;
                }

                var currentFreshness = freshness.Pop();

                int currentScore = currentIngredient * currentFreshness;

                if (recepies.ContainsKey(currentScore))
                {
                    var food = recepies[currentScore];
                    cooked[food]++;
                    continue;
                }

                currentIngredient += 5;

                ingredients.Enqueue(currentIngredient);
            }

            if (cooked.All(x => x.Value > 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach ((string food, int count) in cooked.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {food} --> {count}");
            }
        }
    }
}
