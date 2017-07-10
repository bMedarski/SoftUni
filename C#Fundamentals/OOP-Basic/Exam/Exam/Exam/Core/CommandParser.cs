using Exam.Contracts;

namespace Exam.Core
{
    public class CommandParser :IParser
    {
        public string ParseCommand(string fullCommand)
        {
            var command = fullCommand.Split(' ')[0];
            
            return command;
        }
    }
}
