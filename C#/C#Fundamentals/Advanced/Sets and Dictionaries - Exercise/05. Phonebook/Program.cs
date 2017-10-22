namespace _05.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var phonebook = new Dictionary<string, string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "search")
                {
                    break;
                }

                var splitedInput = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = splitedInput[0];
                var number = splitedInput[1];

                if (phonebook.ContainsKey(name))
                {
                    phonebook[name] = number;
                }
                else
                {
                    phonebook.Add(name, number);
                }
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }

                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
            }
        }
    }
}