using System;

namespace _05.MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            string highest = string.Empty;
            double maxRating = double.MinValue;

            string lowest = string.Empty;
            double minRating = double.MaxValue;

            double totalRating = 0;
           
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());

                if (rating>maxRating)
                {
                    maxRating = rating;
                    highest = name;
                }
                if (rating<minRating)
                {
                    minRating = rating;
                    lowest = name;
                }

                totalRating += rating;
            }

            double averageRating = totalRating / n;

            Console.WriteLine($"{highest} is with highest rating: {maxRating:f1}");
            Console.WriteLine($"{lowest} is with lowest rating: {minRating:f1}");
            Console.WriteLine($"Average rating: {averageRating:f1}");
        }
    }
}
