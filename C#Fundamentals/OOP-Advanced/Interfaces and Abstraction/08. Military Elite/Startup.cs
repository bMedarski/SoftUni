using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
	{
		IList<ISoldier> soldiers = new List<ISoldier>();

		while (true)
		{
			var input = Console.ReadLine().Split(' ').ToArray();
			if (input[0] == "End")
			{
				break;
			}
			int id = int.Parse(input[1]);
			string firstName = input[2];
			string secondName = input[3];

			switch (input[0])
			{
				case "Private":					
					IPrivate privater = new Private(id, firstName, secondName, double.Parse(input[4]));
					soldiers.Add(privater);
					break;
				case "Commando":
					Corps corp;
					try
					{
						corp = (Corps)Enum.Parse(typeof(Corps), input[5]);
						ICommando commando = new Commando(id, firstName, secondName, double.Parse(input[4]), corp);
						if (input.Length > 6)
						{						
							for (int i = 6; i < input.Length; i += 2)
							{								
								try
								{
									MissionState missionstate;
									missionstate = (MissionState) Enum.Parse(typeof(MissionState), input[i+1]);									
									IMission mission = new Mission(missionstate, input[i]);
									commando.AddMission(mission);
								}
								catch (Exception e)
								{									
								}								
							}
						}
						soldiers.Add(commando);
					break;
					}
					catch (Exception ex)
					{
						break;
					}					
				case "LeutenantGeneral":
					ILeutenantGeneral leutenantGeneral = new LeutenantGeneral(id, firstName, secondName, double.Parse(input[4]));
					for (int i = 5; i < input.Length; i++)
					{
						ISoldier pr = soldiers.First(x => x.Id == int.Parse(input[i]));
						leutenantGeneral.AddPrivate(pr);
					}
					soldiers.Add(leutenantGeneral);
					break;
				case "Engineer":
					Corps corps;
					try
					{
						corps = (Corps)Enum.Parse(typeof(Corps), input[5]);
						IEngineer engineer = new Engineer(id, firstName, secondName, double.Parse(input[4]), corps);
						if (input.Length>6)
						{
							
							for (int i = 6; i < input.Length; i+=2)
							{
								IRepair repair = new Repair(input[i],int.Parse(input[i+1]));
								engineer.AddRepair(repair);

							}
						}
						soldiers.Add(engineer);
						break;
					}
					catch (Exception ex)
					{
						//Console.WriteLine(ex.Message);
						break;
					}
				case "Spy":
					ISpy spy = new Spy(id, firstName, secondName, int.Parse(input[4]));
					soldiers.Add(spy);
					break;
			}
		}
		foreach (var soldier in soldiers)
		{
			Console.WriteLine(soldier);
		}
	}
}
