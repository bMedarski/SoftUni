using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {


            //SortedDictionary<string, int> ipAdresses = new SortedDictionary<string, int>();
            //  ip adress -> count messages
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();

            string user = "";

            while (true)
            {
               
                string[] input = Console.ReadLine().Split().ToArray();
                string ip = input[0];
                if (ip == "end")
                {
                    break;
                }

                user = input[2].Substring(5);
                ip = input[0].Substring(3);
                string message = input[1];


                //Console.WriteLine(user);
                //Console.WriteLine(ip);                

                if (!users.ContainsKey(user))
                {
                    users[user] = new Dictionary<string, int>(); ;
                    if (!users[user].ContainsKey(ip))
                    {
                        users[user].Add(ip,1);
                    }else
                    {
                        users[user][ip] += 1;
                    }
                }
                else
                {
                    if (!users[user].ContainsKey(ip))
                    {
                        users[user].Add(ip, 1);
                    }
                    else
                    {
                        users[user][ip] += 1;
                    }
                }
            }
            
            int count = 0;
            foreach (var key1 in users.Keys)
            {
                Console.WriteLine("{0}: ", key1);
                var value1 = users[key1];
                count = users[key1].Count;
                //Console.WriteLine(count);
                foreach (var key2 in value1)
                {
                    if (count > 1)
                    {
                        Console.Write("{0} => {1}, ", key2.Key, key2.Value);
                    }
                    else
                    {
                        Console.Write("{0} => {1}.", key2.Key, key2.Value);
                       
                    }
                    count--;
                }
                Console.WriteLine();          
            }
            //foreach (var key1 in dc.Keys)
            //{
            //    Console.WriteLine(key1);
            //    var value1 = dc[key1];
            //    foreach (var key2 in value1.Keys)
            //    {
            //        Console.WriteLine("    {0}, {1}", key2, value1[key2]);
            //    }
            //}

        }
    }
}
