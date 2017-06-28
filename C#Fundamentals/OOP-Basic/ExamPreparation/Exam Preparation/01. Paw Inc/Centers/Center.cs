using System.Collections.Generic;

namespace _01.Paw_Inc
{
    abstract class Center
    {
        private string name;
        private List<Animal> storedAnimals;

        protected Center(string name)
        {
            this.Name = name;
            this.storedAnimals = new List<Animal>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public List<Animal> StoredAnimals
        {
            get { return this.storedAnimals; }
        }
       
    }
}
