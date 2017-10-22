using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Google
{
    public class Car
    {
        private string model;
        private int speed;

        public Car(string model, int speed)
        {
            this.Model = model;
            this.Speed = speed;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public int Speed
        {
            get { return this.speed; }
            private set { this.speed = value; }
        }
    }
}
