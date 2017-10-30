using System;

public class DateModifier
{
	public int Difference { get; set; }

	public DateModifier(string firstDate, string secondDate)
	{
		this.Difference = CalculateDifference(firstDate, secondDate);
	}

	private int CalculateDifference(string firstDate, string secondDate)
	{
		var first = DateTime.Parse(firstDate);
		var second = DateTime.Parse(secondDate);
		var result = Math.Abs((first - second).Days);
		return result;
	}
}

