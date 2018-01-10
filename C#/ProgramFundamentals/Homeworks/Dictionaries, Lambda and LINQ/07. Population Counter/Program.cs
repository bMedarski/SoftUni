using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {

            string country = "";

            Dictionary<string, Dictionary<string, long>> countrysPopulation = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {

                string[] userInput = Console.ReadLine().Split('|').ToArray();
                if (userInput[0] == "report")
                {
                    break;
                }
                country = userInput[1];
                string city = userInput[0];
                long population = long.Parse(userInput[2]);
                addCountry(countrysPopulation,country);
                addCity(countrysPopulation,country,city,population);
            }

            countrysPopulation.OrderBy(x => x.Value.Values.Sum());
            
            foreach (var key1 in countrysPopulation.OrderByDescending(i=>i.Value.Values.Sum()))
            {
                long sum = key1.Value.Values.Sum();
                Console.WriteLine("{0} (total population: {1})", key1.Key, sum);
                var value1 = key1.Value;
                foreach (var key2 in value1.OrderByDescending(i=>i.Value))
                {                  
                 Console.WriteLine("=>{0}: {1}", key2.Key, key2.Value);                  
                }
            }

        }

        private static void addCity(Dictionary<string, Dictionary<string, long>> countryPop, string country,string city, long population)
        {
            if (!countryPop[country].ContainsKey(city))
            {
                countryPop[country].Add(city,population);
            }
            countryPop[country][city] = population;
        }

        private static void addCountry(Dictionary<string, Dictionary<string, long>> countryPop, string country)
        {
            if (!countryPop.ContainsKey(country))
            {
                countryPop.Add(country, new Dictionary<string, long>());
            }
        }
    }
}
