//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _03.Number_Wars
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var alphabet = "-abcdefghijklmnopqrstuvwxyz";
//            var firstPlayersCards = new Queue<Dictionary<int,string>>();
//            var firstInput = Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries);
//            var secondPlayersCards = new Queue<Dictionary<int, string>>();
//            var secondInput = Console.ReadLine().Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);
//            var turns = 0;
//            var winner = true;
//            var listOfCardsToCheckFirst = new List<string>();
//            var listOfCardsToCheckSecond = new List<string>();
//            var draw = false;

//            foreach (var s in firstInput)
//            {
//                var num = s.Substring(0, s.Length - 1);
//                var letter = s.Substring(s.Length - 1, 1);
//            }

//            while (firstPlayersCards.Count>0&&secondPlayersCards.Count>0&&turns< 1000000)
//            {
//                turns++;
//                var firstPlayerCard = firstPlayersCards.Dequeue();
//                var secondPlayerCard = secondPlayersCards.Dequeue();

//                var firstPlayerCardValue = int.Parse(firstPlayerCard.Substring(0, firstPlayerCard.Length - 1));
//                var secondPlayeCardValue = int.Parse(secondPlayerCard.Substring(0, secondPlayerCard.Length - 1));

//                if (firstPlayerCardValue>secondPlayeCardValue)
//                {
//                    firstPlayersCards.Enqueue(firstPlayerCard);
//                    firstPlayersCards.Enqueue(secondPlayerCard);
//                }
//                else if(secondPlayeCardValue>firstPlayerCardValue)
//                {
//                    secondPlayersCards.Enqueue(secondPlayerCard);
//                    secondPlayersCards.Enqueue(firstPlayerCard);
//                }
//                else if (secondPlayeCardValue == firstPlayerCardValue)
//                {
//                    while (winner)
//                    {
//                        if (firstPlayersCards.Count<3&&secondPlayersCards.Count>=3)
//                        {
//                            break;
//                        }else if (firstPlayersCards.Count >= 3 && secondPlayersCards.Count < 3)
//                        {
//                            break;
//                        }else if (secondPlayersCards.Count < 3 && firstPlayersCards.Count <3 && firstPlayersCards.Count!=secondPlayersCards.Count)
//                        {
//                            break;
//                        }
//                        else if(secondPlayersCards.Count < 3 && firstPlayersCards.Count < 3 && firstPlayersCards.Count == secondPlayersCards.Count)
//                        {
//                            draw = true;
//                            break;
//                        }
//                        for (int i = 0; i < 3; i++)
//                        {
//                            listOfCardsToCheckFirst.Add(firstPlayersCards.Dequeue());
//                            listOfCardsToCheckSecond.Add(secondPlayersCards.Dequeue());
//                        }
//                        var sumOne = 0;
//                        var sumTwo = 0;

                        //foreach (var card in listOfCardsToCheckFirst)
                        //{
                        //    Console.WriteLine(card.Substring(card.Length-1,1));
                        //    sumOne += alphabet.IndexOf(card.Substring(card.Length - 1, 1));
                        //    Console.WriteLine($"{card},{alphabet.IndexOf(card.Substring(card.Length - 1, 1))}");
                        //}
                        //foreach (var card in listOfCardsToCheckSecond)
                        //{
                        //    Console.WriteLine(card.Substring(card.Length - 1, 1));
                        //    sumTwo += alphabet.IndexOf(card.Substring(card.Length - 1, 1));
                        //}
//                        if (sumOne > sumTwo)
//                        {
//                            var cardsToAddWinner = new List<string>();
//                            cardsToAddWinner.AddRange(listOfCardsToCheckFirst);
//                            cardsToAddWinner.AddRange(listOfCardsToCheckSecond);
//                            cardsToAddWinner.Sort(
//                                (a, b) => (int.Parse(b.Substring(0, b.Length - 1))).CompareTo(
//                                    int.Parse(a.Substring(0, a.Length - 1))));
//                            Console.WriteLine(string.Join(",", cardsToAddWinner));
//                            foreach (var card in cardsToAddWinner)
//                            {
//                                firstPlayersCards.Enqueue(card);
//                            }
//                            winner = false;
//                        }
//                        else if (sumOne < sumTwo)
//                        {
//                            var cardsToAddWinner = new List<string>();
//                            cardsToAddWinner.AddRange(listOfCardsToCheckFirst);
//                            cardsToAddWinner.AddRange(listOfCardsToCheckSecond);
//                            cardsToAddWinner.Sort(
//                                (a, b) => (int.Parse(b.Substring(0, b.Length - 1))).CompareTo(
//                                    int.Parse(a.Substring(0, a.Length - 1))));
//                            cardsToAddWinner.Sort((a, b) => b.Substring( b.Length - 1,1).CompareTo(a.Substring( a.Length - 1,1)));
//                            Console.WriteLine(string.Join(",", cardsToAddWinner));
//                            foreach (var card in cardsToAddWinner)
//                            {
//                                secondPlayersCards.Enqueue(card);
//                            }
//                            Console.WriteLine(string.Join(",", cardsToAddWinner));
//                            winner = false;
//                        }
//                        else if ((sumOne == sumTwo) && (firstPlayersCards.Count <= 0 || secondPlayersCards.Count <= 0))
//                        {
//                            winner = false;
//                            draw = true;
//                            break;
//                        }
//                    }
//                }
//                Console.WriteLine($"{string.Join(",",firstPlayersCards)}");
//                Console.WriteLine($"{string.Join(",", secondPlayersCards)}");

//            }
//            if (draw)
//            {
//                Console.WriteLine($"Draw after {turns} turns");
//            }
//            if (firstPlayersCards.Count>secondPlayersCards.Count)
//            {
//                Console.WriteLine($"First player wins after {turns} turns");
                
//            }
//            else if (firstPlayersCards.Count < secondPlayersCards.Count)
//            {
//                Console.WriteLine($"Second player wins after {turns} turns");
//            }
//        }

//        static List<string> Sort(List<string> list)
//        {
//            foreach (var item in list)
//            {
                
//            }

//            return list;
//        }
//    }
//}
