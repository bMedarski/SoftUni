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
                if (ticket.Length!=20)
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
            for (int i = 1; i <10; i++)
            {
                if (ticketSymbols[i]=='@'&& ticketSymbols[i]== ticketSymbols[i-1])
                {
                    
                    countOneBefore++;
                    
                    if(ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countOneBefore = 1;
                    }
                }else
                {
                    if (maxBefore< countOneBefore)
                    {
                        maxBefore = countOneBefore;
                        symbol = '@';
                    }
                }
                if (ticketSymbols[i] == '#' && ticketSymbols[i] == ticketSymbols[i - 1])
                {
                    countTwoBefore++;
                   
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countTwoBefore = 1;
                    }

                }
                else
                {
                    if (maxBefore <= countTwoBefore)
                    {
                        maxBefore = countTwoBefore;
                        symbol = '#';
                    }
                }
                if (ticketSymbols[i] == '$' && ticketSymbols[i] == ticketSymbols[i - 1])
                {
                    countTreeBefore++;
                    
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countTreeBefore = 1;
                    }
                }
                else
                {
                if (maxBefore < countTreeBefore)
                    {
                        maxBefore = countTreeBefore;
                        symbol = '$';
                    }
                }
                if (ticketSymbols[i] == '^' && ticketSymbols[i] == ticketSymbols[i - 1])
                {
                    countFourBefore++;
                    
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countFourBefore = 1;
                    }
                }else
                {
                    if (maxBefore < countFourBefore)
                    {
                        maxBefore = countFourBefore;
                        symbol = '^';
                    }
                }
            }
            for (int i = 11; i < 20; i++)
            {
                if (ticketSymbols[i] == '@' && ticketSymbols[i] == ticketSymbols[i - 1])
                {
                    countOneAfter++;
                    
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countOneAfter = 1;
                    }
                }else
                {
                    if (maxAfter < countOneAfter)
                    {
                        maxAfter = countOneAfter;
                        symbol = '@';
                    }
                }
                if (ticketSymbols[i] == '#' && ticketSymbols[i] == ticketSymbols[i - 1])
                {
                    countTwoAfter++;
                    
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countTwoAfter = 1;
                    }
                }else
                {
                    if (maxAfter < countTwoAfter)
                    {
                        maxAfter = countTwoAfter;
                        symbol = '#';
                    }
                }
                if (ticketSymbols[i] == '$' && ticketSymbols[i] == ticketSymbols[i - 1])
                {
                    countTreeAfter++;
                    
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countTreeAfter = 1;
                    }
                }
                else
                {
                    if (maxAfter < countTreeAfter)
                    {
                        maxAfter = countTreeAfter;
                        symbol = '$';
                    }
                }
                if (ticketSymbols[i] == '^' && ticketSymbols[i] == ticketSymbols[i - 1])
                {
                    countFourAfter++;
                    
                    if (ticketSymbols[i] != ticketSymbols[i - 1])
                    {
                        countFourAfter = 1;
                    }
                }
                else
                {
                    if (maxAfter < countFourAfter)
                    {
                        maxAfter = countFourAfter;
                        symbol = '^';
                    }
                }
            }
            if (Math.Min(maxAfter, maxBefore) >=6)
            {
                if (Math.Min(maxAfter, maxBefore) == 10)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {maxBefore}@ Jackpot!");
                }else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(maxAfter, maxBefore)}{symbol}");
                }
                
            }
            //else if (Math.Min(countTwoBefore, countTwoAfter) >= 6)
            //{
            //    if (Math.Min(countTwoBefore, countTwoAfter) == 10)
            //    {
            //        Console.WriteLine($"ticket \"{ticket}\" - {countTwoBefore}# Jackpot!");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(countTwoBefore, countTwoAfter)}#");
            //    }

            //}
            //else if (Math.Min(countTreeBefore, countTreeAfter) >= 6)
            //{
            //    if (Math.Min(countTreeBefore, countTreeAfter) == 10)
            //    {
            //        Console.WriteLine($"ticket \"{ticket}\" - {countTreeBefore}$ Jackpot!");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(countTreeBefore, countTreeAfter)}$");
            //    }
            //}
            //else if (Math.Min(countFourBefore, countFourAfter) >= 6)
            //{
            //    if (Math.Min(countFourBefore, countFourAfter) == 10)
            //    {
            //        Console.WriteLine($"ticket \"{ticket}\" - {countFourBefore}^ Jackpot!");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(countFourBefore, countFourAfter)}^");
            //    }
            //}
            else
            {
                Console.WriteLine($"ticket \"{ticket}\" - no match");
            }

        }
    }
}
