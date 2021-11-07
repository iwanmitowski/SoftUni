using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddable, IRemovable
    {
        private readonly List<string> collection;
        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            this.collection.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            var element = collection.Last();

            collection.Remove(element);

            return element;
        }
    }
}
