using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {

            var lines = int.Parse(Console.ReadLine());
            var log = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var user = input[1];
                var ip = input[0];
                var duration = int.Parse(input[2]);

                if (log.ContainsKey(user))
                {
                    if (log[user].ContainsKey(ip))
                    {
                        log[user][ip] += duration;
                    }
                    else
                    {
                        log[user].Add(ip, duration);
                    }
                }
                else
                {
                    log[user] = new SortedDictionary<string, int>();
                    log[user].Add(ip,duration);
                }
            }
            foreach (var user in log)
            {
                var values = user.Value;
                Console.Write($"{user.Key}: {user.Value.Values.Sum()} [");               
                Console.Write(string.Join(", ",values.Keys));
                Console.Write("]");
                Console.WriteLine();
            }
        }
    }
}
