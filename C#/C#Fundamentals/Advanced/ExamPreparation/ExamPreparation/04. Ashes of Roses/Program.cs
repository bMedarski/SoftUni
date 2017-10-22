using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Ashes_of_Roses
{
    class Program
    {
        static void Main(string[] args)
        {

            var roses = new SortedDictionary<string, SortedDictionary<string,long>>();
            string pattern = @"Grow\s<([A-Z]{1}[a-z]+)>\s<(\w+)>\s(\d+)";
            string patternN = (@"^Grow\s<([A-Z]{1}[a-z]+)>\s<([A-Za-z0-9]+)>\s(\d+)$");

            while (true)
            {
                var input = Console.ReadLine();
                if (input== "Icarus, Ignite!")
                {
                    break;
                }                
                Match successInput = Regex.Match(input, patternN);
                if (successInput.Success)
                {
                var region = successInput.Groups[1].Value;
                var roseColor = successInput.Groups[2].Value;
                var amount = long.Parse(successInput.Groups[3].Value);
                AddRegion(roses,region);
                AddRoseColor(roses,region,roseColor,amount);
                }                            
            }
            foreach (var rose in roses.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine(rose.Key);
                var val = rose.Value;
                foreach (var r in val.OrderBy(x=>x.Value))
                {
                    Console.WriteLine($"*--{r.Key} | {r.Value}");
                }
            }
        }
        

        private static void AddRoseColor(SortedDictionary<string, SortedDictionary<string, long>> roses, string region, string roseColor, long amount)
        {
            if (!roses[region].ContainsKey(roseColor))
            {
                roses[region].Add(roseColor, amount);
            }
            else
            {
                roses[region][roseColor] += amount;
            }
            
        }

        private static void AddRegion(SortedDictionary<string, SortedDictionary<string, long>> roses, string region)
        {
            if (!roses.ContainsKey(region))
            {
                roses.Add(region, new SortedDictionary<string, long>());
            }
        }
    }
}
