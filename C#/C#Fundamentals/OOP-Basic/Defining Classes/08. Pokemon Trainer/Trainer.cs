using System.Collections.Generic;

namespace _08.Pokemon_Trainer
{
    public class Trainer
    {
        private string name;
        private int badges = 0;
        private List<Pokemon> pokemons = new List<Pokemon>();

        public Trainer(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }
        public int Badges
        {
            get { return this.badges; }
            set { this.badges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
        }

        public void RemovePokemon(Pokemon pokemon)
        {
            this.Pokemons.Remove(pokemon);
        }

        public void AddPokemon(Pokemon pokemon)
        {
            this.Pokemons.Add(pokemon);
        }
    }
}
