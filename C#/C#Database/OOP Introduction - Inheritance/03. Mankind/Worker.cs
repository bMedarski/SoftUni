using System;
using System.Text;

public class Worker : Human
{
	private double weekSalary;
	private double hoursPerDay;

	public Worker(string firstName, string lastName, double weekSalry, double hoursPerDay) : base(firstName, lastName)
	{
		this.WeekSalary = weekSalry;
		this.HoursPerDay = hoursPerDay;
	}

	public double WeekSalary
	{
		get { return this.weekSalary; }
		set
		{
			if (value<=10)
			{
				throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
			}
			this.weekSalary = value;
		}
	}

	public double HoursPerDay
	{
		get { return this.hoursPerDay; }
		set
		{
			if (value<1||value>12)
			{
				throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
			}
			this.hoursPerDay = value;
		}
	}

	public double SalaryPerHour()
	{
		return this.WeekSalary / (5 * this.HoursPerDay);
	}

	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine($"First Name: {this.FirstName}");
		sb.AppendLine($"Last Name: {this.LastName}");
		sb.AppendLine($"Week Salary: {this.WeekSalary:F2}");
		sb.AppendLine($"Hours per day: {this.HoursPerDay:F2}");
		sb.AppendLine($"Salary per hour: {this.SalaryPerHour():F2}");

		return sb.ToString().Trim();
	}
}

