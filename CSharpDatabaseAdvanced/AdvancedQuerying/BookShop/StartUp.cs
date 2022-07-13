namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);
            Console.WriteLine(RemoveBooks(db));
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksForRemove = context.Books.Where(b => b.Copies < 4200).ToList();

            context.Books.RemoveRange(booksForRemove);
            context.SaveChanges();

            return booksForRemove.Count;
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                    .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010)
                    .ToList();

            books.ForEach(b => b.Price += 5);

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                    .Select(c => new
                    {
                        c.Name,
                        Books = c.CategoryBooks
                                    .Select(b => new
                                    {
                                        b.Book.Title,
                                        b.Book.ReleaseDate,
                                    })
                                    .OrderByDescending(b => b.ReleaseDate)
                                    .Take(3),
                    })
                    .OrderBy(c => c.Name)
                    .ToList();

            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                    .Select(a => new
                    {
                        a.FirstName,
                        a.LastName,
                        Copies = a.Books.Sum(b => b.Copies)
                    })
                    .OrderByDescending(b => b.Copies)
                    .ToList();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context
                  .Books
                  .Count(b => b.Title.Length > lengthCheck);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context
                .Books
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Title = b.Title,
                    AuthorFirstName = b.Author.FirstName,
                    AuthorLastName = b.Author.LastName
                })
                .Where(a => a.AuthorLastName.ToLower().StartsWith(input.ToLower()))
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                    .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                    .Select(b => b.Title)
                    .OrderBy(t => t)
                    .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                    .Where(a => a.FirstName.EndsWith(input))
                    .Select(a => a.FirstName + " " + a.LastName)
                    .OrderBy(a => a)
                    .ToList();

            return string.Join(Environment.NewLine, authors);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateTime = DateTime.Parse(date);

            var books = context.Books
                    .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate < dateTime)
                    .OrderByDescending(b => b.ReleaseDate)
                    .Select(b => new
                    {
                        b.Title,
                        b.EditionType,
                        b.Price,
                    })
                    .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - {book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var cateogries = input.Split(" ").Select(s => s.ToLower()).ToArray();

            var books = context.Books
                    .Where(b => b.BookCategories
                                .Any(bc => b.BookCategories
                                            .Any(bc => cateogries.Any(c => c == bc.Category.Name.ToLower()))))
                    .Select(b => b.Title)
                    .OrderBy(t => t)
                    .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                   .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                   .OrderBy(b => b.BookId)
                   .Select(b => b.Title)
                   .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                    .Where(b => b.Price > 40)
                    .Select(b => new
                    {
                        b.Title,
                        b.Price
                    })
                    .OrderByDescending(b => b.Price)
                    .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                    .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestrict = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            var books = context.Books
                    .Where(b => b.AgeRestriction == ageRestrict)
                    .Select(b => b.Title)
                    .OrderBy(b => b);

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
