using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Roli_The_Coder
{
    class Program
    {
        static void Main(string[] args)
        {

            //Dictionary<int, string> eventsOrder = new Dictionary<int, string>();
            //Dictionary<string, string> eventsList = new Dictionary<string, string>();
            List<Events> eventList = new List<Events>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Time for Code")
                {
                    break;
                }
                string[] splitInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                addEvent(eventList, splitInput);
            }
            foreach (var item in eventList)
            {
                item.listOfParticipions.Sort();
            }
            foreach (var item in eventList.OrderBy(x=>x.Name).OrderByDescending(item => item.listOfParticipions.Count()))
            {
                Console.WriteLine($"{item.Name} - {item.listOfParticipions.Count}");
                var list = item.listOfParticipions;
                foreach (var p in list)
                {
                    Console.WriteLine(p);
                }
            }
        }

        //private static void addEvent(Dictionary<int, string> eventsOrder, Dictionary<string, string> eventsList, string[] splitInput)

        private static void addEvent(List<Events> eventList, string[] splitInput)
        {
            int id = int.Parse(splitInput[0]);
            string eventName = splitInput[1];
            List<string> participions = new List<string>();
            for (int i = 2; i < splitInput.Length; i++)
            {
                participions.Add(splitInput[i]);
            }
            //Console.WriteLine(string.Join(">", participions));
            if (eventName.Substring(0, 1) != "#")
            {
                return;
            }
            eventName = splitInput[1].Substring(1);
            Events newEvent = new Events();
            newEvent.Id = id;
            newEvent.Name = eventName;
            newEvent.listOfParticipions = new List<string>();
            bool exist = false;
            foreach (var item in eventList)
            {
                if (item.Id==newEvent.Id&&item.Name!=newEvent.Name)
                {
                    return;
                }
                else if (item.Id == newEvent.Id && item.Name == newEvent.Name)
                {
                    addPeople(participions, item);
                    //item.listOfParticipions.AddRange(participions);
                    //Console.WriteLine(string.Join(">", item.listOfParticipions));
                    exist = true;
                }
            }
            if (!exist)
            {
                newEvent.listOfParticipions.AddRange(participions);
                eventList.Add(newEvent);
            }
            //Console.WriteLine(string.Join(">", newEvent.listOfParticipions));
            //eventList.Add(newEvent);
        }

        private static void addPeople(List<string> participions, Events item)
        {
            for (int i = 0; i < participions.Count; i++)
            {
                if (!item.listOfParticipions.Contains(participions[i]))
                {
                    item.listOfParticipions.Add(participions[i]);
                }
            }           
        }

        //    int id = int.Parse(splitInput[0]);
        //        string eventName = splitInput[1];
        //        if (eventName.Substring(0, 1) != "#")
        //        {
        //            return;
        //        }
        //        if (!eventsOrder.ContainsKey(id))
        //        {
        //            eventsOrder.Add(id, eventName.Substring(1));
        //        }else
        //        {
        //            if (eventsOrder[id]!= eventName.Substring(1))
        //            {
        //                return;
        //            }
        //        }
        //        if (!eventsList.ContainsKey(eventName.Substring(1)))
        //        {

        //        }

        //    }

        //}
    }
        class Events
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<string> listOfParticipions { get; set; }
        }
    }

