using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] demonList = Console.ReadLine().Split(new char[] { ' ',',' }, StringSplitOptions.RemoveEmptyEntries);
            List<Demon> demons = new List<Demon>();
            



            foreach (var item in demonList)
            {
                addDemon(item, demons);
            }
                    


           // Console.WriteLine(string.Join("-",demonList));



        }

        private static void addDemon(string item, List<Demon> demons)
        {
            Demon demon = new Demon();

            demon.DemonName = item;
            int health = 0;
            double damage = 0;
            var split = item.ToCharArray();
            string pattern = @"[-+]?([0-9]*\.[0-9]+|[0-9]+)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(item);
            while (match.Success)
            {
                damage += double.Parse(match.Value);
                Console.WriteLine(match);
                match = match.NextMatch();

            }
            Console.WriteLine(damage);
        }
    }
    class Demon
    {
        public string DemonName { get; set; }
        public int DemonHealth { get; set; }
        public double DemonDamage { get; set; }
    }

}
