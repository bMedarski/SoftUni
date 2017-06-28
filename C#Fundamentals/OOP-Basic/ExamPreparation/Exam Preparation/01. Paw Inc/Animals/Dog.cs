using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Paw_Inc
{
    class Dog : Animal
    {
        private int commands;

        public Dog(string name, int age, int commands)
        {
            this.Name = name;
            this.Age = age;
            this.Commands = commands;
        }

        public int Commands
        {
            get { return this.commands; }
            set
            {
                if (value > 0)
                {
                    this.commands = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("The commands must be positive number");
                }

            }
        }
    }
}
