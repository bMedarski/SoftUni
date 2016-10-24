using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            long listCount = long.Parse(Console.ReadLine());      //1000
            List<long> bugsPosition = Console.ReadLine().Split().Select(long.Parse).ToList();    //int
            bool[] listOfBugs = new bool[listCount];
            List<long> validBugs = new List<long>();

            for (int i = 0; i < bugsPosition.Count; i++)
            {
                if (0 <= bugsPosition[i] && bugsPosition[i] < listCount)
                {
                    validBugs.Add(bugsPosition[i]);
                }
            }
            validBugs.Distinct();
            //Console.WriteLine(string.Join(",", validBugs));   //1 2 3 4 6 5
            for (int i = 0; i < listOfBugs.Length; i++)
            {
                for (int j = 0; j < validBugs.Count; j++)
                {
                    if (i == validBugs[j])
                    {
                        listOfBugs[i] = true;
                    }
                }
            }
            //Console.WriteLine(string.Join(",", listOfBugs));
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;                   
                }
                executeCommand(command, validBugs, listCount);
            }
            for (int i = 0; i < listCount; i++)
            {
                if (validBugs.Contains(i))
                {
                    Console.Write("1 ");
                }else
                {
                    Console.Write("0 ");
                }
            }
            
        }

        private static void executeCommand(string command, List<long> validBugs, long listCount)
        {
            string[] commands = command.Split();
            long bugIndex = long.Parse(commands[0]);
            string direction = commands[1];
            long step = long.Parse(commands[2]);
            long newPosition = 0;
            bool correctPosition = true;
            if (direction == "right")
            {
                newPosition = bugIndex + step;
            }
            else
            {
                newPosition = bugIndex - step;
            }

            while (correctPosition)
            {                
                if (0 <= bugIndex && bugIndex < listCount)
                {
                    if (!validBugs.Contains(bugIndex))
                    {
                        correctPosition = false;
                    }
                    else
                    {
                              
                        validBugs.Remove(bugIndex);
                        if (0 <= newPosition && newPosition < listCount)
                        {
                            if (!validBugs.Contains(newPosition))
                            {
                                validBugs.Add(newPosition);
                                correctPosition = false;
                            }
                            else
                            {
                                if (direction == "right")
                                {
                                    newPosition = newPosition + step;
                                }
                                else
                                {
                                    newPosition = newPosition - step;
                                }
                            }
                        }
                        else
                        {
                            correctPosition = false;
                        }
                       
                    }
                }else
                {
                    correctPosition = false;
                }
            }
            return;
        }

        //private static void executeCommand(string command, bool[] listOfBugs)
        //{
        //    string[] commands = command.Split();
        //    int bugIndex = int.Parse(commands[0]);
        //    string direction = commands[1];
        //    int step = int.Parse(commands[2]);
        //    int newPosition = 0;
        //    bool inRange = true;
        //    //Console.WriteLine(string.Join(",", listOfBugs));      5   1 2 4
        //        if (0 <= bugIndex && bugIndex < listOfBugs.Length)
        //        {
        //            //while (inRange) {
        //            if (direction == "right")
        //            {
        //                newPosition = bugIndex + step;
        //            }
        //            else
        //            {
        //                newPosition = bugIndex - step;
        //            }
        //            //Console.WriteLine(listOfBugs.Length);
        //            if (newPosition >= listOfBugs.Length||newPosition<0)
        //            {
        //            return;
        //            }
        //            if (listOfBugs[newPosition] == false)
        //                {
        //                    listOfBugs[newPosition] = true;
        //                    listOfBugs[bugIndex] = false;
        //                  Console.WriteLine(listOfBugs[newPosition]);
        //                 Console.WriteLine(listOfBugs[bugIndex]);
        //                inRange = false;

        //                }                       
        //        //}   
        //    } 
        //     return;
    }
    
}
