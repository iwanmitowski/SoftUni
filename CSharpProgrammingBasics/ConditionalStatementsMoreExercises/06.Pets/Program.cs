using System;

namespace _06.Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int leftedFood = int.Parse(Console.ReadLine());
            double dogFood = double.Parse(Console.ReadLine());
            double catFood = double.Parse(Console.ReadLine());
            double turtleFood = double.Parse(Console.ReadLine());

            double totalFoodNeeded = (dogFood * days) + (catFood * days) + (turtleFood * days)/1000;

            if (totalFoodNeeded <= leftedFood)
            {
                Console.WriteLine($"{Math.Floor( leftedFood- totalFoodNeeded)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(totalFoodNeeded- leftedFood )} more kilos of food are needed.");

            }


        }

        

    }
}
