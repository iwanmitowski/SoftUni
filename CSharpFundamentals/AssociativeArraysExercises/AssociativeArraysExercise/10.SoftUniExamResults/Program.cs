using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            //name points
            var participants = new Dictionary<string, int>();

            //contest submits
            var contests = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] tokens = input.Split("-");

                string name = tokens[0];
                string contest = tokens[1];

                if (contest == "banned")
                {
                    participants.Remove(name);
                    input = Console.ReadLine();
                    continue;
                }

                int points = int.Parse(tokens[2]);

                if (!participants.ContainsKey(name))
                {
                    participants.Add(name, points);
                }
                else
                {
                    if (participants[name] < points)
                    {
                        participants[name] = points;
                    }
                }

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, 0);
                }

                contests[contest]++;

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            foreach ((string name, int points) in participants.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{name} | {points}");
            }

            Console.WriteLine("Submissions:");
            foreach ((string contest, int submissions) in contests.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{contest} - {submissions}");
            }


        }
    }
}
