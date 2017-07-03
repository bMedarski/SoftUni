using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _14.Cat_Lady
{
    public abstract class Cat
    {
        private string name;

        public Cat(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }


    }
}
