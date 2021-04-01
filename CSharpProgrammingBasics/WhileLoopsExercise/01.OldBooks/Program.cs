using System;

namespace _01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookToLookFor = Console.ReadLine();

            string currentBook = Console.ReadLine();
            int checkedBooks = 0;
            bool isFound = false;

            while (currentBook!="No More Books")
            {
                if (currentBook==bookToLookFor)
                {
                    isFound = true;
                    break;
                }

                checkedBooks++;

                currentBook = Console.ReadLine();
            }

            if (isFound)
            {
                Console.WriteLine($"You checked {checkedBooks} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {checkedBooks} books.");
            }

        }
    }
}
