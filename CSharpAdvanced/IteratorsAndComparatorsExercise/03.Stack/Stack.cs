using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private readonly List<T> elements;

        public Stack(List<T> elements)
        {
            this.elements = elements;
        }

        public void Push(T element)
        {
            elements.Add(element);
        }

        public T Pop()
        {
            var element = elements.LastOrDefault();

            if (element == null)
            {
                throw new InvalidOperationException("No elements");
            }

            elements.RemoveAt(elements.Count - 1);
            return element;

        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
