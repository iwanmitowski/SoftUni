using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class Vlogger
    {
        public Vlogger()
        {
            this.Followers = new SortedSet<string>();
            this.Following = new HashSet<string>();
        }
        public string Name { get; set; }
        public SortedSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Vlogger>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] tokens = input.Split();

                string vlogger = tokens[0];
                string command = tokens[1];
                string secondVlogger = tokens[2];

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(vlogger))
                    {
                        vloggers.Add(vlogger, new Vlogger());
                    }
                }
                else if (command == "followed")
                {
                    if (vloggers.ContainsKey(vlogger) &&
                        vloggers.ContainsKey(secondVlogger) &&
                        vlogger != secondVlogger)
                    {
                        if (vloggers[vlogger].Following.Contains(secondVlogger))
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        vloggers[vlogger].Following.Add(secondVlogger);
                        vloggers[secondVlogger].Followers.Add(vlogger);
                    }

                }

                input = Console.ReadLine();
            }

            vloggers = vloggers
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count)
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int counter = 0;

            foreach ((string name, Vlogger vlogger) in vloggers)
            {
                Console.WriteLine($"{++counter}. {name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");

                if (counter == 1)
                {
                    foreach (var follower in vlogger.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}
