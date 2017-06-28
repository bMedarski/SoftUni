//Define a class Employee that holds the following information: 
//name, salary, position, department, email and age.The name, salary, position and department are mandatory 
//    while the rest are optional.

//Your task is to write a program which takes N lines of employees from the 
//console and calculates the department with the highest average salary and prints 
//    for each employee in that department his name, salary, 
//    email and age – sorted by salary in descending order. 
//    If an employee doesn’t have an email – in place of that field you should print “n/a” instead, 
//    if he doesn’t have an age – print “-1” instead.
//The salary should be printed to two decimal places after the seperator.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _04.Company_Roster
{
    class Employee
    {
        public string name;
        public double salary;
        public string position;
        public string department;
        public string email="n/a";
        public int age=-1;

        public Employee(string name, double salary,string position, string department)
        {
            this.name = name;
            this.salary = salary;
            this.department = department;
            this.position = position;
        }
        public Employee(string name, double salary, string position, string department, int age)
        {
            this.name = name;
            this.salary = salary;
            this.department = department;
            this.position = position;
            this.age = age;
        }
        public Employee(string name, double salary, string position, string department, string email)
        {
            this.name = name;
            this.salary = salary;
            this.department = department;
            this.position = position;
            this.email = email;
        }
        public Employee(string name, double salary, string position, string department, string email, int age)
        {
            this.name = name;
            this.salary = salary;
            this.department = department;
            this.position = position;
            this.email = email;
            this.age = age;
        }
    }

    class Program
    {
        static void Main()
        {
            var countEmployee = int.Parse(Console.ReadLine());
            var Employees = new List<Employee>();

            for (int i = 0; i < countEmployee; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                var name = input[0];
                double salary = double.Parse(input[1], CultureInfo.InvariantCulture);
                var position = input[2];
                var department = input[3];
               // Console.WriteLine(name);
                //Console.WriteLine(department);
                if (input.Length == 5)
                {
                    if (input[4].IndexOf("@") != -1)
                    {
                        var email = input[4];
                        Employees.Add(new Employee(name, salary, position, department, email));
                    }
                    else
                    {
                        var email = "n/a";
                        var age = int.Parse(input[4]);
                        Employees.Add(new Employee(name, salary, position, department, email, age));
                    }
                }
                else if (input.Length == 6)
                {
                    var email = input[4];
                    var age = int.Parse(input[5]);
                    Employees.Add(new Employee(name, salary, position, department, email, age));
                }
                else
                {
                    Employees.Add(new Employee(name, salary, position, department));
                }
                
            }
            foreach (var employee in Employees)
            {
                //Console.WriteLine($"{employee.name}={employee.department}");
            }
            Dictionary<string, double> result = new Dictionary<string, double>();

            for (int i = 0; i < Employees.Count; i++)
            {
                if (result.ContainsKey(Employees[i].department))
                {
                    result[Employees[i].department] += Employees[i].salary;
                    result[Employees[i].department] /= 2.0d;
                }
                else
                {
                    result.Add(Employees[i].department, Employees[i].salary);
                }
            }

            var max = result.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            Console.WriteLine($"Highest Average Salary: {max}");
            foreach (var r in Employees.Where(x => x.department.Equals(max)).OrderByDescending(x => x.salary))
            {
                Console.WriteLine("{0} {1:F2} {2} {3}", r.name, r.salary, r.email, r.age);
            }
        }
    }
}
