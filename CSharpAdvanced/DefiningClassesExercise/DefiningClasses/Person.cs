using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public Person()
        {
        }

        public Person(int age)
        {
            Age = age;
        }

        public Person(int age, string name)
            : this(age)
        {
            Name = name;
        }
        public string Name { get; set; } = "No name";
        public int Age { get; set; } = 1;

        public override string ToString()
        {
            return $"{this.Name} - {this.Age}";
        }
    }
}
