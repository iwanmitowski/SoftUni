using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestParticipantsPoints = new Dictionary<string, Dictionary<string, int>>();
            var participantPoints = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "no more time")
            {
                string[] tokens = input.Split(" -> ");

                string participant = tokens[0];
                string contest = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!participantPoints.ContainsKey(participant))
                {
                    participantPoints.Add(participant, 0);
                }

                if (!contestParticipantsPoints.ContainsKey(contest))
                {
                    contestParticipantsPoints.Add(contest, new Dictionary<string, int>());
                    contestParticipantsPoints[contest].Add(participant, points);
                    participantPoints[participant] += points;
                }
                else
                {
                    if (!contestParticipantsPoints[contest].ContainsKey(participant))
                    {
                        contestParticipantsPoints[contest].Add(participant, points);
                        participantPoints[participant] += points;
                    }
                    else
                    {
                        int currentPoints = contestParticipantsPoints[contest][participant];

                        if (currentPoints < points)
                        {
                            contestParticipantsPoints[contest][participant] = points;
                            participantPoints[participant] -= currentPoints;
                            participantPoints[participant] += points;
                        }
                    }


                }


                input = Console.ReadLine();
            }

            int counter = 0;

            foreach ((string contest, Dictionary<string, int> partPoints) in contestParticipantsPoints)
            {
                counter = 0;

                Console.WriteLine($"{contest}: {partPoints.Count} participants");
                foreach ((string name, int points) in partPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{++counter}. {name} <::> {points}");
                }
            }
            Console.WriteLine("Individual standings:");

            counter = 0;

            foreach ((string name, int points) in participantPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {

                Console.WriteLine($"{++counter}. {name} -> {points}");
            }

        }
    }
}
