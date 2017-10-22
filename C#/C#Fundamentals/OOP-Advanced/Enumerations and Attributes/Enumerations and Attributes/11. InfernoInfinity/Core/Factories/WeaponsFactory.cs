using System;
using System.Collections.Generic;

public class WeaponsFactory:IWeaponsFactory
{
	private IList<IWeapon> createdWeapons;

	public WeaponsFactory()
	{
		this.createdWeapons = new List<IWeapon>();
	}

	public IList<IWeapon> CreatedWeapons
	{
		get { return  this.createdWeapons; }
	}
	public IWeapon GetWeapon(IList<string> args)
	{
		var weaponArgs = args[0].Split(' ');
		
		IWeapon weapon;
		Enum.TryParse(weaponArgs[0], out Rarity rarity);
		switch (weaponArgs[1])
		{
			case "Axe":
				weapon = new Axe(args[1],rarity);
				this.createdWeapons.Add(weapon);
				return weapon;
			case "Sword":
				weapon = new Sword(args[1], rarity);
				this.createdWeapons.Add(weapon);
				return weapon;
			case "Knife":
				weapon = new Knife(args[1], rarity);
				this.createdWeapons.Add(weapon);
				return weapon;
			default:
				return null;
		}
	}
}

