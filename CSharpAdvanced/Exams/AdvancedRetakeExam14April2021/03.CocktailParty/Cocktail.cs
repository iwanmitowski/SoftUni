using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private readonly List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            this.ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => this.ingredients.Sum(x => x.Alcohol);
        public void Add(Ingredient ingredient)
        {
            if (ingredients.Any(x => x.Name == ingredient.Name ||
                this.ingredients.Count == Capacity ||
                ingredient.Alcohol + CurrentAlcoholLevel > MaxAlcoholLevel))
            {
                throw new InvalidOperationException();
            }

            ingredients.Add(ingredient);
        }

        public bool Remove(string name)
        {
            var ingredient = FindIngredient(name);

            if (ingredient == null)
            {
                return false;
            }

            this.ingredients.Remove(ingredient);

            return true;
        }

        public Ingredient FindIngredient(string name)
        {
            return this.ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return this.ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.ToString());

            foreach (var ingredient in ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return $"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}";
        }
    }
}
