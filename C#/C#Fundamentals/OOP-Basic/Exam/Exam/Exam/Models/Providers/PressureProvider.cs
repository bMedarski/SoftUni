using System.Text;

public class PressureProvider:Provider
{
	public PressureProvider(string id, double energyOutput) 
		: base(id, energyOutput)
	{
		this.EnergyOutput = energyOutput * Constants.PRESSURE_PROVIDER_ENERGY_INCREASE;
	}
	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine($"Pressure Provider - {this.Id}");
		sb.AppendLine($"Energy Output: {this.EnergyOutput}");
		return sb.ToString().Trim();
	}
}

