using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine().Split();

            string pizzaName = pizzaInput[1];

            string[] doughInput = Console.ReadLine().Split();
            string doughFlour = doughInput[1];
            string doughBakingTechnique = doughInput[2];
            double doughGrams = double.Parse(doughInput[3]);

            try
            {
                var dough = new Dough(doughFlour, doughBakingTechnique, doughGrams);
                var pizza = new Pizza(pizzaName, dough);

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] tokens = input.Split();

                    string toppingType = tokens[1];
                    double toppingGrams = double.Parse(tokens[2]);

                    var topping = new Topping(toppingType, toppingGrams);
                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
