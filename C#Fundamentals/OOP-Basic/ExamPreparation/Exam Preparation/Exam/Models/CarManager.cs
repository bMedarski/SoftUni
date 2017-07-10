using System;
using Exam.Contracts;
using Exam.Core.Factory;
using Exam.Models.Cars;
using Exam.Providers;

namespace Exam.Models
{
    public class CarManager : ICarManager
    {
        private static readonly ICarManager carManagerInstance = new CarManager();
        private ICarFactory carFactory;
        private IRaceFactory raceFactory;
        private IWriter writer;

        private CarManager()
        {
            this.carFactory = CarFactory.CarFactoryInstance;
            this.raceFactory = RaceFactory.RaceFactoryInstance;
            this.writer = new ConsoleWriter();
        }

        public static ICarManager CarManagerInstance
        {
            get { return carManagerInstance; }
        }

      

        public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        {
            carFactory.CreateCar( id,  type,  brand,  model,  yearOfProduction,  horsepower,  acceleration,  suspension,  durability);
           //to add here
        }

        public string Check(int id)
        {
            if (Data.cars.ContainsKey(id))
            {
                ICar car = Data.cars[id];
                if (car.GetType().Name== "PerformanceCar")
                {
                    car = (PerformanceCar) car;
                }else if (car.GetType().Name == "ShowCar")
                {
                    car = (ShowCar)car;
                }
                writer.WriteLine(car.ToString());   //not here
                return car.ToString();
            }else if (Data.garage.ContainsKey(id))
            {
                ICar car = Data.garage[id];
                if (car.GetType().Name == "PerformanceCar")
                {
                    car = (PerformanceCar)car;
                }
                else if (car.GetType().Name == "ShowCar")
                {
                    car = (ShowCar)car;
                }
                writer.WriteLine(car.ToString()); //not here
                return car.ToString();
            }
            else
            {
                return "No such car";
            }                    
        }

        public void Open(int id, string type, int length, string route, int prizePool,int optional)
        {
            
            raceFactory.CreateRace(id, type, length, route, prizePool,optional);
            
        }
        public void Participate(int carId, int raceId)
        {
            if (Data.cars.ContainsKey(carId))
            {
                ICar car = Data.cars[carId];                
                IRace race = Data.races[raceId];
                race.AddParticipiant(car);
            }            
        }
        public string Start(int id)
        {
            var s = Data.races[id].StartRace();
            Console.WriteLine(s);
            return s;
        }
        public void Park(int id)
        {
            if (Data.cars.ContainsKey(id))
            {
                foreach (var race in Data.races)
                {
                    if (race.Value.CheckForParticipiant(id))
                    {
                        return;
                    }
                }
            }
                ICar car = Data.cars[id];
                Data.garage.Add(id,car);
                Data.cars.Remove(id);                      
        }
        public void Unpark(int id)
        {
            ICar car = Data.garage[id];
            Data.cars.Add(id,car);
            Data.garage.Remove(id);
        }
        public void Tune(int tuneIndex, string addOn)
        {
            foreach (var car in Data.garage)
            {                   
                if (car.Value.GetType().Name=="ShowCar")
                    {                  
                        IShowCar carToTuned = (ShowCar)car.Value;
                        carToTuned.Horsepower += tuneIndex;
                        carToTuned.Suspension += tuneIndex / 2;
                        carToTuned.Stars += tuneIndex;
                    }
                    else if (car.Value.GetType().Name == "PerformanceCar")
                    {
                        IPerformanceCar carToTuned = (PerformanceCar)car.Value;
                        carToTuned.Horsepower += tuneIndex;
                        carToTuned.Suspension += tuneIndex / 2;
                        carToTuned.AddOn(addOn);
                    }
            }            
        }
    }
}
