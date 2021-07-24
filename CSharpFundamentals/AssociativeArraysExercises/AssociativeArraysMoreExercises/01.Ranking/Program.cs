using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestPassword = new Dictionary<string, string>();
            var userContestPoints = new Dictionary<string, Dictionary<string, int>>();
            var userTotalPoints = new Dictionary<string, int>();

            string contestInput = Console.ReadLine();

            while (contestInput != "end of contests")
            {
                string[] tokens = contestInput.Split(":");

                string name = tokens[0];
                string password = tokens[1];

                contestPassword.Add(name, password);

                contestInput = Console.ReadLine();
            }

            string submissionsInput = Console.ReadLine();

            while (submissionsInput != "end of submissions")
            {
                string[] tokens = submissionsInput.Split("=>");

                string contest = tokens[0];
                string password = tokens[1];

                if (contestPassword.ContainsKey(contest) && contestPassword[contest] == password)
                {
                    string username = tokens[2];
                    int points = int.Parse(tokens[3]);

                    if (!userContestPoints.ContainsKey(username))
                    {
                        userContestPoints.Add(username, new Dictionary<string, int>());

                        userContestPoints[username].Add(contest, points);
                        userTotalPoints.Add(username, points);
                    }
                    else
                    {

                        if (!userContestPoints[username].ContainsKey(contest))
                        {
                            userContestPoints[username].Add(contest, points);
                            userTotalPoints[username] += points;
                        }
                        else
                        {
                            int currentPoints = userContestPoints[username][contest];

                            if (points > currentPoints)
                            {
                                userContestPoints[username][contest] = points;
                                userTotalPoints[username] -= currentPoints;
                                userTotalPoints[username] += points;
                            }
                        }
                    }
                }

                submissionsInput = Console.ReadLine();
            }

            string bestCandidate = userTotalPoints.OrderByDescending(x => x.Value).First().Key;

            Console.WriteLine($"Best candidate is {bestCandidate} with total {userTotalPoints[bestCandidate]} points.");
            Console.WriteLine("Ranking:");
            foreach ((string name, Dictionary<string, int> contestPoints) in userContestPoints.OrderBy(x => x.Key))
            {
                Console.WriteLine(name);
                foreach ((string contest, int points) in contestPoints.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }

        }
    }
}
