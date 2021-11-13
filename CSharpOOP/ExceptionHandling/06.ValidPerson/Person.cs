using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.ValidPerson
{
    public class Person
    {
        private const int MinAge = 0;
        private const int MaxAge = 120;

        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
        {
            get => firstName; 
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name can't be null or empty");
                }

                if (value.Any(x=>!char.IsLetter(x)))
                {
                    throw new InvalidPersonNameException("Name should contain only letters.");
                }

                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name can't be null or empty");
                }
                lastName = value;
            }
        }
        public int Age
        {
            get => age;
            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentOutOfRangeException($"Age should be in range [{MinAge} .. {MaxAge}]");
                }
                age = value;
            }
        }
    }
}
