using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Phonebook_Upgrade
{
    class Program
    {
        static void Main(string[] args)
        {

            string command = "";
            string person = "";
            string phoneNumber = "";
            string personToFind = "";
            SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();


            while (command != "END")
            {
                string[] input = Console.ReadLine().Split().ToArray();
                command = input[0];

                if (command == "A")
                {
                    person = input[1];
                    phoneNumber = input[2];
                    phonebook[person] = phoneNumber;
                }
                else if (command == "S")
                {
                    personToFind = input[1];
                    if (phonebook.ContainsKey(personToFind))
                    {
                        Console.WriteLine($"{personToFind} -> {phonebook[personToFind]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {personToFind} does not exist.");
                    }
                }else if (command== "ListAll")
                {
                    foreach(var item in phonebook)
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value}");
                    }
                }

            }
        }
    }
}
