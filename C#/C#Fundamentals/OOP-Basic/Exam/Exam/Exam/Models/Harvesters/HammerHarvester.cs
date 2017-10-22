using System.Text;

public class HammerHarvester : Harvester
{
	public HammerHarvester(string id, double oreOutput, double energyRequirement)
		: base(id, oreOutput, energyRequirement)
	{
		this.EnergyRequirement = energyRequirement*Constants.HAMMER_HARVESTER_ENERGY_INCREASE;
		this.OreOutput = oreOutput*Constants.HAMMER_HARVESTER_ORE_OUTPUT_INCREASE;
	}
	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine($"Hammer Harvester - {this.Id}");
		sb.AppendLine($"Ore Output: {this.OreOutput}");
		sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
		return sb.ToString().Trim();
	}
}

