using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;

public class GameManager
{

	private BuildingFactory buildingFactory;
	private List<Building> buildings;
	private static List<Unit> units = new List<Unit>();

	public GameManager()
	{
		this.buildingFactory = new BuildingFactory();
		this.buildings = new List<Building>();
	}

	public static void AddUnit(Unit unit)
	{
		units.Add(unit);
	}

	public void Build(string type)
	{
		if (type=="barracks")
		{
			var building = this.buildingFactory.BuildBarracks();
			this.buildings.Add(building);
		}
		else if (type == "archery")
		{
			var building = this.buildingFactory.BuildArchery();
			this.buildings.Add(building);
		}
	}

	public void Turn()
	{
		foreach (var building in this.buildings)
		{
			building.Turn();
		}
	}

	public string Status()
	{
		int gold = 0;
		int steel = 0;
		int archer = 0;
		int swordsman = 0;
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Treasury:");

		foreach (var building in this.buildings)
		{
			if (building.Resource.Type == ResourceType.Gold)
			{
				gold += building.Resource.Quantity;
			}
			else
			{
				steel += building.Resource.Quantity;
			}
		}
		sb.AppendLine($"--Gold: {gold}");
		sb.AppendLine($"--Steel: {steel}");
		sb.AppendLine($"Buildings:");
		if (this.buildings.Count == 0)
		{
			sb.AppendLine($"N/A");
		}
		else
		{
			foreach (var building in this.buildings)
			{
				sb.AppendLine(building.ToString());
			}
		}
		
		sb.AppendLine($"Units:");
		if (units.Count == 0)
		{
			sb.AppendLine($"N/A");
		}
		else
		{
			foreach (var unit in units)
			{
				if (unit.GetType().Name == "Archer")
				{
					archer++;
				}
				else
				{
					swordsman++;
				}
			}
		}
		if (units.Count!=0)
		{
			if (units.First().GetType().Name=="Archer")
		{
			sb.AppendLine($"--Archer: {archer}");
			sb.AppendLine($"--Swordsman: {swordsman}");
			}
			else
			{
				sb.AppendLine($"--Swordsman: {swordsman}");
				sb.AppendLine($"--Archer: {archer}");
			}
		}		
		return sb.ToString().Trim();
	}


}

