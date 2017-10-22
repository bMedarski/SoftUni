using System;

    public class CarFactory : ICarFactory
    {
        private static ICarFactory carFactoryInstance = new CarFactory();

        private CarFactory()
        {
            
        }

        public static ICarFactory CarFactoryInstance
        {
            get { return carFactoryInstance; }
        }

        public void CreateCar(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        {
            if (type == "Performance")
            {
                ICar car = new PerformanceCar(brand,model,yearOfProduction,horsepower,acceleration,suspension,durability);
                Data.cars.Add(id,car);
            }
            else if (type == "Show")
            {
                ICar car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension,
                    durability);
                Data.cars.Add(id,car);
            }
            else
            {
                Console.WriteLine("No such type of car");
            }
        }
    }
