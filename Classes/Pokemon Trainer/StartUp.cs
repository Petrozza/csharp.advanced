using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Trainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Tournament")
                {
                    break;
                }

                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHealth = int.Parse(data[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer currentTrainer = new Trainer(trainerName);
                
                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, currentTrainer);
                }

                trainers[trainerName].Pokemons.Add(pokemon);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                foreach ((string trainerName, Trainer trainer) in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;

                        }
                        trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
            }
            var result = trainers.OrderByDescending(x => x.Value.Badges).ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} {item.Value.Badges} {item.Value.Pokemons.Count}");
            }
        }
    }
}
