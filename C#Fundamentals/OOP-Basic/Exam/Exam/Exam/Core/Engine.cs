using System;
using System.Text;
using Exam.Contracts;
using Exam.Providers;

namespace Exam.Core
{
    public class Engine : IEngine
    {
        private static readonly IEngine instanceHolder = new Engine();
        private const string TerminationCommand = "";   //In constatns
        private const string NullProvidersExceptionMessage = "cannot be null.";//In constatns

        private Engine()
        {
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();
            this.Parser = new CommandParser();
        }

        public static IEngine Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public IReader Reader { get; set; }
        public IWriter Writer { get; set; }
        public IParser Parser { get; set; }

        public void Start()
        {
            while (true)
            {                
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
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

            //var command = this.Parser.ParseCommand(commandAsString);
            //var parameters = this.Parser.ParseParameters(commandAsString);

            //var executionResult = command.Execute(parameters);            
        }
    }
}
