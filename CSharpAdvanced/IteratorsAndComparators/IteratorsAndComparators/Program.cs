using System;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);
            Book bookFour = new Book("The Documents in the Case", 1930);
            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            Console.WriteLine(bookOne.CompareTo(bookTwo));
            Console.WriteLine(bookTwo.CompareTo(bookTwo));
            Console.WriteLine(bookThree.CompareTo(bookFour));
            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
