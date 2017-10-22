using System;

namespace _01.Paw_Inc
{
    class Program
    {
        static void Main()
        {
            var writer = new Writer();
            var commandParser = new CommandParser(writer);
            var animal = new Cat("Pesho",0,4);

            //while (true)
            //{
            //    var command = Console.ReadLine();
            //    if (command== "Paw Paw Pawah")
            //    {
            //        break;
            //    }
            //    commandParser.ProcessCommand(command);
            //}
            //commandParser.Status();
            
        }
    }
}
