using System.Collections.Generic;
using System.Linq;
using _01.Paw_Inc.Centers;

namespace _01.Paw_Inc
{
    internal class CleansingCenter : Center
    {
        private readonly List<Animal> cleansedAnimals;

        public CleansingCenter(string name):base(name)
        {
            this.Name = name;
            this.cleansedAnimals = new List<Animal>();
        }

        public List<Animal> CleansecAnimals => this.cleansedAnimals;

        public void Cleanse()
        {
            foreach (var animal in this.StoredAnimals)
            {
                animal.CleansingStatus = true;
                var center = AvailableCentres.adoptionCenters.FirstOrDefault(x => x.Name == animal.Center);
                center.AdmitAnimal(animal);
                this.cleansedAnimals.Add(animal);                
            }
                this.StoredAnimals.Clear();
        }
    }
}
