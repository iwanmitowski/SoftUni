using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var date1 = Console.ReadLine();
            var date2 = Console.ReadLine();

            Console.WriteLine(DateModifier.DateDiff(date1, date2));
        }
    }
}
