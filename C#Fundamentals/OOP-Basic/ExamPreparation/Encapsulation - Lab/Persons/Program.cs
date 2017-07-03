using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

    class Program
    {
        static void Main()
        {
        var team = new Team("MyTeam");
        var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    double.Parse(cmdArgs[3],CultureInfo.InvariantCulture));
                team.AddPlayer(person);
                persons.Add(person);
            
            }
            //var bonus = double.Parse(Console.ReadLine());
            //persons.ForEach(p => p.IncreaseSalary(bonus));
            //persons.ForEach(p => Console.WriteLine(p.ToString()));
            Console.WriteLine($"First team have {team.FirstTeam.Count} players");
            Console.WriteLine($"Reserve team have {team.ReserveTeam.Count} players");
    }
}
