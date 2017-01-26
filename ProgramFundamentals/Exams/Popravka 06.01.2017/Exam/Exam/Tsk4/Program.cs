using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tickets = Console.ReadLine().Split(new char[] { ',', ' ' },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            //Console.WriteLine(string.Join("///", tickets));
            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    checkForPrise(ticket);
                }


            }
            //Console.WriteLine(string.Join("///", tickets));
        }

        private static void checkForPrise(string ticket)
        {
            var ticketSymbols = ticket.ToCharArray();
            // '@', '#', '$' and '^'
            int countOneBefore = 1;
            int countTwoBefore = 1;
            int countTreeBefore = 1;
            int countFourBefore = 1;
            int countOneAfter = 1;
            int countTwoAfter = 1;
            int countTreeAfter = 1;
            int countFourAfter = 1;
            int maxBefore = 1;
            int maxAfter = 1;
            char symbol = '-';
            for (int i = 1; i < 10; i++)
            {
                if (ticketSymbols[i] == '@')
                {
symbol = '@';
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countOneBefore = 1;
                    }else
                    {
                        countOneBefore++;
                        if (maxBefore< countOneBefore)
                        {
                            maxBefore = countOneBefore;
                            
                        }
                    }
                }
                if (ticketSymbols[i] == '#')
                {
symbol = '#';
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countTwoBefore = 1;
                    }
                    else
                    {
                        countTwoBefore++;
                        if (maxBefore < countTwoBefore)
                        {
                            maxBefore = countTwoBefore;
                            
                        }
                    }
                }
                if (ticketSymbols[i] == '$')
                {
symbol = '$';
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countTreeBefore = 1;
                    }
                    else
                    {
                        countTreeBefore++;
                        if (maxBefore < countTreeBefore)
                        {
                            maxBefore = countTreeBefore;
                            
                        }
                    }
                }
                if (ticketSymbols[i] == '^')
                {
symbol = '^';
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countFourBefore = 1;
                    }
                    else
                    {
                        countFourBefore++;
                        if (maxBefore < countFourBefore)
                        {
                            maxBefore = countFourBefore;
                            
                        }
                    }
                }
            }
            for (int i = 11; i < 20; i++)
            {
                if (ticketSymbols[i] == '@')
                {
                    symbol = '@';
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countOneAfter = 1;
                    }
                    else
                    {
                        countOneAfter++;
                        if (maxAfter < countOneAfter)
                        {
                            maxAfter = countOneAfter;
                            
                        }
                    }
                }
                if (ticketSymbols[i] == '#')
                {
symbol = '#';
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countTwoAfter = 1;
                    }
                    else
                    {
                        countTwoAfter++;
                        if (maxAfter < countTwoAfter)
                        {
                            maxAfter = countTwoAfter;
                            
                        }
                    }
                }
                if (ticketSymbols[i] == '$')
                {
symbol = '$';
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countTreeAfter = 1;
                    }
                    else
                    {
                        countTreeAfter++;
                        if (maxAfter < countTreeAfter)
                        {
                            maxAfter = countTreeAfter;
                            
                        }
                    }
                }
                if (ticketSymbols[i] == '^')
                {
symbol = '^';
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countFourAfter = 1;
                    }
                    else
                    {
                        countFourAfter++;
                        if (maxAfter < countFourAfter)
                        {
                            maxAfter = countFourAfter;
                            
                        }
                    }
                }
            }
            if (Math.Min(maxAfter, maxBefore) >= 6)
            {
                if (Math.Min(maxAfter, maxBefore) == 10)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(maxAfter, maxBefore)}{symbol} Jackpot!");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(maxAfter, maxBefore)}{symbol}");
                }

            }
            //else if ((countTwoBefore == countTwoAfter) && countTwoBefore >= 6)
            //{
            //    if (countTwoBefore == 10)
            //    {
            //        Console.WriteLine($"ticket \"{ticket}\" - {countTwoBefore}# Jackpot!");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"ticket \"{ticket}\" - {countTwoBefore}#");
            //    }

            //}
            //else if ((countTreeBefore == countTreeAfter) && countTreeBefore >= 6)
            //{
            //    if (countTreeBefore == 10)
            //    {
            //        Console.WriteLine($"ticket \"{ticket}\" - {countTreeBefore}$ Jackpot!");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"ticket \"{ticket}\" - {countTreeBefore}$");
            //    }
            //}
            //else if ((countFourBefore == countFourAfter) && countFourBefore >= 6)
            //{
            //    if (countFourBefore == 10)
            //    {
            //        Console.WriteLine($"ticket \"{ticket}\" - {countFourBefore}^ Jackpot!");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"ticket \"{ticket}\" - {countFourBefore}^");
            //    }
            //}
            else
            {
                Console.WriteLine($"ticket \"{ticket}\" - no match");
            }

        }
    }
}