using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class InputReader
    {
        private const string endCommand = "quit";
        public static void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}" + "> ");
            string input = Console.ReadLine().Trim();

            while (input != endCommand)
            {
                CommandInterpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}" + "> ");
                input = Console.ReadLine().Trim();
            }
        }
    }
}
