using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
	private Nation airNation;
	private Nation fireNation;
	private Nation waterNation;
	private Nation earthNation;
	private BenderFactory benderFactory;
	private MonumentFactory monumentFactory;
	private List<string> issuedWars;

	public NationsBuilder()
	{
		this.airNation = new Nation("Air");
		this.earthNation = new Nation("Earth");
		this.fireNation = new Nation("Fire");
		this.waterNation = new Nation("Water");
		this.benderFactory = new BenderFactory();
		this.monumentFactory = new MonumentFactory();
		this.issuedWars = new List<string>();
	}

	public void AssignBender(List<string> benderArgs)
	{
		Bender bender = this.benderFactory.CreateBender(benderArgs);
		switch (benderArgs[0])
		{
			case "Air":
				airNation.AddBender(bender);
				break;
			case "Fire":
				fireNation.AddBender(bender);
				break;
			case "Earth":
				earthNation.AddBender(bender);
				break;
			case "Water":
				waterNation.AddBender(bender);
				break;
		}
	}
	public void AssignMonument(List<string> monumentArgs)
	{
		Monument monument = this.monumentFactory.CreateMonument(monumentArgs);

		switch (monumentArgs[0])
		{
			case "Air":
				airNation.AddMonument(monument);
				break;
			case "Fire":
				fireNation.AddMonument(monument);
				break;
			case "Earth":
				earthNation.AddMonument(monument);
				break;
			case "Water":
				waterNation.AddMonument(monument);
				break;
		}
	}

	public string GetStatus(string nationsType)
	{
		switch (nationsType)
		{
			case "Air":
				return this.airNation.ToString();				
			case "Fire":
				return this.fireNation.ToString();
			case "Earth":
				return this.earthNation.ToString();
			case "Water":
				return this.waterNation.ToString();
		}
		return null;

	}

	public void IssueWar(string nationsType)
	{
		this.issuedWars.Add(nationsType);

		List<Nation> nations = new List<Nation>();
		nations.Add(airNation);
		nations.Add(waterNation);
		nations.Add(fireNation);
		nations.Add(earthNation);
		nations = nations.OrderByDescending(x => x.GetNationPower()).ToList();
		for (int i = 1; i < 4; i++)
		{
			nations[i].DefeatNation();
		}
	}
	public string GetWarsRecord()
	{
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < issuedWars.Count; i++)
		{
			sb.AppendLine($"War {i + 1} issued by {this.issuedWars[i]}");
		}

		return sb.ToString().Trim();
	}

}

