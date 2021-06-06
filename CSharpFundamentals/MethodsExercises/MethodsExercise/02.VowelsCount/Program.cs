using System;
using System.Linq;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int count = GetCount(word.ToLower());

            Console.WriteLine(count);
        }

        private static int GetCount(string word)
        {
            return word.Where(x => x =='a'||x=='o'||x=='e'||x=='u'||x=='i').Count();
        }
    }
}
