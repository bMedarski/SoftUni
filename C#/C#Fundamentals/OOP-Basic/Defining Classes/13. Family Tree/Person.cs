using System;
using System.Collections.Generic;
using System.Text;

namespace _13.Family_Tree
{
    public class Person
    {
        private string name;
        private List<Person> parents = new List<Person>();
        private List<Person> childrens = new List<Person>();     
        private DateTime birthdate;

        public Person(string name)
        {
            this.Name = name;
        }

        public Person(DateTime birthdate)
        {
            this.Birthdate = birthdate;
        }

        public string Name
        {
           get { return this.name; }
           set { this.name = value; }
        }
        public List<Person> Parents
        {
            get { return this.parents; }
        }

        public List<Person> Childrens
        {
            get { return this.childrens; }
        }
        public DateTime Birthdate
        {
            get { return this.birthdate; }
            set { this.birthdate = value; }
        }

        public void AddParent(Person parent)
        {
            this.parents.Add(parent);
        }

        public void AddChildren(Person children)
        {
            this.childrens.Add(children);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} {this.Birthdate.Date}/{this.Birthdate.Month}/{this.Birthdate.Year}");
            sb.AppendLine($"Parents: ");
            foreach (var parent in this.Parents)
            {
                sb.AppendLine($"{parent.Name} {parent.Birthdate.Date}/{parent.Birthdate.Month}/{parent.Birthdate.Year}");
            }
            sb.AppendLine($"Children: ");
            foreach (var child in this.Childrens)
            {
                sb.AppendLine($"{child.Name} {child.Birthdate.Date}/{child.Birthdate.Month}/{child.Birthdate.Year}");
            }
            return sb.ToString();
        }
    }
}
