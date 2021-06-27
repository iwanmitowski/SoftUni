using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace _05.ShoppingSpree
{
    class Product
    {
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
    class Person
    {
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        public string Name { get; set; }
        public decimal Money { get; set; }

        public List<Product> Products { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleTokens = Console.ReadLine().Split(new char[] { '=', ';' });
            string[] productTokens = Console.ReadLine().Split(new char[] { '=', ';' });

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();


            for (int i = 0; i < peopleTokens.Length-1; i+=2)
            {
                people.Add(new Person(peopleTokens[i], decimal.Parse(peopleTokens[i + 1])));
            }

            for (int i = 0; i < productTokens.Length-1; i += 2)
            {
                products.Add(new Product(productTokens[i], decimal.Parse(productTokens[i + 1])));
            }

            string input = Console.ReadLine();

            while (input!="END")
            {
                string[] tokens = input.Split();

                string personName = tokens[0];
                string productName = tokens[1];

                var person = people.First(x => x.Name == personName);
                var product = products.First(x => x.Name == productName);

                if (person.Money>=product.Cost)
                {
                    Console.WriteLine($"{personName} bought {productName}");
                    person.Products.Add(product);
                    person.Money -= product.Cost;
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }

                input = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (!person.Products.Any())
                {
                    Console.WriteLine($"{person} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person} - {string.Join(", ",person.Products)}");
                }
            }
        }
    }
}
