public class Axe:Weapon
{

	public Axe(string name, Rarity rarity) : base(name, rarity)
	{
		this.Damage = new Damage(5,10);
		this.Stats = new Stats(0,0,0);
		this.AddDamageForRarity();
	}
}

