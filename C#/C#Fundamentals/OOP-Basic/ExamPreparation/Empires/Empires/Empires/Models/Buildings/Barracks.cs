using System.Text;

public class Barracks : Building
{
	public Barracks()
	{
		base.Resource = new Resource(ResourceType.Steel, 0);
		base.ResourceBuldCounter = Constants.STEEL_TURNS_TO_PRODUCE;
		base.UnitBuildCounter = Constants.SWORDSMAN_TURNS_TO_BUILD;
	}

	public override void Turn()
	{
		base.TotalCount++;
		this.ResourceBuldCounter--;
		if (this.ResourceBuldCounter==0)
		{
			this.Resource.Quantity += Constants.STEEL_AMMOUNT_FOR_CYCLE;
			this.ResourceBuldCounter = Constants.STEEL_TURNS_TO_PRODUCE;
		}
		this.UnitBuildCounter--;
		if (this.UnitBuildCounter==0)
		{
			var unit = this.UnitFactory.CreateSwordsman();
			GameManager.AddUnit(unit);
			this.UnitBuildCounter = Constants.SWORDSMAN_TURNS_TO_BUILD;
		}
	}
	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"--{this.GetType().Name}: {this.TotalCount} turns ({this.UnitBuildCounter} turns until Swordsman, {this.ResourceBuldCounter} turns until {this.Resource.Type})");
		return sb.ToString().Trim();
	}
}

