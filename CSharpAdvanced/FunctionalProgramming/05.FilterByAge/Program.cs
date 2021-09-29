using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace _05.FilterByAge
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = num => int.Parse(num);
            Func<string, string[]> splitter = input => input.Split(", ");

            int n = parser(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var currentPerson = splitter(Console.ReadLine());

                string name = currentPerson[0];
                int age = parser(currentPerson[1]);

                people.Add(new Person(name, age));
            }

            string condition = Console.ReadLine();
            int ageToCompare = parser(Console.ReadLine());
            string format = Console.ReadLine();

            Predicate<Person> filter = CreateFilter(condition, ageToCompare);
            Action<Person> printer = CreatePrinter(format);

            people.Where(p => filter(p)).ToList().ForEach(printer);

        }

        private static Action<Person> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                return x=> Console.WriteLine($"{x.Name}");
                case "age":
                    return x => Console.WriteLine($"{x.Age}");
                case "name age":
                    return x => Console.WriteLine($"{x.Name} - {x.Age}");
                default:
                    return null;
            }
        }

        private static Predicate<Person> CreateFilter(string condition, int ageToCompare)
        {
            switch (condition)
            {
                case "younger":
                    return x => x.Age < ageToCompare;
                case "older":
                    return x => x.Age >= ageToCompare;
                default:
                    return null;
            }
        }
    }
}
