using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _06.FootballTeamGen
{
    class Program
    {
        static void Main()
        {
            var teams = new List<Team>();
            var players = new List<Player>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input=="END")
                {
                    break;
                }
                var split = input.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (split[0] == "Team")
                {
                    try
                    {
                        var team = new Team(split[1]);
                        teams.Add(team);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);                      
                    }                   
                }
                else if(split[0] == "Add")
                {
                    if (teams.Any(x=>x.Name==split[1]))
                    {
                        try
                        {
                            var player = new Player(split[2],int.Parse(split[3]), int.Parse(split[4]), int.Parse(split[5]), int.Parse(split[6]), int.Parse(split[7]));
                            teams.Find(x=>x.Name==split[1]).AddPlayer(player);
                            players.Add(player);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {split[1]} does not exist.");
                    }
                }
                else if (split[0] == "Remove")
                {
                    if (teams.Any(x => x.Name == split[1]))
                    {
                        if (players.Any(x => x.Name == split[2]))
                        {
                            var player = players.Find(x => x.Name == split[2]);
                            teams.FirstOrDefault(x => x.Name == split[1]).RemovePlayer(player);
                            players.Remove(player);
                        }
                        else
                        {
                            Console.WriteLine($"Player {split[2]} is not in {split[1]} team.");
                        }
                        try
                        {                                                     
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {split[1]} does not exist.");
                    }
                }
                else if (split[0] == "Rating")
                {
                    if (teams.Any(x => x.Name == split[1]))
                    {
                        try
                        {
                            Console.WriteLine($"{split[1]} - {teams.Find(x => x.Name == split[1]).OverallTeamRating()}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {split[1]} does not exist.");
                    }
                }
            }
        }
    }
}
