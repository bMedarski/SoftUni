using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var alphabet = "-abcdefghijklmnopqrstuvwxyz";
            var firstPlayersCards = new Queue<Dictionary<int, string>>();
            var firstInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var secondPlayersCards = new Queue<Dictionary<int, string>>();
            var secondInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var turns = 0;
            var winner = true;
            var listOfCardsToCheckFirst = new List<Dictionary<int, string>>();
            var listOfCardsToCheckSecond = new List<Dictionary<int, string>>();
            var cardsToAddWinner = new List<Dictionary<int, string>>();
            var draw = false;

            foreach (var s in firstInput)
            {
                var num = int.Parse(s.Substring(0, s.Length - 1));
                var letter = s.Substring(s.Length - 1, 1);
                var dict = new Dictionary<int, string>();
                dict.Add(num, letter);
                firstPlayersCards.Enqueue(dict);
            }
            foreach (var s in secondInput)
            {
                var num = int.Parse(s.Substring(0, s.Length - 1));
                var letter = s.Substring(s.Length - 1, 1);
                var dict = new Dictionary<int, string>();
                dict.Add(num, letter);
                secondPlayersCards.Enqueue(dict);
            }
            while (firstPlayersCards.Count > 0 && secondPlayersCards.Count > 0 && turns < 1000000)
            {
                turns++;
                var firstPlayerCard = firstPlayersCards.Dequeue();
                var secondPlayerCard = secondPlayersCards.Dequeue();

                var firstPlayerCardValue = firstPlayerCard.Keys.ToArray()[0];
                var secondPlayeCardValue = secondPlayerCard.Keys.ToArray()[0];
                //Console.WriteLine(firstPlayerCardValue);
                if (firstPlayerCardValue > secondPlayeCardValue)
                {
                    firstPlayersCards.Enqueue(firstPlayerCard);
                    firstPlayersCards.Enqueue(secondPlayerCard);
                }
                else if (secondPlayeCardValue > firstPlayerCardValue)
                {
                    secondPlayersCards.Enqueue(secondPlayerCard);
                    secondPlayersCards.Enqueue(firstPlayerCard);
                }
                else if (secondPlayeCardValue == firstPlayerCardValue)
                {
                    while (true)
                    {
                        if (firstPlayersCards.Count < 3 && secondPlayersCards.Count >= 3)
                        {
                            break;
                        }
                        else if (firstPlayersCards.Count >= 3 && secondPlayersCards.Count < 3)
                        {
                            break;
                        }
                        else if (secondPlayersCards.Count < 3 && firstPlayersCards.Count < 3 && firstPlayersCards.Count != secondPlayersCards.Count)
                        {
                            break;
                        }
                        else if (secondPlayersCards.Count < 3 && firstPlayersCards.Count < 3 && firstPlayersCards.Count == secondPlayersCards.Count)
                        {
                            draw = true;
                            break;
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            listOfCardsToCheckFirst.Add(firstPlayersCards.Dequeue());
                            listOfCardsToCheckSecond.Add(secondPlayersCards.Dequeue());
                        }
                        var sumOne = 0;
                        var sumTwo = 0;
                        foreach (var card in listOfCardsToCheckFirst)
                        {
                            sumOne += alphabet.IndexOf(card.Values.ToArray()[0]);
                        }
                        foreach (var card in listOfCardsToCheckSecond)
                        {
                            sumTwo += alphabet.IndexOf(card.Values.ToArray()[0]);
                        }
                        //Console.WriteLine(sumOne);
                        //Console.WriteLine(sumTwo);
                        if (sumOne > sumTwo)
                        {
                            cardsToAddWinner.AddRange(listOfCardsToCheckFirst);
                            cardsToAddWinner.AddRange(listOfCardsToCheckSecond);
                            cardsToAddWinner.Sort(
                                (a, b) => (b.Values.ToArray()[0]).CompareTo(
                                    a.Values.ToArray()[0]));
                            cardsToAddWinner.Sort(
                                (a, b) => (b.Keys.ToArray()[0]).CompareTo(
                                    a.Keys.ToArray()[0]));
                            foreach (var card in cardsToAddWinner)
                            {
                                firstPlayersCards.Enqueue(card);
                            }
                        }
                        else if (sumOne < sumTwo)
                        {
                            cardsToAddWinner.AddRange(listOfCardsToCheckFirst);
                            cardsToAddWinner.AddRange(listOfCardsToCheckSecond);
                            cardsToAddWinner.Sort(
                                (a, b) => (b.Values.ToArray()[0]).CompareTo(
                                    a.Values.ToArray()[0]));
                            cardsToAddWinner.Sort(
                                (a, b) => (b.Keys.ToArray()[0]).CompareTo(
                                    a.Keys.ToArray()[0]));
                            foreach (var card in cardsToAddWinner)
                            {
                                secondPlayersCards.Enqueue(card);
                            }
                        }
                    }
                }
            }
            if (draw)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else if (firstPlayersCards.Count > secondPlayersCards.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");

            }
            else if (firstPlayersCards.Count < secondPlayersCards.Count)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }

        }
    }
}