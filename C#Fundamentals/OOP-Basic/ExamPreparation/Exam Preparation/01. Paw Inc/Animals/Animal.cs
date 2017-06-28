using System;

namespace _01.Paw_Inc
{
    abstract class Animal
    {
        private string name;
        private int age;
        private bool cleansingStatus = false;
        private string center;
        private bool toBeRemoved = false;

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value > 0)
                {
                    this.age = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("The age must be positive number");
                }

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
    }
}
