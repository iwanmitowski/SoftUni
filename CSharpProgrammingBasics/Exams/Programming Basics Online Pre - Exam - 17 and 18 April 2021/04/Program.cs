using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            double liters = 0;
            double degrees = 0;

            for (int i = 0; i < days; i++)
            {
                double currentLiters = double.Parse(Console.ReadLine());
                double currentDegrees = double.Parse(Console.ReadLine());
                liters += currentLiters;
                degrees += currentDegrees * currentLiters;
            }

            degrees /= liters;

            Console.WriteLine($"Liter: {liters:f2}");
            Console.WriteLine($"Degrees: {degrees:f2}");
            if (degrees < 38)
            {
                Console.WriteLine("Not good, you should baking!");
            }
            else if (degrees >= 38 && degrees <= 42)
            {
                Console.WriteLine("Super!");
            }
            else
            {
                Console.WriteLine("Dilution with distilled water!");
            }
        }
    }
}
