using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IAddable, IRemovable
    {
        private readonly List<string> collection;
        public MyList()
        {
            this.collection = new List<string>();
        }

        public int Used => collection.Count;

        public int Add(string item)
        {
            collection.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            var element = collection.First();

            collection.Remove(element);

            return element;
        }
    }
}
