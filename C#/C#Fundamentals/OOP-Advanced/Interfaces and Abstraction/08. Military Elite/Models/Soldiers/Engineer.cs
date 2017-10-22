using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier,IEngineer
{
	private IList<IRepair> repairs;

	public Engineer(int id, string firstName, string lastName, double salary, Corps corps)
	: base(id, firstName, lastName, salary, corps)
	{
		this.repairs = new List<IRepair>();
	}

	public void AddRepair(IRepair repair)
	{
		this.repairs.Add(repair);
	}
	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine(base.ToString());
		sb.AppendLine($"Repairs:");
		foreach (var repair in repairs)
		{
			sb.AppendLine($"  {repair}");
		}
		return sb.ToString().Trim();
	}
}

