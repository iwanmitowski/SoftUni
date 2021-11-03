using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get => money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public string AddProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.bagOfProducts.Add(product);
            this.Money -= product.Cost;

            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            if (this.bagOfProducts.Any())
            {
                return $"{this.Name} - {string.Join(", ", bagOfProducts)}";
            }

            return $"{this.Name} - Nothing bought";
        }
    }
}
