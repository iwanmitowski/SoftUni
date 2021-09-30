using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> namesFilter = (name, length) => name.Sum(x => x) >= length;

            Action<string[], Func<string, int, bool>> filtering = (names, filter) =>
            {
                Console.WriteLine(names.FirstOrDefault(name => filter(name, n)));
            };

            filtering(names, namesFilter);
        }
    }
}
