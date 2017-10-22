using System.Collections.Generic;
using System.Text;

public class Nation
{
	private string name;
	private List<Monument> monumets;
	private List<Bender> benders;

	public Nation(string name)
	{
		this.Name = name;
		this.benders = new List<Bender>();
		this.monumets= new List<Monument>();
	}

	public string Name
	{
		get => name;
		private set => name = value;
	}

	public void AddBender(Bender bender)
	{
		this.benders.Add(bender);
	}

	public void AddMonument(Monument monument)
	{
		this.monumets.Add(monument);
	}

	public double GetNationPower()
	{
		double power = 0;
		int totalAffinity = 0;
		foreach (var bender in this.benders)
		{
			power += bender.TotalPower();
		}
		foreach (var monument in this.monumets)
		{
			totalAffinity += monument.Affinity();
		}
		power += power / 100 * totalAffinity;
		return power;
	}

	public void DefeatNation()
	{
		this.benders.Clear();
		this.monumets.Clear();
	}
	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"{this.name} Nation");
		if (this.benders.Count == 0)
		{
			sb.AppendLine($"Benders: None");
		}
		else
		{
			sb.AppendLine($"Benders:");
			foreach (var bender in this.benders)
			{
				sb.AppendLine($"###{bender}");
			}
		}

		if (this.monumets.Count == 0)
		{
			sb.AppendLine($"Monuments: None");
		}
		else
		{
			sb.AppendLine($"Monuments:");
			foreach (var monument in this.monumets)
			{
				sb.AppendLine($"###{monument}");
			}
		}

		return sb.ToString().Trim();
	}
}

