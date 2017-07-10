using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _01.Paw_Inc.Centers;

namespace _01.Paw_Inc
{
    public class Writer
    {
        private List<string> adoptedAnimals = new List<string>();
        private List<string> cleancedAnimals = new List<string>();
        private List<string> awaitingAdoption = new List<string>();
        private List<string> awaitingCleansing = new List<string>();
        private List<string> castratedAnimals = new List<string>();
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
            if (adoptedAnimals.Count == 0)
            {
                sb.AppendLine($"Adopted Animals: None");
            }
            else
            {
               sb.AppendLine($"Adopted Animals: {string.Join(", ",this.adoptedAnimals.OrderBy(x=>x))}"); 
            }
            if (cleancedAnimals.Count == 0)
            {
                sb.AppendLine($"Cleansed Animals: None");
            }
            else
            {
                sb.AppendLine($"Cleansed Animals: {string.Join(", ", cleancedAnimals.OrderBy(x => x))}");
            }
            sb.AppendLine($"Animals Awaiting Adoption: { this.awaitingAdoption.Count}");          
            sb.AppendLine($"Animals Awaiting Cleansing: { this.awaitingCleansing.Count}");
            Console.WriteLine(sb);
        }
        public void CastrationStatistics()
        {
            GetCastratedAnimals();

            var st = new StringBuilder();
            st.AppendLine("Paw Inc. Regular Castration Statistics");
            st.AppendLine($"Castration Centers: {AvailableCentres.castrationCenters.Count}");
            if (castratedAnimals.Count == 0)
            {
                st.Append($"Castrated Animals: None");
            }
            else
            {
               st.Append($"Castrated Animals: {string.Join(", ", this.castratedAnimals)}"); 
            }
            
            Console.WriteLine(st);
        }
        private void GetWaitingForAdoptionAnimals()
        {
            foreach (var center in AvailableCentres.adoptionCenters)
            {
                foreach (var animal in center.StoredAnimals)
                {
                    if (animal.CleansingStatus)
                    {
                        this.awaitingAdoption.Add(animal.Name);
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
                    this.adoptedAnimals.Add(animal.Name);
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
                    this.cleancedAnimals.Add(animal.Name);
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
                    this.awaitingCleansing.Add(animal.Name);
                }
            }
        }
        private void GetCastratedAnimals()
        {
            foreach (var center in AvailableCentres.castrationCenters)
            {
                foreach (var animal in center.CastratedAnimals.OrderBy(x=>x.Name))
                {
                    //Console.WriteLine(animal.Name);
                    this.castratedAnimals.Add(animal.Name);
                }
            }
        }
    }
}
