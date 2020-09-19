using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new List<Trainer>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Tournament")
                {
                    break;
                }

                var partsOfCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var trainerName = partsOfCommand[0];
                var pokemonName = partsOfCommand[1];
                var pokemonElement = partsOfCommand[2];
                var pokemonHealth = int.Parse(partsOfCommand[3]);

                if (trainers.Where(x => x.Name == trainerName).ToList().Count == 0)
                {
                    trainers.Add(new Trainer(trainerName));
                }

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainers.Where(x => x.Name == trainerName).FirstOrDefault().Pokemons.Add(pokemon);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                for (int i = 0; i < trainers.Count; i++)
                {
                    if (trainers[i].Pokemons.Where(x => x.Element == command).ToList().Count > 0)
                    {
                        trainers[i].Badges++;
                    }

                    else
                    {
                        for (int j = 0; j < trainers[i].Pokemons.Count; j++)
                        {
                            trainers[i].Pokemons[j].Health -= 10;

                            if (trainers[i].Pokemons[j].Health <= 0)
                            {
                                trainers[i].Pokemons.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
