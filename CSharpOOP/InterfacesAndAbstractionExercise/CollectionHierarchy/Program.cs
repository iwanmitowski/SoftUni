using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split();

            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            PrintCollectionAddResult(addCollection, elements);
            PrintCollectionAddResult(addRemoveCollection, elements);
            PrintCollectionAddResult(myList, elements);

            int removeIteration = int.Parse(Console.ReadLine());

            PrintCollectionRemoveResult(addRemoveCollection, removeIteration);
            PrintCollectionRemoveResult(myList, removeIteration);
        }

        private static void PrintCollectionRemoveResult(IRemovable collection, int removeIteration)
        {
            var removeResult = new List<string>();

            for (int i = 0; i < removeIteration; i++)
            {
                removeResult.Add(collection.Remove());
            }

            Console.WriteLine(string.Join(" ", removeResult));
        }

        private static void PrintCollectionAddResult(IAddable collection, string[] elements)
        {
            var indexes = new List<int>();

            for (int i = 0; i < elements.Length; i++)
            {
                indexes.Add(collection.Add(elements[i]));
            }

            Console.WriteLine(string.Join(" ", indexes));
        }
    }
}
