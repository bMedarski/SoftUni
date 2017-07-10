using System;
using _01.Paw_Inc.Providers;

namespace _01.Paw_Inc
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private bool cleansingStatus = false;
        private string center;
        private bool toBeRemoved = false;
        private bool castrated = false;

        public int Age
        {
            get { return this.age; }
            set
            {
                Validator.ValidateLessThenValue(value,Constants.minAge,Constants.ageMustBePosiive);               

                //if (value > Constants.minAge)
                //{
                //    this.age = value;
                //}
                //else
                //{
                //    throw new IndexOutOfRangeException(Constants.ageMustBePosiive);
                //}
            }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Center
        {
            get { return this.center; }
            set { this.center = value; }
        }

        public bool CleansingStatus
        {
            get { return this.cleansingStatus; }
            set { this.cleansingStatus = value; }
        }

        public bool ToBeRemoved
        {
            get { return this.toBeRemoved; }
            set { this.toBeRemoved = value; }
        }

        public bool Castrateed
        {
            get { return this.castrated; }
            set { this.castrated = value; }
        }
    }
}
