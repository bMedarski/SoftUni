
using System;

namespace _05.Pizza_Calories
{
    public class Dough
    {
        private string flour;
        private string bakeTechnique;
        private double weight;

        public Dough(string flour, string bakeTech, double weight)
        {
            this.Flour = flour;
            this.Weight = weight;
            this.BakeTechnique = bakeTech;
        }

        private string Flour
        {
            get { return this.flour; }
            set
            {
                if (value.ToLower()!="white"&& value.ToLower()!= "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flour = value;
            }
        }

        private string BakeTechnique
        {
            get { return this.bakeTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower()!="homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakeTechnique = value;
            }
        }

        private double Weight
        {
            get { return this.weight; }
            set
            {
                if (value<1||value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }
        public double Calories()
        {
            double calories = 2;
            if (Flour.ToLower() == "white")
            {
                calories *= Modifiers.WHITE;
            }
            else
            {
                calories *= Modifiers.WHOLEGRAIN;
            }

            if (BakeTechnique.ToLower() =="chewy")
            {
                calories *= Modifiers.CHEWY;
            }
            else if (BakeTechnique.ToLower() == "crispy")
            {
                calories *= Modifiers.CRISPY;
            }
            else
            {
                calories *= Modifiers.HOMEMADE;
            }
            return calories*this.Weight;
        }
    }
}
