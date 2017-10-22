using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Pokemon_Trainer
{
    class Program
    {
        static void Main()
        {
            var trainers = new List<Trainer>();
            var foundTrainer = false;
            var foundPokemon = false;
            while (true)
            {
                var input = Console.ReadLine();
                if (input== "Tournament")
                {
                    break;                   
                }
                var split = input.Split(' ').ToArray();
                var pokemon = new Pokemon(split[1],split[2],int.Parse(split[3]));
                foreach (var trainerr in trainers)
                {
                    if (trainerr.Name == split[0])
                    {
                        trainerr.AddPokemon(pokemon);
                        foundTrainer = true;
                    }
                }
                if (!foundTrainer)
                {
                    var trainer = new Trainer(split[0]);
                    trainer.AddPokemon(pokemon);
                    trainers.Add(trainer);
                }
                foundTrainer = false;
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                    foreach (var trainer in trainers)
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            if (pokemon.Element== input)
                            {
                                trainer.Badges += 1;
                                foundPokemon = true;
                                break;
                            }
                        }
                        if (foundPokemon)
                        {
                            foundPokemon = false;
                        }
                        else
                        {
                            for (int i = 0; i < trainer.Pokemons.Count; i++)
                            {
                                trainer.Pokemons[i].Health -= 10;
                                if (trainer.Pokemons[i].Health <= 0)
                                {
                                    trainer.RemovePokemon(trainer.Pokemons[i]);
                                }
                        }
                            //foreach (var pokemon in trainer.Pokemons)
                            //{
                            //    pokemon.Health -= 10;
                            //    if (pokemon.Health<=0)
                            //    {
                            //        trainer.RemovePokemon(pokemon);
                            //    }
                            //}
                        }
                    }
            }

            foreach (var trainer in trainers.OrderByDescending(x=>x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
