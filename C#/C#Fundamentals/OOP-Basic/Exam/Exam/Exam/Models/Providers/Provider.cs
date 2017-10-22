using System;
using System.Text;

public abstract class Provider:Worker
{
	private string id;
	private double energy;

	protected Provider(string id, double energy) : base(id)
	{
		this.Id = id;
		this.EnergyOutput = energy;
	}

	public double EnergyOutput
	{
		get
		{
			return this.energy;
		}
		protected set
		{
			if (value <= 0 || value >= 10000)
			{
				throw new ArgumentException($"Provider is not registered, because of it's EnergyOutput");
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
