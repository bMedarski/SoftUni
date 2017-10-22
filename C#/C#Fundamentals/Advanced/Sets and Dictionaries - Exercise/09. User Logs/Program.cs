using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _09.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {

            var userLog = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0] == "end")
                {
                    break;
                }
                var msg = input[1];
                var user = input[2].Substring(5);
                var ip = input[0].Substring(3);

                if (userLog.ContainsKey(user))
                {
                    if (userLog[user].ContainsKey(ip))
                    {
                        userLog[user][ip]++;
                    }
                    else
                    {
                        userLog[user].Add(ip, 1);
                    }
                }
                else
                {
                    userLog[user] = new Dictionary<string, int>();
                    userLog[user].Add(ip, 1);
                }

            }

            foreach (var user in userLog.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}:");
                var val = user.Value;
                var count = val.Count;
                foreach (var v in val)
                {
                    if (count > 1)
                    {
                        Console.Write("{0} => {1}, ", v.Key, v.Value);
                    }
                    else
                    {
                        Console.Write("{0} => {1}.", v.Key, v.Value);

                    }
                    count--;
                }
                Console.WriteLine();
            }
        }
    }
}