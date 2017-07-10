using Exam.Contracts;
using Exam.Models;
using Exam.Models.Races;

namespace Exam.Core.Factory
{
    public class RaceFactory : IRaceFactory
    {
        private static IRaceFactory raceFactoryInstance = new RaceFactory();

        private RaceFactory()
        {

        }

        public static IRaceFactory RaceFactoryInstance
        {
            get { return raceFactoryInstance; }
        }

        public void CreateRace(int id, string type, int length, string route, int prizePool, int optional)
        {           
            if (type == "Casual")
            {
                IRace race = new CasualRace(length, route, prizePool);
                Data.races.Add(id, race);
            }
            else if (type == "Drag")
            {
                IRace race = new DragRace(length, route, prizePool);
                Data.races.Add(id, race);
                
            }
            else if (type == "Drift")
            {
                IRace race = new DriftRace(length, route, prizePool);
                Data.races.Add(id, race);               
            }
            else if (type == "TimeLimit")
            {

                IRace race = new TimeLimitRace(length, route, prizePool,optional);
                Data.races.Add(id, race);
            }
            else if (type == "Circuit")
            {
                IRace race = new CircuitRace(length, route, prizePool,optional);
                Data.races.Add(id, race);
            }
        }
    }
}
