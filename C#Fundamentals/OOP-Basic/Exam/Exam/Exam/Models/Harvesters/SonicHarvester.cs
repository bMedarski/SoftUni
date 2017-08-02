using System.Text;

public class SonicHarvester : Harvester
{
	private int sonicFactor;

	public SonicHarvester(string id, double oreOutput, double energyRequirement,int sonicFactor)
		: base(id, oreOutput, energyRequirement)
	{
		this.EnergyRequirement = energyRequirement;
		this.EnergyRequirement /= sonicFactor;
	}
	//private int SonicFactor
	//{
	//	get { return this.sonicFactor; }
	//	set { this.sonicFactor = value; }
	//}
	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine($"Sonic Harvester - {this.Id}");
		sb.AppendLine($"Ore Output: {this.OreOutput}");
		sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
		return sb.ToString().Trim();
	}

}

