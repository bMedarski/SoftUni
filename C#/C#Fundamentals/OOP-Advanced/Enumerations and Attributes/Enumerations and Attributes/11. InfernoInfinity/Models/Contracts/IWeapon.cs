using System.Collections.Generic;

public interface IWeapon
{
	string Name { get; }

	string ToString();

	IList<IGem> Gems { get; }

	void Calculate();
}

