using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
    public class Person
    {
        private string name;
        private Company company = null;
        private List<Person> parents = new List<Person>();
        private List<Person> childrens = new List<Person>();
        private List<Pokemon> pokemons = new List<Pokemon>();
        private Car car = null;
        private string birthdate;

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }
        public Company Company
        {
            get { return this.company; }
            set { this.company = value; }
        }

        public List<Person> Parents
        {
            get { return this.parents; }
        }

        public List<Person> Childrens
        {
            get { return this.childrens; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
        }

        public Car Car
        {
            get { return this.car; }
            set { this.car = value; }
        }

        public string Birthdate
        {
            get { return this.birthdate; }
            set { this.birthdate = value; }
        }

        public void AddParent(Person parent)
        {
            this.parents.Add(parent);
        }

        public void AddChildren(Person children)
        {
            this.childrens.Add(children);
        }

        public void AddPokemon(Pokemon pokemon)
        {
            this.pokemons.Add(pokemon);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Name);
            sb.AppendLine($"Company: ");
            if (this.Company!=null)
            {
               sb.AppendLine($"{this.Company.Name} {this.Company.Department} {this.Company.Salary:F2}");  
            }           
            sb.AppendLine($"Car: ");
            if (this.Car != null)
            {
              sb.AppendLine($"{this.Car.Model} {this.Car.Speed}");  
            }          
            sb.AppendLine($"Pokemon: ");
            foreach (var pokemon in this.Pokemons)
            {
                sb.AppendLine($"{pokemon.Name} {pokemon.Type}");
            }
            sb.AppendLine($"Parents: ");
            foreach (var parent in this.Parents)
            {
                sb.AppendLine($"{parent.Name} {parent.Birthdate}");
            }
            sb.AppendLine($"Children: ");
            foreach (var child in this.Childrens)
            {
                sb.AppendLine($"{child.Name} {child.Birthdate}");
            }
            return sb.ToString();
        }
    }
}
