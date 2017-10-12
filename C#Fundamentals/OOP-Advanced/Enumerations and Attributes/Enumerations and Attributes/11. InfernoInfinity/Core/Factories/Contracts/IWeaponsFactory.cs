using System.Collections.Generic;

public interface IWeaponsFactory
{
	IWeapon GetWeapon(IList<string> args);
	IList<IWeapon> CreatedWeapons { get; }
}

