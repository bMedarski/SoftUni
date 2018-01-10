using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main()
        {

            string[] participants = Console.ReadLine().Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Select(song => song.Trim()).ToArray();
            string[] songs = Console.ReadLine().Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Select(song => song.Trim()).ToArray();
                      
            SortedDictionary<string, SortedDictionary<string,int>> data = new SortedDictionary<string, SortedDictionary<string, int>>();

            while (true)
            {
                string[] performances = Console.ReadLine().Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Select(performance => performance.Trim()).ToArray();
                if (performances[0]=="dawn")
                {
                    break;
                }

                if (isValid(performances, participants, songs))
                {
                    addSinger(data, performances);
                    addSongs(data, performances);
                }
            }
            //myDict.Skip(1).Sum(x => x.Value);
            //var result = yourMainDict.OrderBy(x => x.Value.Sum(v => v.Value.Delivered + v.Value.Submitted + v.Value.Failed));
            var sortedData = data.OrderByDescending(i => i.Value.Sum(x=>x.Value));
            foreach (var item in sortedData)
            {
                //var insideDict = item.Value.OrderByDescending(y=>y.Count).OrderByDescending(x => x.Value);
                //Console.WriteLine($"{item.Key}: {item.Value.Count} awards");

                var keys = item.
                //item.Value.OrderByDescending(i=>i.Count());
                //var insideDict = item.Key.OrderBy(x=>x);
                Console.WriteLine($"{item.Key}: {item.Value.Count} awards");

                foreach (var item2 in keys)
                {

                    //Console.WriteLine($"{item.Key}: {item.Value.Count} awards");
                    Console.WriteLine($"--{item2.Key}");
                }
            }
            
            if (data.Count==0)
            {
                Console.WriteLine("No awards");
            }

            //Console.WriteLine(string.Join("*", songs));

        }

        private static void addSongs(SortedDictionary<string, SortedDictionary<string, int>> data, string[] performances)
        {
            string singer = performances[0];
            string song = performances[1];
            string award = performances[2];

            if (!data[singer].ContainsKey(award))
            {
                data[singer].Add(award,1);
            }else
            {
                data[singer][award]++;
            }
            //else
            //{
            //    data[venue][singer] += ticketPrice * ticketCount;
            //}
        }

        private static void addSinger(SortedDictionary<string, SortedDictionary<string, int>> data, string[] performances)
        {
            string singer = performances[0];

            if (!data.ContainsKey(singer))
            {
                data.Add(singer, new SortedDictionary<string, int>());
            }
        }

        private static bool isValid(string[] performances, string[] participants, string[] songs)
        {
            if (Array.IndexOf(participants, performances[0]) < 0)
            {
                return false;
            }
            if (Array.IndexOf(songs, performances[1]) < 0)
            {
                return false;
            }

            return true;
        }
    }
}
