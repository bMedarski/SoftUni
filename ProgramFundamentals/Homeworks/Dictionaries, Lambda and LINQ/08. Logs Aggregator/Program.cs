using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int logsCount = int.Parse(Console.ReadLine());
            SortedDictionary<string, SortedDictionary<string, int>> userLogs = new SortedDictionary<string, SortedDictionary<string, int>>();
            for (int i = 0; i < logsCount; i++)
            {
                string[] logs = Console.ReadLine().Split().ToArray();

                string ip = logs[0];
                string user = logs[1];
                int duration = int.Parse(logs[2]);

                addUser(userLogs,user);
                addIp(userLogs,user,ip,duration);
                Console.WriteLine();
            }
            foreach (var item in userLogs)
            {
                var userName = item.Key;
                var ipAdresses = item.Value.Keys.ToArray();
                var totalDuration = item.Value.Values.Sum();
                Console.WriteLine("{0}: {1} [{2}]",userName,totalDuration, string.Join(", ",ipAdresses));

            }
        }

        private static void addIp(SortedDictionary<string, SortedDictionary<string, int>> userLogs, string user, string ip, int duration)
        {
            if (!userLogs[user].ContainsKey(ip))
            {
                userLogs[user].Add(ip, duration);
            }
            else
            {
                userLogs[user][ip] += duration;
            }
        }

        private static void addUser(SortedDictionary<string, SortedDictionary<string, int>> userLogs, string user)
        {
            if (!userLogs.ContainsKey(user))
            {
                userLogs.Add(user, new SortedDictionary<string, int>());
            }
        }
    }
}
