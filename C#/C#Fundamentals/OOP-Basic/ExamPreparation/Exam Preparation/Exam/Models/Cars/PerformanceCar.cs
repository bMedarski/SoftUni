using System.Collections.Generic;
using System.Text;

    public class PerformanceCar : Car, IPerformanceCar
    {
        private List<string> addOns;

        public PerformanceCar(string brand, string model, int year, int horsepower, int acceleration, int suspension, int durability) 
            : base(brand, model, year, horsepower, acceleration, suspension, durability)
        {
            this.addOns = new List<string>();
            base.Horsepower = (int)(horsepower * 1.5);
            base.Suspension = (int) (suspension * 0.75);
        }

        public void AddOn(string addon)
        {
            this.addOns.Add(addon);
        }
        public override string ToString()
        {
            var st = new StringBuilder();
            st.AppendLine($"{base.Brand} {base.Model} {base.YearOfProduction}");
            st.AppendLine($"{base.Horsepower} HP, 100 m/h in {base.Acceleration} s");
            st.AppendLine($"{base.Suspension} Suspension force, {base.Durability} Durability");
            if (this.addOns.Count == 0)
            {
                st.Append($"Add-ons: None");
            }
            else
            {
                st.Append($"Add-ons: {string.Join(", ",this.addOns)}");
            }          
            return st.ToString();
        }
    }    

