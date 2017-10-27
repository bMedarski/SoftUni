using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main()
	{
		int count = int.Parse(Console.ReadLine());
		Employee[] employees = new Employee[count];

		for (int i = 0; i < count; i++)
		{
			string input = Console.ReadLine();
			string[] tokens = input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
			string name = tokens[0];
			decimal salary = decimal.Parse(tokens[1]);
			string position = tokens[2];
			string department = tokens[3];
			if (tokens.Length == 4)
			{
				employees[i] = new Employee(name, salary, position, department);
			}
			else if (tokens.Length == 5)
			{
				int age;
				bool isAge = int.TryParse(tokens[4], out age);
				if (isAge)
				{
					employees[i] = new Employee(name, salary, position, department, age);
				}
				else
				{
					string email = tokens[4];
					employees[i] = new Employee(name, salary, position, department, email);
				}
			}
			else
			{
				string email = tokens[4];
				int age = int.Parse(tokens[5]);
				employees[i] = new Employee(name, salary, position, department, email, age);
			}
		}

		Dictionary<string, decimal> totalSalaries = new Dictionary<string, decimal>();
		foreach (Employee employee in employees)
		{
			if (totalSalaries.ContainsKey(employee.Department))
			{
				totalSalaries[employee.Department] += employee.Salary;
			}
			else
			{
				totalSalaries[employee.Department] = employee.Salary;
			}
		}

		decimal highestAverageSalary = decimal.MinValue;
		string highestPaidDepartment = "";

		foreach (string department in totalSalaries.Keys)
		{
			decimal averageSalary = totalSalaries[department] / employees.Where(e => e.Department == department).Count();
			if (averageSalary > highestAverageSalary)
			{
				highestAverageSalary = averageSalary;
				highestPaidDepartment = department;
			}
		}

		Console.WriteLine("Highest Average Salary: {0}", highestPaidDepartment);
		foreach (Employee employee in employees.Where(e => e.Department == highestPaidDepartment).OrderByDescending(e => e.Salary))
		{
			Console.WriteLine("{0} {1:F2} {2} {3}", employee.Name, employee.Salary, employee.Email, employee.Age);
		}
	}
}