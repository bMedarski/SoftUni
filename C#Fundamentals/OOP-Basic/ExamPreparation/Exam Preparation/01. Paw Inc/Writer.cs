using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Paw_Inc.Centers;

namespace _01.Paw_Inc
{
    public class Writer
    {
        private List<string> adoptedAnimals = new List<string>();
        private List<string> cleancedAnimals = new List<string>();
        private List<string> awaitingAdoption = new List<string>();
        private List<string> awaitingCleansing = new List<string>();
        private StringBuilder sb = new StringBuilder();

        public void Status()
        {
            GetAdoptedAnimals();
            GetCleancedAnimals();
            GetAnimalsWaitingForCleansing();
            GetWaitingForAdoptionAnimals();

            sb.AppendLine("Paw Incorporative Regular Statistics");
            sb.AppendLine($"Adoption Centers: { AvailableCentres.adoptionCenters.Count}");
            sb.AppendLine($"Cleansing Centers: { AvailableCentres.cleansingCenters.Count}");
            sb.AppendLine($"Adopted Animals: {string.Join(", ",adoptedAnimals.OrderBy(x=>x))}");
            sb.AppendLine($"Cleansed Animals: {string.Join(", ", cleancedAnimals.OrderBy(x => x))}");
            sb.AppendLine($"Animals Awaiting Adoption: { awaitingAdoption.Count}");
            sb.AppendLine($"Animals Awaiting Cleansing: { awaitingCleansing.Count}");
            Console.WriteLine(sb);
        }

        private void GetWaitingForAdoptionAnimals()
        {
            foreach (var center in AvailableCentres.adoptionCenters)
            {
                foreach (var animal in center.StoredAnimals)
                {
                    if (animal.CleansingStatus)
                    {
                        awaitingAdoption.Add(animal.Name);
                    }
                }
            }
        }
        private void GetAdoptedAnimals()
        {
            foreach (var center in AvailableCentres.adoptionCenters)
            {

                foreach (var animal in center.AdoptedAnimals)
                {
                    //Console.WriteLine(animal.Name);
                    adoptedAnimals.Add(animal.Name);
                }
            }
        }
        private void GetCleancedAnimals()
        {
            foreach (var center in AvailableCentres.cleansingCenters)
            {
                foreach (var animal in center.CleansecAnimals)
                {
                    //Console.WriteLine(animal.Name);
                    cleancedAnimals.Add(animal.Name);
                }
            }
        }
        private void GetAnimalsWaitingForCleansing()
        {
            foreach (var center in AvailableCentres.cleansingCenters)
            {
                foreach (var animal in center.StoredAnimals)
                {
                    //Console.WriteLine(animal.Name);
                    awaitingCleansing.Add(animal.Name);
                }
            }
        }
    }
}
