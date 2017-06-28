using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Jedi_Dreams
{
    internal class Prime
    {
        public  string Name { get; set; }

        public List<string> Methods { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {

            var lineCounts = int.Parse(Console.ReadLine());
            var patternStatic = @"static \w+ ([A-Z]\w+)\(.+\)";
            var patternInternalMethods = @"([a-zA-Z]*[A-Z][\w]*)\s*\(";
            var primeStaticMatch = new Regex(patternStatic);
            var internalMethodsMAtch = new Regex(patternInternalMethods);
            var primes = new List<Prime>();
            var currentMethod = "";
            for (int i = 0; i < lineCounts; i++)
            {
                var line = Console.ReadLine();
                var match = primeStaticMatch.Match(line);
                if (match.Success)
                {
                   var methodName = match.Groups[1].Value;
                   currentMethod = methodName;
                   var newPrimeMethod = new Prime();
                    newPrimeMethod.Name = methodName;
                    primes.Add(newPrimeMethod);
                }
                var intMethod = internalMethodsMAtch.Match(line);
                if (intMethod.Success)
                {
                    
                    var intMethodToAdd = intMethod.Groups[1].Value;
                    if (intMethodToAdd!=currentMethod)
                    {
                        primes.First(x=>x.Name==currentMethod).Methods.Add(intMethodToAdd);
                    }
                    
                    //toAdd.Methods.Add(intMethodToAdd);
                }
            }
            foreach (var prime in primes)
            {
                Console.WriteLine($"{prime.Name} -> {prime.Methods.Count} -> {string.Join(", ",prime.Methods)}");
            }
        }
    }
}
