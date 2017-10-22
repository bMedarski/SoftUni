using System.Text;

public class FireBender : Bender
{
	private double heatAggression;
	public FireBender(string name, int power,double heatAggression) : base(name, power)
	{
		this.HeatAggression = heatAggression;
	}

	public double HeatAggression
	{
		get => heatAggression;
		private set => heatAggression = value;
	}
	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Fire Bender: {this.Name}, Power: {this.Power}, Heat Aggression: {this.HeatAggression:F2}");
		return sb.ToString().Trim();
	}

	public override double TotalPower()
	{
		return this.Power * this.HeatAggression;
	}
}

