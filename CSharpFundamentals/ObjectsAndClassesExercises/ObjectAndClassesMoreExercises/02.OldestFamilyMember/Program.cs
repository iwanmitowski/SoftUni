using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamilyMember
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

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    class Family
    {
        private List<Person> members { get; set; }

        public Family()
        {
            members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public void GetOldest()
        {
            Console.WriteLine(this.members.OrderByDescending(x=>x.Age).First());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                family.AddMember(new Person(tokens[0], int.Parse(tokens[1])));
            }

            family.GetOldest();
        }
    }
}
