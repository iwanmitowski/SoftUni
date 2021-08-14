using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> personHpEnergy = new Dictionary<string, int[]>();

            string input = Console.ReadLine();

            while (input != "Results")
            {
                string[] tokens = input.Split(":");

                string command = tokens[0];
                string name = tokens[1];
                if (command == "Add")
                {
                    int hp = int.Parse(tokens[2]);
                    int energy = int.Parse(tokens[3]);

                    if (!personHpEnergy.ContainsKey(name))
                    {
                        personHpEnergy.Add(name, new int[2] { hp,energy});
                    }
                    else
                    {
                        personHpEnergy[name][0] += hp;
                    }
                }
                else if (command == "Attack")
                {
                    string defender = tokens[2];
                    int dmg = int.Parse(tokens[3]);

                    if (personHpEnergy.ContainsKey(name) &&
                        personHpEnergy.ContainsKey(defender))
                    {
                        personHpEnergy[name][1]--;
                        personHpEnergy[defender][0] -= dmg;

                        if (personHpEnergy[defender][0] <= 0)
                        {
                            personHpEnergy.Remove(defender);
                            Console.WriteLine($"{defender} was disqualified!");
                        }
                        if (personHpEnergy[name][1] <=0 )
                        {
                            personHpEnergy.Remove(name);
                            Console.WriteLine($"{name} was disqualified!");
                        }
                    }
                }
                else if (command=="Delete")
                {
                    if (name=="All")
                    {
                        personHpEnergy = new Dictionary<string, int[]>();
                    }
                    else
                    {
                        personHpEnergy.Remove(name);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"People count: {personHpEnergy.Count}");
            foreach ((string name, int[] hpEn) in personHpEnergy.OrderByDescending(x=>x.Value[0]).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{name} - {hpEn[0]} - {hpEn[1]}");
            }
        }
        
    }
}
