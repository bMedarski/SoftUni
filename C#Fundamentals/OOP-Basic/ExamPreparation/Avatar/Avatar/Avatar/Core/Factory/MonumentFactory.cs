using System.Collections.Generic;

public class MonumentFactory
{
	public Monument CreateMonument(List<string> monumnetArgs)
	{
		string type = monumnetArgs[0];
		string name = monumnetArgs[1];
		int affinity = int.Parse(monumnetArgs[2]);


		switch (type)
		{
			case "Air":
				return new AirMonument(name, affinity);
			case "Fire":
				return new FireMonument(name, affinity);
			case "Earth":
				return new EarthMonument(name, affinity);
			case "Water":
				return new WaterMonument(name, affinity);
		}
		return null;
	}
}

