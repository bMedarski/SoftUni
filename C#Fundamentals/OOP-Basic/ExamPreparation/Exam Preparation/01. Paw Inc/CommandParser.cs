using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Paw_Inc.Centers;

namespace _01.Paw_Inc
{
    class CommandParser
    {
        public void ProcessCommand(string input)
        {
            var command = input.Split(new char[] {' ', '|'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (command[0]== "RegisterCleansingCenter")
            {
                var center = new CleansingCenter(command[1]);
                AvailableCentres.cleansingCenters.Add(center);
            }
            else if (command[0] == "RegisterAdoptionCenter")
            {
                var center = new AdoptionCenter(command[1]);
                AvailableCentres.adoptionCenters.Add(center);
            }
            else if (command[0] == "RegisterDog")
            {
                var animal = new Dog(command[1],int.Parse(command[2]),int.Parse(command[3]));                
                var center = AvailableCentres.adoptionCenters.First(x => x.Name == command[4]);
                center.AdmitAnimal(animal);
                //foreach (var an in center.StoredAnimals)
                //{
                //    Console.WriteLine($"-{an.Name}-");
                //}
            }
            else if (command[0] == "RegisterCat")
            {
                var animal = new Cat(command[1], int.Parse(command[2]), int.Parse(command[3]));
                var center = AvailableCentres.adoptionCenters.First(x => x.Name == command[4]);
                center.AdmitAnimal(animal);
                //foreach (var an in center.StoredAnimals)
                //{
                //    Console.WriteLine($"-{an.Name}-");
                //}
            }
            else if (command[0] == "SendForCleansing")
            {
                var center = AvailableCentres.adoptionCenters.FirstOrDefault(x => x.Name == command[1]);
                //foreach (var an in center.StoredAnimals)
                //{
                //    Console.WriteLine($"-{an.Name}-");
                //}
                center.SendForCleance(command[2]);
            }
            else if (command[0] == "Cleanse")
            {
                var center = AvailableCentres.cleansingCenters.FirstOrDefault(x => x.Name == command[1]);

                foreach (var animal in center.StoredAnimals)
                {
                    //Console.WriteLine($"animal:{animal.Name}");
                }               
                center.Cleanse();
            }
            else if (command[0] == "Adopt")
            {
                var center = AvailableCentres.adoptionCenters.First(x => x.Name == command[1]);
                center.Adopt();
            }
            else
            {
                throw new IndexOutOfRangeException("Wrong command");
            }
        }
    }
}
