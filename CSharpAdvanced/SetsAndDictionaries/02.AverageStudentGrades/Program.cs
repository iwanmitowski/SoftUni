using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                }

                students[name].Add(grade);
            }

            foreach ((string name, List<decimal> grades) in students)
            {
                Console.WriteLine($"{name} -> {string.Join(" ", grades.Select(x => x.ToString("f2")))} (avg: {grades.Average():f2})");
            }
        }
    }
}
