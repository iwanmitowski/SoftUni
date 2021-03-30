using System;

namespace _04.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            decimal biggerThan5 = 0;
            decimal biggerThan4 = 0;
            decimal biggerThan3 = 0;
            decimal failed = 0;

            decimal average = 0;

            for (int i = 0; i < students; i++)
            {
                decimal grade = decimal.Parse(Console.ReadLine());

                average += grade;

                if (grade >= 5)
                {
                    biggerThan5++;
                }
                else if (grade >= 4 && grade <= 4.99M)
                {
                    biggerThan4++;
                }
                else if (grade >= 3 && grade <= 3.99M)
                {
                    biggerThan3++;
                }
                else
                {
                    failed++;
                }

            }

            biggerThan5 = biggerThan5 / students * 100;
            biggerThan4 = biggerThan4 / students * 100;
            biggerThan3 = biggerThan3 / students * 100;
            failed = failed/students*100;
            average /= students;    

            Console.WriteLine($"Top students: {biggerThan5:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {biggerThan4:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {biggerThan3:f2}%");
            Console.WriteLine($"Fail: {failed:f2}%");
            Console.WriteLine($"Average: {average:f2}");
        }
    }
}
