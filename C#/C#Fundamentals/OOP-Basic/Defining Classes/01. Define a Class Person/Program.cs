using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01.Define_a_Class_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);

        }
    }

    class Person
    {
        public string name;
        public int age;

        public Person()
        {
            
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
    }
}
