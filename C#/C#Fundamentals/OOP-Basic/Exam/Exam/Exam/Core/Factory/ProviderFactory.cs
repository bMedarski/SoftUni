using System.Collections.Generic;
using System.Globalization;

public class ProviderFactory
{

	//public Provider CreatePressureProvider(string id, double energyOutput)
	//{
	//	return new PressureProvider(id,energyOutput);
	//}

	//public Provider CreateSolarProvider(string id, double energyOutput)
	//{
	//	return new SolarProvider(id,energyOutput);
	//}
	public Provider Create(List<string> args)
	{
		if (args[0] == "Solar")
		{
			var id = args[1];
			var oreOutput = double.Parse(args[2], CultureInfo.InvariantCulture);
			Provider provider = new SolarProvider(id, oreOutput);
			return provider;
		}
		else
		{
			var id = args[1];
			var oreOutput = double.Parse(args[2], CultureInfo.InvariantCulture);
			Provider provider = new PressureProvider(id, oreOutput);
			return provider;
		}
	}
}

