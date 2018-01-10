using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Hands_of_Cards
{
    class Program
    {
        static void Main(string[] args) //100/100
        {

            string name = "";
            List<string> cards = new List<string>();
            Dictionary<String, List<string>> playerAndCards = new Dictionary<string, List<string>>();
            char[] separator = { ',',' ' };
            while (name != "JOKER")
            {
                string[] input = Console.ReadLine().Split(':').ToArray();
                name = input[0];
                if (name == "JOKER")
                {
                    break;
                }
                cards = input[1].Split(separator, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();                                            
                if (playerAndCards.ContainsKey(name))
                {
                    playerAndCards[name] = UpdateList(playerAndCards[name], cards);
                }
                else
                {
                    playerAndCards[name] = cards;
                }
            }

            foreach (var player in playerAndCards)
            {
                int value = CardsValue(player.Value);
                Console.WriteLine($"{player.Key}: {value}");
            }

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
        static int CardsValue(List<string> listOfCards)
        {
            int sum = 0;
            Dictionary<string, int> Values = new Dictionary<string, int>()
        { {"1C",1},
          {"2C",2},
          {"3C",3},
          {"4C",4},
          {"5C",5},
          {"6C",6},
          {"7C",7},
          {"8C",8},
          {"9C",9},
          {"10C",10},
          {"AC",14},
          {"JC",11},
          {"QC",12},
          {"KC",13},
          {"1D",2},
          {"2D",4},
          {"3D",6},
          {"4D",8},
          {"5D",10},
          {"6D",12},
          {"7D",14},
          {"8D",16},
          {"9D",18},
          {"10D",20},
          {"AD",28},
          {"JD",22},
          {"QD",24},
          {"KD",26},
          {"1H",3},
          {"2H",6},
          {"3H",9},
          {"4H",12},
          {"5H",15},
          {"6H",18},
          {"7H",21},
          {"8H",24},
          {"9H",27},
          {"10H",30},
          {"AH",42},
          {"JH",33},
          {"QH",36},
          {"KH",39},
          {"1S",4},
          {"2S",8},
          {"3S",12},
          {"4S",16},
          {"5S",20},
          {"6S",24},
          {"7S",28},
          {"8S",32},
          {"9S",36},
          {"10S",40},
          {"AS",56},
          {"JS",44},
          {"QS",48},
          {"KS",52},
        };    
            foreach (var card in listOfCards)
            {
                //Console.Write(card);
                sum += Values[card];
            }
            return sum;
        } }
}
