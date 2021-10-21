using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            var foods = new Dictionary<int, string>();
            foods[25] = "Bread";
            foods[50] = "Cake";
            foods[75] = "Pastry";
            foods[100] = "Fruit Pie";

            var cooked = new SortedDictionary<string, int>();
            cooked["Bread"] = 0;
            cooked["Cake"] = 0;
            cooked["Pastry"] = 0;
            cooked["Fruit Pie"] = 0;

            var liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            while (liquids.Any() && ingredients.Any())
            {
               
                if (foods.ContainsKey(liquids.Peek() + ingredients.Peek()))
                {
                    cooked[foods[liquids.Peek() + ingredients.Pop()]]++;
                }
                else
                {
                    ingredients.Push(ingredients.Pop() + 3);
                }

                liquids.Dequeue();
            }

            if (cooked.Values.All(x => x > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach ((string food, int amount) in cooked)
            {
                Console.WriteLine($"{food}: {amount}");
            }
        }
    }
}
