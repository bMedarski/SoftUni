using System.Text;

public abstract class SpecialisedSoldier: Private,ISpecialisedSoldier
{
	private Corps corps;

	public SpecialisedSoldier(int id, string firstName, string lastName, double salary,Corps corps) 
		: base(id, firstName, lastName, salary)
	{
		this.Corps = corps;
	}

	public Corps Corps
	{
		get { return this.corps; }
		private set { this.corps = value; }
	}

	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine(base.ToString());
		sb.AppendLine($"Corps: {this.Corps}");
		return sb.ToString().Trim();
	}
}

