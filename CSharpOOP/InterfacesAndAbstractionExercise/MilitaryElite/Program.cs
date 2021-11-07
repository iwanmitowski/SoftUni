using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var soldiers = new List<Soldier>();

            while (input != "End")
            {
                var tokens = input.Split();

                string rank = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];

                Soldier soldier = null;
                decimal salary = decimal.Parse(tokens[4]);

                switch (rank)
                {
                    case "Private":
                        soldier = new Private(id, firstName, lastName, salary);
                        break;

                    case "LieutenantGeneral":
                        var lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                        var privates = tokens.Skip(5).Select(int.Parse).ToArray();

                        foreach (var privId in privates)
                        {
                            lieutenantGeneral.AddPrivate(soldiers.First(x => x.Id == privId) as IPrivate);
                        }

                        soldier = lieutenantGeneral;
                        break;

                    case "Engineer":
                        var corps = tokens[5];
                        try
                        {
                            var engineer = new Engineer(id, firstName, lastName, salary,
                            corps);

                            var repairs = tokens.Skip(6).ToArray();

                            for (int i = 0; i < repairs.Length; i += 2)
                            {
                                string repairPart = repairs[i];
                                int repairHours = int.Parse(repairs[i + 1]);

                                engineer.AddRepair(new Repair(repairPart, repairHours));
                            }

                            soldier = engineer;
                        }
                        catch (Exception)
                        {
                            input = Console.ReadLine();
                            continue;
                        }
                        break;

                    case "Commando":
                        corps = tokens[5];
                        try
                        {
                            var commando = new Commando(id, firstName, lastName, salary,
                            corps);

                            var missions = tokens.Skip(6).ToArray();

                            for (int i = 0; i < missions.Length; i += 2)
                            {
                                string codeName = missions[i];
                                string missionState = missions[i + 1];

                                try
                                {
                                    commando.AddMission(new Mission(codeName, missionState));
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }

                            soldier = commando;
                        }
                        catch (Exception)
                        {
                            input = Console.ReadLine();
                            continue;
                        }
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(tokens[4]);
                        soldier = new Spy(id, firstName, lastName, codeNumber);
                        break;
                }

                soldiers.Add(soldier);
                input = Console.ReadLine();
            }

            soldiers.ForEach(Console.WriteLine);
        }
    }
}
