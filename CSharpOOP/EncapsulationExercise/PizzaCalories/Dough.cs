using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int BaseCalouriesValue = 2;
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private readonly IReadOnlyDictionary<string, double> bakingTechniquesValues;
        private readonly IReadOnlyDictionary<string, double> flourTypesValues;
        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            bakingTechniquesValues = FillBakingTechniqueDictionary();
            flourTypesValues = FillFlourTypesDictionary();
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string FlourType
        {
            get => flourType;

            private set
            {
                if (!flourTypesValues.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;

            private set
            {
                if (!bakingTechniquesValues.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }
        public double Grams
        {
            get => grams; 
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                grams = value;
            }
        }
        public int BaseCalories => BaseCalouriesValue;
        public double FlourTypeCalories => GetFlourTypeCaloriesValue();
        public double BakingTechniqueCalories => GetBakingTechniqueCaloriesValue();
        public double TotalCalories => (BaseCalories * Grams) * FlourTypeCalories * BakingTechniqueCalories;

        private IReadOnlyDictionary<string, double> FillBakingTechniqueDictionary()
        {
            var dictionary = new Dictionary<string, double>
            {
                ["white"] = 1.5,
                ["wholegrain"] = 1.0,
                ["crispy"] = 0.9,
                ["chewy"] = 1.1,
                ["homemade"] = 1.0
            };

            return dictionary;
        }

        private IReadOnlyDictionary<string, double> FillFlourTypesDictionary()
        {
            var dictionary = new Dictionary<string, double>
            {
                ["white"] = 1.5,
                ["wholegrain"] = 1.0
            };

            return dictionary;
        }
        private double GetBakingTechniqueCaloriesValue()
        {
            return bakingTechniquesValues[this.BakingTechnique.ToLower()];
        }

        private double GetFlourTypeCaloriesValue()
        {
            return flourTypesValues[this.FlourType.ToLower()];
        }
    }
}
