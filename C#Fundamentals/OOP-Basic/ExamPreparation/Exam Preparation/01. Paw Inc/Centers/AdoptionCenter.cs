using System;
using System.Collections.Generic;
using System.Linq;
using _01.Paw_Inc.Centers;

namespace _01.Paw_Inc
{
    public class AdoptionCenter : Center
    {
        private List<Animal> adoptedAnimals = new List<Animal>();
        private List<Animal> unCleansed = new List<Animal>();
        private List<Animal> toAdopt =new List<Animal>();

        public AdoptionCenter(string name):base(name)
        {
            this.Name = name;
        }

        public List<Animal> AdoptedAnimals
        {
            get { return this.adoptedAnimals;}
        }

        public void Adopt()
        {
            for (int i = 0; i < this.StoredAnimals.Count; i++)
            {
                if (this.StoredAnimals[i].CleansingStatus)
                {
                    this.AdoptedAnimals.Add(this.StoredAnimals[i]);

                }
                else
                {
                    this.unCleansed.Add(this.StoredAnimals[i]);
                }               
            }
            this.StoredAnimals.Clear();
            foreach (var animal in this.unCleansed)
            {
                this.StoredAnimals.Add(animal);
            }

        }
        public void AdmitAnimal(Animal animal)
        {
            animal.Center = this.Name;
            this.StoredAnimals.Add(animal);
            
        }

        public void SendForCleance(string cleansingCenter)
        {        
            for (int i = 0; i < this.StoredAnimals.Count; i++)
            {
                if (!this.StoredAnimals[i].CleansingStatus)
                {
                    var center = AvailableCentres.cleansingCenters.First(x => x.Name == cleansingCenter);
                    center.StoredAnimals.Add(StoredAnimals[i]);
                    //Console.WriteLine(this.StoredAnimals[i].Name);
                }
                else
                {
                    this.toAdopt.Add(this.StoredAnimals[i]);
                }                            
            };
            this.StoredAnimals.Clear();
            foreach (var animal in this.toAdopt)
            {
                this.StoredAnimals.Add(animal);
            }
        }
        public void SendForCastration(string castrationCenter)
        {
            for (int i = 0; i < this.StoredAnimals.Count; i++)
            {
                if (!this.StoredAnimals[i].Castrateed)
                {
                    var center = AvailableCentres.castrationCenters.First(x => x.Name == castrationCenter);
                    center.StoredAnimals.Add(StoredAnimals[i]);
                    //Console.WriteLine(this.StoredAnimals[i].Name);
                }
            };
            this.StoredAnimals.Clear();
        }
    }
}
