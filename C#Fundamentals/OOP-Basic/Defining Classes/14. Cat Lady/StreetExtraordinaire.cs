using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Cat_Lady
{
    public class StreetExtraordinaire : Cat
    {
        private int decibelsOfMeows;

        public StreetExtraordinaire(string name, int decibelsOfMeows) : base(name)
        {
            this.DecibelsOfMeows = decibelsOfMeows;
        }

        public int DecibelsOfMeows
        {
            get { return this.decibelsOfMeows; }
            set { this.decibelsOfMeows = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"StreetExtraordinaire {this.Name} {this.decibelsOfMeows}");
            return sb.ToString();
        }
    }
}
