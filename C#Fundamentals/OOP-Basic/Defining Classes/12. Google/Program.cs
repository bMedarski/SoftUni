using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Google
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            while (true)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                if (input[0] == "End")
                {
                    break;
                }
                else
                {
                    Person person;
                        if (people.FindIndex(x => x.Name == input[0]) != -1)
                        {
                            person = people.First(x => x.Name == input[0]);
                        }
                        else
                        {
                            person = new Person(input[0]);
                            people.Add(person);
                        }

                    if (input[1]=="company")
                    {
                        var company = new Company(input[2],input[3],double.Parse(input[4]));
                        person.Company = company;
                    }
                    else if (input[1] == "car")
                    {
                        var car = new Car(input[2], int.Parse(input[3]));
                        person.Car = car;
                    }
                    else if (input[1] == "pokemon")
                    {
                        var pokemon = new Pokemon(input[2],(input[3]));
                        person.AddPokemon(pokemon);
                    }
                    else if (input[1] == "parents")
                    {
                        var parent = new Person(input[2]);
                        parent.Birthdate = input[3];
                        person.AddParent(parent);
                    }
                    else if (input[1] == "children")
                    {
                        var children = new Person(input[2]);
                        children.Birthdate = input[3];
                        person.AddChildren(children);
                    }
                }
                               
            }
            var toPrint = Console.ReadLine();
            var p = people.Where(x => x.Name == toPrint).ToArray()[0].ToString();
            Console.WriteLine(p);
        }
    }
}
