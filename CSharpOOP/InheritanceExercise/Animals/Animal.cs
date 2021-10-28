using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get => name;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException("Invalid input!");
                }

                this.name = value;
            }
        }
        public int Age
        {
            get => age;

            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Invalid input!");
                }

                this.age = value;
            }
        }
        public string Gender
        {
            get => gender;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException("Invalid input!");
                }

                this.gender = value;
            }
        }
        public abstract string ProduceSound();

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(ProduceSound());

            return sb.ToString().Trim();
        }
    }
}
