using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
	private IList<ISoldier> privates;

	public LeutenantGeneral(int id, string firstName, string lastName, double salary) 
		: base(id, firstName, lastName, salary)
	{
		this.privates = new List<ISoldier>();
	}

	public void AddPrivate(ISoldier pr)
	{
		this.privates.Add(pr);
	}
	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine(base.ToString());
		sb.AppendLine($"Privates:");
		foreach (var pr in privates)
		{
			sb.AppendLine($"  {pr}");
		}
		return sb.ToString().Trim();
	}
}

