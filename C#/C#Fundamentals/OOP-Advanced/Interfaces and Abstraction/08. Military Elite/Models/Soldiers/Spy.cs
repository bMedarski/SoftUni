using System.Text;

public class Spy : Soldier,ISpy
{
	private int code;

	public Spy(int id, string firstName, string lastName,int code) 
		: base(id, firstName, lastName)
	{
		this.Code = code;
	}

	public int Code
	{
		get { return this.code; }
		private set { this.code = value; }
	}

	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine(base.ToString());
		sb.AppendLine($"Code Number: {this.Code}");

		return sb.ToString().Trim();
	}
}

