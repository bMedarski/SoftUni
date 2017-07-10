using System;
using System.Linq;
using Exam.Contracts;
using Exam.Models;
using Exam.Providers;

namespace Exam.Core
{
    public class Engine : IEngine
    {
        private static readonly IEngine instanceHolder = new Engine();
        private ICarManager carManager = CarManager.CarManagerInstance;

        private Engine()
        {
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();           
        }
        private IReader Reader { get; set; }
        private IWriter Writer { get; set; }      

        public static IEngine Instance
        {
            get
            {
                return instanceHolder;
            }
        }
       
        public void Start()
        {
            while (true)
            {                
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString.ToLower() == Constants.endOfProgram.ToLower())
                    {                       
                        break;
                    }
                this.ProcessCommand(commandAsString);
            }
        }
        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");    //Constants
            }
            string[] commandAndParams = commandAsString.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int optional = 0;
            string command = commandAndParams[0];
            int id = int.Parse(commandAndParams[1]);
            switch (command.ToLower())
            {
                case "register":
                    carManager.Register(id, commandAndParams[2], commandAndParams[3], commandAndParams[4]
                        , int.Parse(commandAndParams[5]), int.Parse(commandAndParams[6]), int.Parse(commandAndParams[7])
                        , int.Parse(commandAndParams[8]),int.Parse(commandAndParams[9]));
                    break;
                case "check":
                    carManager.Check(id);
                    break;
                case "open":
                    
                    if (commandAndParams.Length<7)
                    {
                         optional = 0;
                    }
                    else
                    {
                         optional = int.Parse(commandAndParams[6]);
                    }
                    carManager.Open(id, commandAndParams[2], int.Parse(commandAndParams[3]), commandAndParams[4], int.Parse(commandAndParams[5]),optional);
                    break;
                case "participate":                    
                    carManager.Participate(id,int.Parse(commandAndParams[2]));
                    break;
                case "start":
                    carManager.Start(id);
                    break;
                case "park":
                    carManager.Park(id);
                    break;
                case "unpark":
                    carManager.Unpark(id);
                    break;
                case "tune":
                    carManager.Tune(id, commandAndParams[2]);
                    break;
            }

        }
    }
}
