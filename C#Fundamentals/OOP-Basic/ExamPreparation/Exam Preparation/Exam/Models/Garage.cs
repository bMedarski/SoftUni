using System.Collections.Generic;
using Exam.Contracts;

namespace Exam.Models
{
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
}
