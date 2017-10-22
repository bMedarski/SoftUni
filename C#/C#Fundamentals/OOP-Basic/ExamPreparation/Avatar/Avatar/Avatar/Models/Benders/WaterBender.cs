using System.Text;

public class WaterBender : Bender
{

	private double waterClarity;

	public WaterBender(string name, int power, double waterClarity) : base(name, power)
	{
		this.WaterClarity = waterClarity;
	}

	public double WaterClarity
	{
		get => waterClarity;
		private set => waterClarity = value;
	}
	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Water Bender: {this.Name}, Power: {this.Power}, Water Clarity: {this.WaterClarity:F2}");
		return sb.ToString().Trim();
	}
	public override double TotalPower()
	{
		return this.Power * this.WaterClarity;
	}
}

