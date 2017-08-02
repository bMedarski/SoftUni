using System.Collections.Generic;
using System.Globalization;

public class HarvesterFactory
{

	//public Harvester CreateSonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
	//{
	//	return new SonicHarvester(id,oreOutput,energyRequirement,sonicFactor);
	//}

	//public Harvester CreateHammerHarvester(string id, double oreOutput, double energyRequirement)
	//{
	//	return new HammerHarvester(id, oreOutput, energyRequirement);
	//}
	//public Harvester Get(int id)
	//{
	//	switch (id)
	//	{
	//		case 0:
	//			return new Manager();
	//		case 1:
	//		case 2:
	//			return new Clerk();
	//		case 3:
	//		default:
	//			return new Programmer();
	//	}
	//}
//	if (arguments[0] == "Solar")
//	{
//		var id = arguments[1];
//		var oreOutput = double.Parse(arguments[2], CultureInfo.InvariantCulture);
//		//var provider = this.providerFactory.CreateSolarProvider(id, oreOutput);
//		Provider provider = new SolarProvider(id, oreOutput);
//		this.providers.Add(provider);
//		return $"Successfully registered Solar Provider - {id}";
//	}
//	else
//	{
//		var id = arguments[1];
//		var oreOutput = double.Parse(arguments[2], CultureInfo.InvariantCulture);
////var provider = this.providerFactory.CreatePressureProvider(id, oreOutput);
//		Provider provider = new PressureProvider(id, oreOutput);
//		this.providers.Add(provider);
//		return $"Successfully registered Pressure Provider - {id}";
//	}
	public Harvester Create(List<string> args)
	{
		if (args[0] == "Solar")
		{
			var id = args[1];
			var oreOutput = double.Parse(args[2], CultureInfo.InvariantCulture);
			var energy = double.Parse(args[3], CultureInfo.InvariantCulture);
			var sonik = int.Parse(args[4]);
			Harvester provider = new SonicHarvester(id, oreOutput,energy,sonik);
			return provider;
		}
		else
		{
			var id = args[1];
			var oreOutput = double.Parse(args[2], CultureInfo.InvariantCulture);
			var energy = double.Parse(args[3], CultureInfo.InvariantCulture);
			Harvester provider = new HammerHarvester(id, oreOutput, energy);
			return provider;
		}
	}
}

