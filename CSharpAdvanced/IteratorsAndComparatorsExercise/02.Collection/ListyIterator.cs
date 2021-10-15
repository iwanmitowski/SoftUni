using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> products;
        private int index;
        public ListyIterator(List<T> products)
        {
            this.products = products.ToList();
            index = 0;
        }
        public bool Move()
        {


            if (HasNext())
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return index < products.Count - 1;
        }

        public void Print()
        {
            if (products.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(products[index]);
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", products));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < products.Count; i++)
            {
                yield return products[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
