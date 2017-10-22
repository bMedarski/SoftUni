using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

class PrimeMethod
{
    public string name { get; set; }
    public List<string> invokedMethods { get; set; }

    public PrimeMethod(string name, List<string> invokedMethods)
    {
        this.name = name;
        this.invokedMethods = invokedMethods;
    }
}

public class StartProg
{
    public static void Main()
    {
        string declaratedMethodPat = @"static\s+.*\s+([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(";
        Regex declarationRegex = new Regex(declaratedMethodPat);

        string invokeMethodPat = @"([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(";
        Regex invokedRegex = new Regex(invokeMethodPat);


        List<PrimeMethod> allMethods = new List<PrimeMethod>();

        int lines = int.Parse(Console.ReadLine());
        for (int line = 0; line < lines; line++)
        {
            string codeLine = Console.ReadLine();
            Match decMethodMatch = declarationRegex.Match(codeLine);

            if (declarationRegex.IsMatch(codeLine))
            {
                string currDecMethodName = decMethodMatch.Groups[1].Value;

                allMethods.Add(new PrimeMethod(currDecMethodName, new List<string>()));
            }
            else if (allMethods.Count > 0)
            {
                MatchCollection invokedMatches = invokedRegex.Matches(codeLine);

                foreach (Match invMatch in invokedMatches)
                {
                    string currInvokedMethodName = invMatch.Groups[1].Value;
                    allMethods[allMethods.Count - 1].invokedMethods.Add(currInvokedMethodName);
                }
            }
        }


        allMethods.OrderByDescending(d => d.invokedMethods.Count)
            .ThenBy(d => d.name)
            .ToList()
            .ForEach(method =>
            {
                if (method.invokedMethods.Count > 0)
                    Console.WriteLine("{0} -> {1} -> {2}",
                        method.name, method.invokedMethods.Count, string.Join(", ", method.invokedMethods.OrderBy(inv => inv)));
                else
                    Console.WriteLine("{0} -> None", method.name);
            });
    }
}