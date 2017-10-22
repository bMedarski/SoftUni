public class Sword:Weapon
{

	public Sword(string name, Rarity rarity) : base(name, rarity)
	{
		this.Damage = new Damage(4, 6);
		this.Stats = new Stats(0, 0, 0);
		this.AddDamageForRarity();
	}
}

