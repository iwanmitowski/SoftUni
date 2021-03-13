using System;

namespace _08.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double salary = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialScholarship = Math.Floor(minSalary * 0.35);
            double excellentScholarship = Math.Floor(grade * 25);

            bool socialPossibility = false;
            bool excellentPossibility = false;

            if (salary <= minSalary && grade > 4.50)
            {
                socialPossibility = true;
            }
            if (grade >= 5.50)
            {
                excellentPossibility = true;
            }

            if (socialPossibility && excellentPossibility)
            {
                if (socialScholarship > excellentScholarship)
                {
                    Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
                }
                else if (socialScholarship < excellentScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");
                }
            }
            else if (!socialPossibility && !excellentPossibility)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (socialPossibility)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");

            }
            else if (excellentPossibility)
            {
                Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");

            }
            
        }
    }
}
