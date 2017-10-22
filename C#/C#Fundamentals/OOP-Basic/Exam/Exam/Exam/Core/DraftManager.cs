using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class DraftManager
{
	private HarvesterFactory harvesterFactory;
	private ProviderFactory providerFactory;
	private List<Harvester> harvesters;
	private List<Provider> providers;
	private double totalEnergyStored;
	private double totalMinedOre;
	private string currentMode = "Full";


	public DraftManager()
	{
		this.harvesterFactory = new HarvesterFactory();
		this.providerFactory = new ProviderFactory();
		this.harvesters = new List<Harvester>();
		this.providers = new List<Provider>();
	}

	public string RegisterHarvester(List<string> arguments)
	{
		if (arguments[0] == "Sonic")
		{
			var id = arguments[1];
			var oreOutput = double.Parse(arguments[2], CultureInfo.InvariantCulture);
			var energyRequirement = double.Parse(arguments[3], CultureInfo.InvariantCulture);
			var sonicFactor = int.Parse(arguments[4]);
			//var harvester = this.harvesterFactory.CreateSonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
			Harvester harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
			this.harvesters.Add(harvester);
			return $"Successfully registered Sonic Harvester - {id}";
		}
		else
		{
			var id = arguments[1];
			var oreOutput = double.Parse(arguments[2], CultureInfo.InvariantCulture);
			var energyRequirement = double.Parse(arguments[3], CultureInfo.InvariantCulture);
			//var harvester = this.harvesterFactory.CreateHammerHarvester(id, oreOutput, energyRequirement);
			Harvester harvester = new HammerHarvester(id, oreOutput, energyRequirement);
			this.harvesters.Add(harvester);
			return $"Successfully registered Hammer Harvester - {id}";
		}

	}

	public string RegisterProvider(List<string> arguments)
	{
		if (arguments[0] == "Solar")
		{
			var id = arguments[1];
			var oreOutput = double.Parse(arguments[2], CultureInfo.InvariantCulture);
			//var provider = this.providerFactory.CreateSolarProvider(id, oreOutput);
			Provider provider = new SolarProvider(id, oreOutput);
			this.providers.Add(provider);
			return $"Successfully registered Solar Provider - {id}";
		}
		else
		{
			var id = arguments[1];
			var oreOutput = double.Parse(arguments[2], CultureInfo.InvariantCulture);
			//var provider = this.providerFactory.CreatePressureProvider(id, oreOutput);
			Provider provider = new PressureProvider(id, oreOutput);
			this.providers.Add(provider);
			return $"Successfully registered Pressure Provider - {id}";
		}
	}

	public string Day()
	{
		var sb = new StringBuilder();
		var totalProducedEnergy = this.providers.Sum(p => p.EnergyOutput);
		totalEnergyStored += totalProducedEnergy;
		double totalOreProduced = 0;
		if (currentMode == "Full")
		{
			var totalEnergyRequiredForHarvesters = this.harvesters.Sum(h => h.EnergyRequirement);
			if (totalEnergyRequiredForHarvesters <= totalEnergyStored)
			{
				totalOreProduced = this.harvesters.Sum(h => h.OreOutput);
				totalMinedOre += totalOreProduced;
				totalEnergyStored -= totalEnergyRequiredForHarvesters;
			}
		}
		else if (currentMode == "Half")
		{
			var totalEnergyRequiredForHarvesters = this.harvesters.Sum(h => h.EnergyRequirement);
			if (totalEnergyRequiredForHarvesters <= totalEnergyStored)
			{
				totalOreProduced = this.harvesters.Sum(h => h.OreOutput) * Constants.HALF_DAY_ORE_PRODUCTION;
				totalMinedOre += totalOreProduced;
				totalEnergyStored -= totalEnergyRequiredForHarvesters * Constants.HALF_DAY_CONSUMPTION;
			}
		}

		sb.AppendLine("A day has passed.");
		sb.AppendLine($"Energy Provided: {totalProducedEnergy}");
		sb.AppendLine($"Plumbus Ore Mined: {totalOreProduced}");
		return sb.ToString().Trim();
	}

	public string Mode(List<string> arguments)
	{
		var mode = arguments[0];
		this.currentMode = mode;
		return $"Successfully changed working mode to {currentMode} Mode";
	}

	public string Check(List<string> arguments)
	{
		var id = arguments[0];
		foreach (var harvester in harvesters)
		{
			if (harvester.Id == id)
			{
				return harvester.ToString();
			}
		}
		foreach (var provider in providers)
		{
			if (provider.Id == id)
			{
				return provider.ToString();
			}
		}
		return $"No element found with id - {id}";
	}

	public string ShutDown()
	{
		var sb = new StringBuilder();
		sb.AppendLine("System Shutdown");
		sb.AppendLine($"Total Energy Stored: {totalEnergyStored}");
		sb.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");
		return sb.ToString().Trim();
	}
}

