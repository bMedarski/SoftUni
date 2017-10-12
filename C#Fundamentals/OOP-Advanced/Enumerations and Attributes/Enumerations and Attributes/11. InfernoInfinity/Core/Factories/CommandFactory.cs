using System.Collections.Generic;

public class CommandFactory:ICommandFactory
{
	IWeaponsFactory weaponsFactory = new WeaponsFactory();
	IWriter  writer = new ConsoleWriter();
	private IList<IWeapon> weapons;

	public CommandFactory()
	{
		//this.createdWeapons = new List<IWeapon>();
	}
	public ICommand GetCommand(string command,IList<string> args)
	{
		switch (command)
		{
			case "Create":
				return new CreateCommand(this.weaponsFactory,args);
			case "Add":
				return new AddCommand(this.weaponsFactory, args);
			case "Remove":
				return new RemoveCommand(this.weaponsFactory, args);
			case "Print":
				return new PrintCommand(this.weaponsFactory, args, this.writer);
			default:
				return null;
		}
	}

}

