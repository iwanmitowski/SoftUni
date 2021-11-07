using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAddable
    {
        private readonly List<string> collection;
        public AddCollection()
        {
            this.collection = new List<string>();
        }
        public int Add(string item)
        {
            collection.Add(item);

            return this.collection.Count - 1;
        }
    }
}
