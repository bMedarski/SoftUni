using System;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
	private string facultyNumber;

	public Student(string firstName, string lastName,string facultyNumber):base(firstName,lastName)
	{
		this.FacultyNumber = facultyNumber;
	}
	public string FacultyNumber
	{
		get { return this.facultyNumber; }
		set
		{
			if (!IsValidFacultyNumber(value))
			{
				throw new ArgumentException("Invalid faculty number!");
			}

			this.facultyNumber = value;
		}
	}

	private bool IsValidFacultyNumber(string value)
	{
		bool isValid = true;
		string pattern = @"^([0-9a-zA-Z]{5,10})$";
		var rgx = new Regex(pattern);

		var match = rgx.Match(value);
		if (!match.Success)
		{
			isValid = false;
		}

		return isValid;
	}

	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine($"First Name: {this.FirstName}");
		sb.AppendLine($"Last Name: {this.LastName}");
		sb.AppendLine($"Faculty number: {this.FacultyNumber}");

		return sb.ToString();
	}
}

