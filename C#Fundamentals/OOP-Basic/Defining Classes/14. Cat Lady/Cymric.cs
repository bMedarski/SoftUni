using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Cat_Lady
{
    public class Cymric : Cat
    {
        private double furLength;

        public Cymric(string name, double furLength) : base(name)
        {
            this.FurLength = furLength;
        }

        public double FurLength
        {
            get { return this.furLength; }
            set { this.furLength = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cymric {this.Name} {this.FurLength:F2}");
            return sb.ToString();
        }
    }
}
