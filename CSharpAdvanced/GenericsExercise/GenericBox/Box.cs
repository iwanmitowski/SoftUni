using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBox
{
    public class Box<T>
    {
        private readonly List<T> box;

        public Box()
        {
            this.box = new List<T>();
        }

        public void Add(T element)
        {
            this.box.Add(element);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            box.ForEach(x => sb.AppendLine($"{typeof(T).FullName}: {x}"));

            return sb.ToString().Trim();
        }
    }
}
