using System;
using System.Text;

public abstract class Harvester:Worker
{
	private string id;
	private double oreOutput;
	private double energy;

	protected Harvester(string id, double oreOutput, double energy) : base(id)
	{
		this.Id = id;
		this.OreOutput = oreOutput;
		this.EnergyRequirement = energy;
	}

	public double OreOutput
	{
		get { return this.oreOutput; }
		protected set
		{
			if (value <= 0)
			{
				throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
			}
			this.oreOutput = value;
		}
	}

	public double EnergyRequirement
	{
		get { return this.energy; }
		protected set
		{
			if (value <= 0 || value >= 20000)
			{
				throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirement");
			}
			this.energy = value;
		}
	}

	public override string ToString()
	{
		var sb = new StringBuilder();
		return sb.ToString().Trim();
	}
}

