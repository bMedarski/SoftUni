
    using System;
    using System.Text;

public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private double salary;

        public Person(string f, string l, int a, double s )
        {
            this.FirstName = f;
            this.LastName = l;
            this.Age = a;
            this.Salary = s;
        }

        public string FirstName
        {
        get { return this.firstName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot be less than 3 symbols");                   
            }
            this.firstName = value;
        }
    }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot be less than 3 symbols");
                }
               this.lastName = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set {
                    if(value<=0)
                    {
                    throw new ArgumentException("Age cannot be zero or negative integer");
                    }
                    this.age = value;
                }
        }

        public double Salary
        {
            get { return this.salary; }
            set {
                if (value < 460.00)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva");
                }
               this.salary = value; }
        }

        public void IncreaseSalary(double bonus)
        {
            if (this.Age > 30)
            {
                this.Salary += this.Salary*bonus/100;
            }
            else
            {
            this.Salary += this.Salary*bonus/200;
        }
        }
        public override string ToString()
        {

            var sb = new StringBuilder();
            sb.Append($"{this.FirstName} {this.LastName} get {this.Salary:F2} leva");
            return sb.ToString();
        }

        //Asen Harizanoov is a 44 years old
}

