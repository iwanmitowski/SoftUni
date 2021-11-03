using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var products = new List<Product>();

            string[] peopleArgs = Console.ReadLine().Split(new char[] { '=', ';' });

            try
            {
                for (int i = 0; i < peopleArgs.Length - 1; i += 2)
                {
                    string name = peopleArgs[i];
                    decimal money = decimal.Parse(peopleArgs[i + 1]);
                    people.Add(new Person(name, money));
                }

                string[] productArgs = Console.ReadLine().Split(new char[] { '=', ';' });

                for (int i = 0; i < productArgs.Length - 1; i += 2)
                {
                    string name = productArgs[i];
                    decimal cost = decimal.Parse(productArgs[i + 1]);
                    products.Add(new Product(name, cost));
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(0);
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split();

                string personName = tokens[0];
                string productName = tokens[1];

                var person = people.FirstOrDefault(x => x.Name == personName);
                var product = products.FirstOrDefault(x => x.Name == productName);

                try
                {
                    Console.WriteLine(person.AddProduct(product));
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
