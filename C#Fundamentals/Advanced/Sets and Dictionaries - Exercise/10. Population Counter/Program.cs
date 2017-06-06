using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {

            var countries = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                var input = Console.ReadLine().Split('|').ToArray();
                if (input[0] == "report")
                {
                    break;
                }
                var city = input[0];
                var country = input[1];
                var population = long.Parse(input[2]);

                if (countries.ContainsKey(country))
                {
                    if (countries[country].ContainsKey(city))
                    {
                        countries[country][city] += population;
                    }
                    else
                    {
                        countries[country].Add(city, population);
                    }
                }
                else
                {
                    countries[country] = new Dictionary<string, long>();
                    countries[country].Add(city, population);
                }
            }

            foreach (var country in countries.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");
                var val = country.Value;
                foreach (var v in val.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("=>{0}: {1}", v.Key, v.Value);
                }
            }
        }
    }
}