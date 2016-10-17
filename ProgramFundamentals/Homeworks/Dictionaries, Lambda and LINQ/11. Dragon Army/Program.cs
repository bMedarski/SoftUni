using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, SortedDictionary<string, List<double>>> dragonsData = new Dictionary<string, SortedDictionary<string, List<double>>>();
            string dragonType = "";
            string dragonName = "";
            double dragonHealth = 0;
            double dragonArmor = 0;
            double dragonDamage = 0;
            List<double> averageStats = new List<double>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                dragonType = getType(input);
                dragonName = getName(input);
                dragonDamage = getDamage(input);
                dragonHealth = getHealth(input);
                dragonArmor = getArmor(input);
                List<double> dragonStats = new List<double>();
                dragonStats.Add(dragonDamage);
                dragonStats.Add(dragonHealth);
                dragonStats.Add(dragonArmor);
                addType(dragonsData,dragonType);
                addDragonName(dragonsData, dragonType, dragonName,dragonStats);
                
                //Console.WriteLine(dragonArmor);
               
            }
            foreach (var item in dragonsData)
            {
                
                getAverage(item.Value);
                averageStats = getAverage(item.Value).ToList();
                Console.WriteLine($"{item.Key}::({averageStats[0]:F2}/{averageStats[1]:F2}/{averageStats[2]:F2})");
                var value = item.Value;
                foreach (var item2 in value)
                {
                    Console.WriteLine($"-{item2.Key} -> damage: {item2.Value[0]}, health: {item2.Value[1]}, armor: {item2.Value[2]}");                   
                }
            }
            
            
        }

        private static List<double> getAverage(SortedDictionary<string, List<double>> value)
        {
            double sumDamage = 0;
            double sumHealth = 0;
            double sumArmor = 0;
            int count = 0;
            List<double> averages = new List<double>();
            foreach (var item in value)
            {
                sumDamage += item.Value[0];
                sumHealth += item.Value[1];
                sumArmor += item.Value[2];
                count++;
            }
            averages.Add(sumDamage / count);
            averages.Add(sumHealth / count);
            averages.Add(sumArmor / count);
            return averages;
        }

        private static void addDragonName(Dictionary<string, SortedDictionary<string, List<double>>> dragonsData, string dragonType, string dragonName, List<double> dragonStats)
        {
            if (!dragonsData[dragonType].ContainsKey(dragonName))
            {
                dragonsData[dragonType].Add(dragonName,dragonStats);
            }
            else
            {
                dragonsData[dragonType][dragonName] = dragonStats.ToList();
            }
            //List<Int32> copy = new List<Int32>(original);
            //or if you're using C# 3 and .NET 3.5, with Linq, you can do this:

            //List<Int32> copy = original.ToList();
        }

        private static void addType(Dictionary<string, SortedDictionary<string, List<double>>> dragonsData, string dragonType)
        {
            if (!dragonsData.ContainsKey(dragonType))
            {
                dragonsData.Add(dragonType,new SortedDictionary<string, List<double>>());
            }
        }

        private static double getArmor(string input)
        {
            string[] splitInput = input.Split().ToArray();
            double armor = 10;
            if (double.TryParse(splitInput[4], out armor))
            {
                armor = double.Parse(splitInput[4]);
            }
            else
            {
                armor = 10;
            }
            return armor;
        }

        private static double getHealth(string input)
        {
            string[] splitInput = input.Split().ToArray();
            double health = 250;
            if (double.TryParse(splitInput[3], out health))
            {
                health = double.Parse(splitInput[3]);
            }
            else
            {
                health = 250;
            }
            return health;
        }

        private static double getDamage(string input)
        {
            string[] splitInput = input.Split().ToArray();
            double damage = 45;
            if(double.TryParse(splitInput[2], out damage)){
                damage = double.Parse(splitInput[2]);
            }else
            {
                damage = 45;
            }
            return damage;
        }

        private static string getName(string input)
        {
            string[] splitInput = input.Split().ToArray();
            return splitInput[1];
        }

        private static string getType(string input)
        {
            string[] splitInput = input.Split().ToArray();
            return splitInput[0];
        }
    }
}
