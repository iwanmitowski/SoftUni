using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ");

            Queue<string> playlist = new Queue<string>(songs);


            while (playlist.Any())
            {
                var input = Console.ReadLine().Split("Add ");

                if (input[0] == "Play")
                {
                    playlist.Dequeue();
                }
                else if (input[0]=="Show")
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }
                else
                {
                    if (playlist.Contains(input[1]))
                    {
                        Console.WriteLine($"{input[1]} is already contained!");
                    }
                    else
                    {
                        playlist.Enqueue(input[1]);
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
