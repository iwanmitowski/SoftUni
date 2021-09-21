using System;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class Product {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return $"Product: {this.Name}, Price: {this.Price}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var shops = new SortedDictionary<string, List<Product>>();

            while (input!="Revision")
            {
                string[] tokens = input.Split(", ");

                string shop = tokens[0];
                string name = tokens[1];
                double price = double.Parse(tokens[2]);

                var product = new Product(name, price);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new List<Product>());
                }

                shops[shop].Add(product);

                input = Console.ReadLine();
            }

            foreach ((string shop, List<Product> products) in shops)
            {
                Console.WriteLine($"{shop}->");
                Console.WriteLine(string.Join(Environment.NewLine,products));
            }
        }
    }
}
