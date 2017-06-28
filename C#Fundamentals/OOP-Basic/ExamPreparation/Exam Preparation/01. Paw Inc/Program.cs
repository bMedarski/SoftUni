using System;

namespace _01.Paw_Inc
{
    class Program
    {
        static void Main()
        {
            var commandParser = new CommandParser();
            var writer = new Writer();

            while (true)
            {
                var command = Console.ReadLine();
                if (command== "Paw Paw Pawah")
                {
                    break;
                }
                commandParser.ProcessCommand(command);
            }
            writer.Status();
            
        }
    }
}
