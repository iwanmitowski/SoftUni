using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _03.Articles2._0
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    //With dynamic LINQ ordering
    static class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] articleArguments = Console.ReadLine().Split(", ");

                articles.Add(new Article(articleArguments[0], articleArguments[1], articleArguments[2]));
            }

            string sortingType = Console.ReadLine();

            sortingType = string.Join("", char.ToUpper(sortingType[0]) + sortingType.Substring(1));

            Console.WriteLine(
                string.Join(Environment.NewLine,
                    articles.AsQueryable()
                    .Ordering(sortingType)));
        }

        static IQueryable<Article> Ordering<Article>(
            this IQueryable<Article> source,
            string orderByProperty)
        {
            string command = "OrderBy";
            var type = typeof(Article);
            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            var resultExpression = Expression.Call(
                typeof(Queryable),
                command,
                new Type[] { type, property.PropertyType },
                source.Expression,
                Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<Article>(resultExpression);
        }

    }


}
