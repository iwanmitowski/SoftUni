using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, List<double>>();


            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(name))
                {
                    dictionary.Add(name, new List<double>());
                }

                dictionary[name].Add(grade);
            }

            foreach ((string name, List<double> grades) in dictionary.Where(x=>x.Value.Average()>=4.5).OrderByDescending(x=>x.Value.Average()))
            {
                Console.WriteLine($"{name} -> {grades.Average():f2}");

            }
        }
    }
}
