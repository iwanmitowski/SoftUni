using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string tournamentInput = Console.ReadLine();

            var trainers = new Dictionary<string, Trainer>();

            while (tournamentInput != "Tournament")
            {
                var tokens = tournamentInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                trainers[trainerName].Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));

                tournamentInput = Console.ReadLine();
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                foreach ((string trainerName, Trainer trainer) in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == input))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(x => x.Health -= 10);

                        if (trainer.Pokemons.Any(x => x.Health <= 0))
                        {
                            trainer.Pokemons = trainer.Pokemons.Where(x => x.Health > 0).ToList();
                        }
                    }
                }

                input = Console.ReadLine();
            }

            trainers.Select(x => x.Value).OrderByDescending(x => x.NumberOfBadges).ToList().ForEach(Console.WriteLine);
        }
    }
}
