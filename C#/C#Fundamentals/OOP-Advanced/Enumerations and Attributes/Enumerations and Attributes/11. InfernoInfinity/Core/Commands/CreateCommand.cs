using System;
using System.Collections.Generic;

public class CreateCommand : ICommand
{
	private IWeaponsFactory weaponsFactory;
	private IList<string> args;

	public CreateCommand(IWeaponsFactory weaponsFactory,IList<string> args)
	{
		this.weaponsFactory = weaponsFactory;
		this.args = new List<string>(args);
	}

	public void Execute()
	{
		this.weaponsFactory.GetWeapon(this.args);
	}
}

