using System.Text;

public class EarthBender : Bender
{
	private double groundSaturation;

	public EarthBender(string name, int power,double groundSaturation) : base(name, power)
	{
		this.GroundSaturation = groundSaturation;
	}

	public double GroundSaturation
	{
		get => groundSaturation;
		private set => groundSaturation = value;
	}
	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Earth Bender: {this.Name}, Power: {this.Power}, Ground Saturation: {this.GroundSaturation:F2}");
		return sb.ToString().Trim();
	}

	public override double TotalPower()
	{
		return this.Power * this.GroundSaturation;
	}
}

