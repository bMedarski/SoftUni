using System.Collections.Generic;

public abstract class Weapon:IWeapon
{
	private string name;
	private Damage damage;
	private Stats stats;
	private Rarity rarity;
	protected List<IGem> gems;

	protected Weapon(string name,Rarity rarity)
	{
		this.Name = name;
		this.Rarity = rarity;
		this.gems = new List<IGem>();
	}

	public string Name
	{
		get => this.name;
		private set => this.name = value;
	}

	public Damage Damage
	{
		get => this.damage;
		protected set => this.damage = value;
	}

	public Stats Stats
	{
		get => this.stats;
		protected set => this.stats = value;
	}

	public Rarity Rarity
	{
		get => this.rarity;
		private set => this.rarity = value;
	}

	public IList<IGem> Gems
	{
		get { return this.gems; }
	}
	protected void AddDamageForRarity()
	{
		this.Damage.Min *= (int) this.Rarity;
		this.Damage.Max *= (int)this.Rarity;
	}

	public  void Calculate()
	{
		foreach (var gem in this.Gems)
		{
			if (gem.Type==GemType.Amethyst)
			{
				this.Stats.Strength += 2 + (int) gem.Size;
				this.Stats.Agility += 8 + (int)gem.Size;
				this.Stats.Vitality += 4 + (int)gem.Size;
			}
			else if (gem.Type == GemType.Emerald)
			{
				this.Stats.Strength += 1 + (int)gem.Size;
				this.Stats.Agility += 4 + (int)gem.Size;
				this.Stats.Vitality += 9 + (int)gem.Size;
			}
			else if (gem.Type == GemType.Ruby)
			{
				this.Stats.Strength += 7 + (int)gem.Size;
				this.Stats.Agility += 2 + (int)gem.Size;
				this.Stats.Vitality += 5 + (int)gem.Size;
			}
		}
	}
	
	public override string ToString()
	{
		return $"{this.Name}: {this.Damage}, {this.Stats}";
	}
}

