
using System.Text;

public class AirBender : Bender
{
	private double aerialIntegirty;

	public AirBender(string name, int power, double aerialIntegirty)
	: base(name, power)
	{
		this.AerialIntegirty = aerialIntegirty;
	}

	public double AerialIntegirty
	{
		get => aerialIntegirty;
		private set => aerialIntegirty = value;
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();	
		sb.AppendLine($"Air Bender: {this.Name}, Power: {this.Power}, Aerial Integrity: {this.AerialIntegirty:F2}");
		return sb.ToString().Trim();
	}

	public override double TotalPower()
	{
		return this.Power * this.AerialIntegirty;
	}
}

