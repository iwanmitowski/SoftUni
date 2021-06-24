using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace _06.StoreBoxes
{
    class Item
    {
        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - ${this.Price:f2}";
        }
    }

    class Box
    {
        public Box(string serialNumber, Item item, int itemQuantity)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
        }

        public string SerialNumber { get; set; }
        public Item Item{ get; set; }

        public int ItemQuantity { get; set; }

        public decimal TotalPrice => Item.Price * ItemQuantity;

        public override string ToString()
        {
            StringBuilder bobTheBuilder = new StringBuilder();

            bobTheBuilder.AppendLine(this.SerialNumber);
            bobTheBuilder.AppendLine($"-- {this.Item}: {this.ItemQuantity}");
            bobTheBuilder.AppendLine($"-- ${this.TotalPrice:f2}");

            return bobTheBuilder.ToString().Trim();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var store = new List<Box>();

            while (input!="end")
            {
                string[] arguments = input.Split();

                Item item = new Item(arguments[1], decimal.Parse(arguments[3]));

                store.Add(new Box(arguments[0], item, int.Parse(arguments[2])));

                input = Console.ReadLine();
            }

            foreach (var box in store.OrderByDescending(b=>b.TotalPrice))
            {
                Console.WriteLine(box);
            }
        }
    }
}
