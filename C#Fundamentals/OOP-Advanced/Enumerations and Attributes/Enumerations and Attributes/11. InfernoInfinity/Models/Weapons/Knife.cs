public class Knife:Weapon
{

	public Knife(string name, Rarity rarity) : base(name, rarity)
	{
		this.Damage = new Damage(3, 4);
		this.Stats = new Stats(0, 0, 0);
		this.AddDamageForRarity();
	}
}

