using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()           // 100/100 без нулев тест
    {
        string command = Console.ReadLine();
        Dictionary<string, int> cards = new Dictionary<string, int>();

        while (command != "JOKER")
        {
            string[] actions = command.Split(':').ToArray();
            string name = actions[0];
            string[] cardsSeq = actions[1].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .ToArray();
            int result = 0;

            foreach (string card in cardsSeq)
            {
                string cardType = card.Substring(0, card.Length - 1);
                int points = ExtractCardPoints(cardType);
                int multiplicator = Multipliers(card[card.Length - 1]);
                result += points * multiplicator;

            }

            if (cards.ContainsKey(name))
            {
                cards[name] += result;
            }
            else
            {
                cards[name] = result;
            }

            command = Console.ReadLine();
        }

        foreach (var pair in cards)
        {
            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        }
    }

    static int Multipliers(char letter)
    {
        int val = 0;

        switch (letter)
        {
            case 'S': val = 4; break;
            case 'H': val = 3; break;
            case 'D': val = 2; break;
            default: val = 1; break;
        }

        return val;
    }
    static List<string> UpdateList(List<string> currentList, List<string> newList)
    {
        foreach (var item in newList)
        {
            currentList.Add(item);
        }
        List<string> distinct = currentList.Distinct().ToList();
        return distinct;
    }
    static int ExtractCardPoints(string input)
    {
        int result = 0;

        switch (input)
        {
            case "J":
                result += 11;
                break;
            case "Q":
                result += 12;
                break;
            case "K":
                result += 13;
                break;
            case "A":
                result += 14;
                break;
            default:
                result = int.Parse(input);
                break;
        }

        return result;
    }
}