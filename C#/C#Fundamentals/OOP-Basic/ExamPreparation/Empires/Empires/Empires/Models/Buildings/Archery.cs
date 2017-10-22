using System.Text;

public class Archery : Building
{
	public Archery()
	{
		base.Resource = new Resource(ResourceType.Gold, 0);
		base.ResourceBuldCounter = Constants.GOLD_TURNS_TO_PRODUCE;
		base.UnitBuildCounter = Constants.ARCHER_TURNS_TO_BUILD;
	}
	public override void Turn()
	{
		base.TotalCount++;
		this.ResourceBuldCounter--;
		if (this.ResourceBuldCounter == 0)
		{
			this.Resource.Quantity += Constants.GOLD_AMMOUNT_FOR_CYCLE;
			this.ResourceBuldCounter = Constants.GOLD_TURNS_TO_PRODUCE;
		}
		this.UnitBuildCounter--;
		if (this.UnitBuildCounter == 0)
		{
			var unit = this.UnitFactory.CreateArcher();
			GameManager.AddUnit(unit);
			this.UnitBuildCounter = Constants.ARCHER_TURNS_TO_BUILD;
		}
		//Console.WriteLine(this.Resource.Quantity);
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"--{this.GetType().Name}: {this.TotalCount} turns ({this.UnitBuildCounter} turns until Archer, {this.ResourceBuldCounter} turns until {this.Resource.Type})");
		return sb.ToString().Trim();
	}
}

