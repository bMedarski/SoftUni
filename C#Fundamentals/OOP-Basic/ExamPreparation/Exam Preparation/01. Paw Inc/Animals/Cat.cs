using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Paw_Inc
{
    class Cat : Animal
    {
        private int intelligence;

        public Cat(string name,int age,int intelligence)
        {
            this.Name = name;
            this.Age = age;
            this.Intelligence = intelligence;
        }

        public int Intelligence
        {
            get { return this.intelligence; }
            set
            {
                if (value > 0)
                {
                    this.intelligence = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("The intelligence must be positive number");
                }

            }
        }

    }
}
