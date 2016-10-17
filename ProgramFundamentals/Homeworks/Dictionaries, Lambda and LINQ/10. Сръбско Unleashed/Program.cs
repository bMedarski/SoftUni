using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Сръбско_Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "",
                   singer = "",
                   venue = "";
            int ticketPrice = 0,
                ticketCount = 0;
            long totalPrice = 0;
            Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>>(); 
                      
            while (input!="End")
            {
                input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                if (isValid(input))
                {
                    singer = getSinger(input);
                    venue = getVenue(input);
                    ticketPrice = getPrice(input);
                    ticketCount = getCount(input);
                    addVenue(data, venue);
                    addSinger(data, venue, singer, ticketCount, ticketPrice);
                }               
            }
            foreach (var item in data)
            {
                Console.WriteLine(item.Key);
                var insideDict = item.Value.OrderByDescending(x => x.Value);
                foreach (var item2 in insideDict)
                {
                    Console.WriteLine($"#  {item2.Key} -> {item2.Value}");
                }
            }
        }

        private static void addSinger(Dictionary<string, Dictionary<string, long>> data, string venue, string singer, int ticketCount, int ticketPrice)
        {
            if (!data[venue].ContainsKey(singer))
            {
                data[venue].Add(singer, ticketPrice * ticketCount);
            }else
            {
                data[venue][singer] += ticketPrice * ticketCount;
            }
        }

        private static void addVenue(Dictionary<string, Dictionary<string, long>> data, string venue)
        {
            if (!data.ContainsKey(venue))
            {
                data.Add(venue,new Dictionary<string, long>());
            }
        }

        private static int getCount(string input)
        {
            char[] separetor = new char[] { '@' };
            List<string> splited = input.Split(separetor, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> splitedAgaig = splited[1].Split(' ').ToList();
            int count = int.Parse(splitedAgaig[splitedAgaig.Count - 1]);
            return count;
        }

        private static int getPrice(string input)
        {
            char[] separetor = new char[] { '@' };
            List<string> splited = input.Split(separetor, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> splitedAgaig = splited[1].Split(' ').ToList();
            int price = int.Parse(splitedAgaig[splitedAgaig.Count - 2]);
            return price;
        }
        private static bool isValid(string input)
        {
            char[] separetor = new char[] { '@' };
            List<string> splited = input.Split(separetor).ToList();
            List<string> splitedAgaig = splited[1].Split(' ').ToList();
            var array = splited[0].ToCharArray();
            int num;

            if ((array[array.Length-1]==' ')&&
                (int.TryParse(splitedAgaig[splitedAgaig.Count - 1], out num))&&
                (int.TryParse(splitedAgaig[splitedAgaig.Count - 2], out num)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static string getVenue(string input)
        {
            char[] separetor = new char[] { '@' };
            List<string> splited = input.Split(separetor, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> splitedAgaig = splited[1].Split(' ').ToList();
            splitedAgaig.RemoveAt(splitedAgaig.Count - 1);
            splitedAgaig.RemoveAt(splitedAgaig.Count - 1);
            string venue = string.Join(" ", splitedAgaig);
            return venue;
        }
        private static string getSinger(string input)
        {
            char[] separetor = new char[] {'@'};
            string[] splited = input.Split(separetor, StringSplitOptions.RemoveEmptyEntries).ToArray();
            return splited[0].Trim();
        }
    }
}
