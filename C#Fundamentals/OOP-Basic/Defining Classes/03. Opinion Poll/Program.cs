using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Opinion_Poll
{
    class Program
    {
        static void Main(string[] args)
        {
            var countPerson = int.Parse(Console.ReadLine());
            var Persons = new List<Person>();

            for (int i = 0; i < countPerson; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                var name = input[0];
                var age = int.Parse(input[1]);
                Persons.Add(new Person(name,age));
            }
            foreach (var person in Persons.OrderBy(x=>x.name))
            {
                if (person.age>30)
                {
                    Console.WriteLine($"{person.name} - {person.age}");
                }
            }

        }
    }
    class Person
    {
        public string name;
        public int age;

        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }
        public Person(int age)
        {
            this.name = "No name";
            this.age = age;
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
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

        public int Age
        {
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
