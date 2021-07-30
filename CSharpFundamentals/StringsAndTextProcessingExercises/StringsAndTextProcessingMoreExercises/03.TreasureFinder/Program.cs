using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "find")
            {
                int num = 0;
                List<char> text = input.ToCharArray().ToList();

                for (int i = 0; i < text.Count; i++)
                {
                    text[i] = (char)((int)text[i] - key[num]);

                    num++;

                    if (num == key.Length)
                    {
                        num = 0;
                    }
                }
                
                int typeStart = text.IndexOf('&');
                string type = string.Join("", text.Skip(typeStart + 1).TakeWhile(x => x != '&'));

                int coordsStart = text.IndexOf('<');
                string coords = string.Join("", text.Skip(coordsStart + 1).TakeWhile(x => x != '>'));

                Console.WriteLine($"Found {type} at {coords}");

                input = Console.ReadLine();
            }
        }
    }
}
