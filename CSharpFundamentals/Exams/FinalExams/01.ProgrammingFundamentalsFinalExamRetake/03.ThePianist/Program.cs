using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            var pieceKeyComposer = new Dictionary<string, string[]>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("|");

                string piece = tokens[0];
                string composer = tokens[1];
                string key = tokens[2];

                pieceKeyComposer.Add(piece, new string[] { key, composer });
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] tokens = input.Split("|");

                string command = tokens[0];
                string piece = tokens[1];

                switch (command)
                {
                    case "Add":
                        string composer = tokens[2];
                        string key = tokens[3];

                        if (!pieceKeyComposer.ContainsKey(piece))
                        {
                            pieceKeyComposer.Add(piece, new string[2] { key, composer });
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                        }
                        break;
                    case "Remove":
                        if (!pieceKeyComposer.ContainsKey(piece))
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        else
                        {
                            pieceKeyComposer.Remove(piece);

                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        break;
                    case "ChangeKey":
                        if (!pieceKeyComposer.ContainsKey(piece))
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        else
                        {
                            string newKey = tokens[2];

                            pieceKeyComposer[piece][0] = newKey;
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            foreach ((string pieceName, string[] keyComposer) in pieceKeyComposer.OrderBy(x => x.Key).ThenBy(x => x.Key[1]))
            {
                Console.WriteLine($"{pieceName} -> Composer: {keyComposer[1]}, Key: {keyComposer[0]}");
            }
        }
    }
}
