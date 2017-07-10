
using System.Text;
using Exam.Contracts;

namespace Exam.Models
{
    public abstract class Car : ICar
    {

        private string brand;
        private string model;
        private int yearOfProduction;
        private int horsepower;
        private int acceleration;
        private int suspension;
        private int durability;

        public Car(string brand, string model, int year, int horsepower, int acceleration, int suspension,
            int durability)
        {
            this.Brand = brand;
            this.Model = model;
            this.YearOfProduction = year;
            this.Horsepower = horsepower;
            this.Acceleration = acceleration;
            this.Suspension = suspension;
            this.Durability = durability;
        }

        public string Brand
        {
            get { return this.brand; }
            protected set { this.brand = value; }
        }

        public string Model
        {
            get { return this.model; }
            protected set { this.model = value; }
        }

        public int YearOfProduction
        {
            get { return this.yearOfProduction; }
            protected set { this.yearOfProduction = value; }
        }

        public int Horsepower
        {
            get { return this.horsepower; }
            set { this.horsepower = value; }
        }

        public int Acceleration
        {
            get { return this.acceleration; }
            protected set { this.acceleration = value; }
        }

        public int Suspension
        {
            get { return this.suspension; }
            set { this.suspension = value; }
        }

        public int Durability
        {
            get { return this.durability; }
            protected set { this.durability = value; }
        }
    }
}
