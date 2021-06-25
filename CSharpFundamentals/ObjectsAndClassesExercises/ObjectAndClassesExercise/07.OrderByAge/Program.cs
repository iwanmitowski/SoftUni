using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Person
    {
        public Person(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();

                people.Add(new Person(tokens[0], tokens[1], int.Parse(tokens[2])));

                input = Console.ReadLine();
            }

            foreach (var person in people.OrderBy(p=>p.Age))
            {
                Console.WriteLine(person);
            }
        }
    }
}
