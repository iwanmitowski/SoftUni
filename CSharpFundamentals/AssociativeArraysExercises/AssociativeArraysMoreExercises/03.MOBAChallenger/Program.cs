using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace _03.MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerPositionSkill = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();



            while (input != "Season end")
            {
                if (input.Contains("->"))
                {
                    string[] tokens = input.Split(" -> ");
                    string player = tokens[0];
                    string position = tokens[1];
                    int skill = int.Parse(tokens[2]);

                    if (!playerPositionSkill.ContainsKey(player))
                    {
                        playerPositionSkill.Add(player, new Dictionary<string, int>());
                        playerPositionSkill[player].Add(position, skill);
                    }
                    else
                    {

                        if (!playerPositionSkill[player].ContainsKey(position))
                        {
                            playerPositionSkill[player].Add(position, skill);
                        }
                        else
                        {
                            int currentSkill = playerPositionSkill[player][position];

                            if (currentSkill < skill)
                            {
                                playerPositionSkill[player][position] = skill;
                            }
                        }
                    }
                }
                else
                {
                    string[] tokens = input.Split(" vs ");

                    string p1 = tokens[0];
                    string p2 = tokens[1];

                    if (!playerPositionSkill.ContainsKey(p1) || !playerPositionSkill.ContainsKey(p2))
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    bool isFighting = false;

                    foreach ((string position1, int skill1) in playerPositionSkill[p1])
                    {
                        foreach ((string position2, int skill2) in playerPositionSkill[p2])
                        {
                            if (position1 == position2)
                            {
                                isFighting = true;

                                if (skill1 > skill2)
                                {
                                    playerPositionSkill.Remove(p2);
                                    isFighting = true;
                                }
                                else if (skill1 < skill2)
                                {
                                    playerPositionSkill.Remove(p1);
                                }
                                
                                break;
                            }
                        }

                        if (isFighting)
                        {
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach ((string player, Dictionary<string, int> positionSkill) in playerPositionSkill
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(x => x.Key))
            {
                int totalSkill = positionSkill.Values.Sum();
                Console.WriteLine($"{player}: {totalSkill} skill");

                foreach ((string position, int skill) in positionSkill
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {position} <::> {skill}");
                }
            }
        }
    }
}
