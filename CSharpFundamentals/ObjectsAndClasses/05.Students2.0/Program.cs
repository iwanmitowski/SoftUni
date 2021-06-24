using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05.Students
{
    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] arguments = input.Split();

                var searched = students.FirstOrDefault(x => x.FirstName == arguments[0] && x.LastName == arguments[1]);

                if (searched == null)
                {
                    students.Add(new Student(
                      arguments[0],
                      arguments[1],
                      int.Parse(arguments[2]),
                      arguments[3]));
                }
                else
                {
                    searched.Age = int.Parse(arguments[2]);
                    searched.HomeTown = arguments[3];
                }

                input = Console.ReadLine();
            }

            string town = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine, students.Where(s => s.HomeTown == town)));
        }
    }
}

