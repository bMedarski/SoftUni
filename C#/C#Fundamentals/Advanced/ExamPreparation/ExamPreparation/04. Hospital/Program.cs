using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> doctors =
                new Dictionary<string, List<string>>();

            Dictionary<string, List<string>> departments =
                new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Output")
                {
                    break;
                }
                var splitInput = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                

                var department = splitInput[0];
                var doctor = splitInput[1] +" "+ splitInput[2];
                var patient = splitInput[3];
                if (!doctors.ContainsKey(doctor))
                {
                    var patiens = new List<string>();
                    patiens.Add(patient);
                    doctors.Add(doctor, patiens);
                }
                else
                {
                    doctors[doctor].Add(patient);
                }
                if (!departments.ContainsKey(department))
                {
                    var rooms = new List<string>();
                    rooms.Add(patient);
                    departments.Add(department, rooms);
                }
                else
                {
                    if (departments[department].Count<60)
                    {
                        departments[department].Add(patient);
                    }
                }                              
            }
            
            
            while (true)
            {
                var command = Console.ReadLine().Trim();
                if (command== "End")
                {
                    break;
                }
                if (departments.ContainsKey(command))
                {
                    var key = command;
                        foreach (var patient in departments[key])
                        {
                            Console.WriteLine($"{patient}");
                        }
                }
                else if (doctors.ContainsKey(command))
                {
                    var doctor = command;

                    foreach (var patient in doctors[doctor].OrderBy(x => x))
                    {
                        Console.WriteLine($"{patient}");
                    }
                }
                else
                {
                    var commandSplit = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var dep = commandSplit[0];
                   
                    var room = int.Parse(commandSplit[1]);
                    
                    var count = departments[dep].Count;
                    //Console.WriteLine(count);
                    var roomPatients = new List<string>();
                    var roomPatientss = new List<string>();

                    foreach (var patient in departments[dep])
                    {
                       roomPatients.Add(patient);
                    }
                    var skip = (room - 1) * 3;
                    //Console.WriteLine(skip);
                    var toTake = 0;

                    if (roomPatients.Count - skip > 3)
                    {
                        toTake = 3;
                    }
                    else
                    {
                        toTake = roomPatients.Count - skip;
                    }
                    //Console.WriteLine(toTake);
                    roomPatientss.AddRange(roomPatients.Skip(skip).Take(toTake));

                    foreach (var p in roomPatientss.OrderBy(x=>x))
                    {
                        Console.WriteLine(string.Join(" ",p));
                    }
                }
            }
        }       
    }
}
