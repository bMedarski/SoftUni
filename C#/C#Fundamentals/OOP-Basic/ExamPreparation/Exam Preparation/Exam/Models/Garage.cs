using System.Collections.Generic;
    public class Garage
    {
        private List<ICar> parkedCars;
        public Garage()
        {
            this.parkedCars = new List<ICar>();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
