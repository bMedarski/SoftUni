
using System.Text;
using Exam.Contracts;

namespace Exam.Models.Cars
{
    public class ShowCar : Car, IShowCar
    {
        public ShowCar(string brand, string model, int year, int horsepower, int acceleration, int suspension, int durability) 
            : base(brand, model, year, horsepower, acceleration, suspension, durability)
        {
            this.Stars = 0;
        }

        public int Stars { get; set; }

        public override string ToString()
        {
            var st = new StringBuilder();
            st.AppendLine($"{base.Brand} {base.Model} {base.YearOfProduction}");
            st.AppendLine($"{base.Horsepower} HP, 100 m/h in {base.Acceleration} s");
            st.AppendLine($"{base.Suspension} Suspension force, {base.Durability} Durability");
            st.Append($"{this.Stars} *");
            return st.ToString();
        }
    }
}
