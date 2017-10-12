public class Stats:IStats
{
	private int strength;
	private int agility;
	private int vitality;

	public Stats(int strength, int agility, int vitality)
	{
		this.Strength = strength;
		this.Agility = agility;
		this.Vitality = vitality;
	}

	public int Strength
	{
		get => this.strength;
		set => this.strength = value;
	}

	public int Agility
	{
		get => this.agility;
		set => this.agility = value;
	}

	public int Vitality
	{
		get => this.vitality;
		set => this.vitality = value;
	}
	public static Stats operator +(Stats stats1, Stats stats2)
	{
		return new Stats(stats1.Strength+stats2.Strength,stats1.Agility+stats2.Agility,stats1.Vitality+stats2.Vitality);
	}

	public override string ToString()
	{
		return $"+{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
	}
}

