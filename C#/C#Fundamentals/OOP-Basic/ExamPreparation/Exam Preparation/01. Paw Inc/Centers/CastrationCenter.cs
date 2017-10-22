using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _01.Paw_Inc.Centers
{
    public class CastrationCenter : Center
    {
        private List<Animal> castratedAnimals = new List<Animal>();

        public CastrationCenter(string name) : base(name)
        {
            this.Name = name;
        }
        public List<Animal> CastratedAnimals => this.castratedAnimals;

        public void Castrate()
        {
            foreach (var animal in this.StoredAnimals)
            {
                animal.Castrateed = true;
                var center = AvailableCentres.adoptionCenters.FirstOrDefault(x => x.Name == animal.Center);
                center.AdmitAnimal(animal);
                castratedAnimals.Add(animal);
            }
            this.StoredAnimals.Clear();
        }
    }
}
