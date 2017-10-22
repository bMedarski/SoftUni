using System.Collections.Generic;

public class BenderFactory
{

	public Bender CreateBender(List<string> benderArgs)
	{
		string type = benderArgs[0];
		string name = benderArgs[1];
		int power = int.Parse(benderArgs[2]);
		double secondParam = double.Parse(benderArgs[3]);

		switch (type)
		{
			case "Air":
				return new AirBender(name,power,secondParam);
			case "Fire":
				return new FireBender(name, power, secondParam);
			case "Earth":
				return new EarthBender(name, power, secondParam);
			case "Water":
				return new WaterBender(name, power, secondParam);
		}
		return null;
	}
}

