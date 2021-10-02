using System;
using System.ComponentModel;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                var person = new Person(age, name);

                family.AddMember(person);
            }

            family.People.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList().ForEach(Console.WriteLine);
        }
    }
}
