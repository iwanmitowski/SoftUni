using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);

            var methods = type.GetMethods().Where(x=>x.CustomAttributes.Any(x=>x.AttributeType == typeof(AuthorAttribute)));

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(false);

                foreach (AuthorAttribute authorAttr in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {authorAttr.Name}");
                }
            }
        }
    }
}
