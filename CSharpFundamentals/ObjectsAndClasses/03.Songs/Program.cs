using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Songs
{
    class Song
    {
        public Song(string type, string name, string time)
        {
            Type = type;
            Name = name;
            Time = time;
        }

        public string Type { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> playlist = new List<Song>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arguments = Console.ReadLine().Split("_");

                playlist.Add(new Song(arguments[0], arguments[1], arguments[2]));
            }

            string type = Console.ReadLine();

            if (type=="all")
            {
                Console.WriteLine(string.Join(Environment.NewLine,playlist));
            }
            else
            {
                foreach (var song in playlist.Where(s => s.Type == type))
                {
                    Console.WriteLine(song);
                }
            }
            
        }
    }
}
